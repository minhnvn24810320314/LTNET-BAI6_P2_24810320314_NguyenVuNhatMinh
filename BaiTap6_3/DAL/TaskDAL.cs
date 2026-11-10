using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BaiTap6_3.DTO;

namespace BaiTap6_3.DAL
{
    public class TaskDAL
    {
        // 1. Lấy danh sách Task lọc theo Dự án & Trạng thái
        public DataTable GetTasksByFilter(int maDuAn, string trangThai)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT c.MaTask, c.TenTask, c.MoTa, c.HanNop, c.DoUuTien, c.TrangThai 
                                FROM CongViec c WHERE 1=1";
                if (maDuAn > 0) query += " AND c.MaDuAn = @MaDuAn";
                if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả") query += " AND c.TrangThai = @TrangThai";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (maDuAn > 0) cmd.Parameters.AddWithValue("@MaDuAn", maDuAn);
                    if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả") cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // 2. Thêm Task mới & Phân công cho Thành viên (Sử dụng SqlTransaction)
        public bool InsertTask(CongViecDTO task, int maThanhVien)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string queryTask = @"INSERT INTO CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai) 
                                             VALUES (@MaDuAn, @TenTask, @MoTa, @HanNop, @DoUuTien, @TrangThai);
                                             SELECT SCOPE_IDENTITY();";
                        SqlCommand cmdTask = new SqlCommand(queryTask, conn, trans);
                        cmdTask.Parameters.AddWithValue("@MaDuAn", task.MaDuAn);
                        cmdTask.Parameters.AddWithValue("@TenTask", task.TenTask);
                        cmdTask.Parameters.AddWithValue("@MoTa", task.MoTa ?? (object)DBNull.Value);
                        cmdTask.Parameters.AddWithValue("@HanNop", task.HanNop);
                        cmdTask.Parameters.AddWithValue("@DoUuTien", task.DoUuTien);
                        cmdTask.Parameters.AddWithValue("@TrangThai", task.TrangThai);

                        int newTaskId = Convert.ToInt32(cmdTask.ExecuteScalar());

                        if (maThanhVien > 0)
                        {
                            string queryPC = "INSERT INTO PhanCong (MaTask, MaThanhVien) VALUES (@MaTask, @MaThanhVien)";
                            SqlCommand cmdPC = new SqlCommand(queryPC, conn, trans);
                            cmdPC.Parameters.AddWithValue("@MaTask", newTaskId);
                            cmdPC.Parameters.AddWithValue("@MaThanhVien", maThanhVien);
                            cmdPC.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        // 3. Cập nhật Trạng thái Task (Parameterized SQL Update)
        public bool UpdateTaskStatus(int maTask, string trangThaiMoi)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE CongViec SET TrangThai = @TrangThai WHERE MaTask = @MaTask";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                    cmd.Parameters.AddWithValue("@MaTask", maTask);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 4. Cảnh báo quá hạn (Overdue Task) bằng SqlDataReader
        public DataTable GetOverdueTasks()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT c.MaTask, c.TenTask, d.TenDuAn, c.HanNop, c.TrangThai 
                                FROM CongViec c 
                                JOIN DuAn d ON c.MaDuAn = d.MaDuAn 
                                WHERE c.HanNop < GETDATE() AND c.TrangThai != N'Done'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        // 5. Thống kê tỷ lệ % hoàn thành theo Thành viên (sử dụng GROUP BY)
        public DataTable GetMemberCompletionRate(int maDuAn)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT tv.HoTen, 
                                        COUNT(pc.MaTask) AS TongTask,
                                        SUM(CASE WHEN cv.TrangThai = N'Done' THEN 1 ELSE 0 END) AS TaskHoanThanh,
                                        ROUND(CAST(SUM(CASE WHEN cv.TrangThai = N'Done' THEN 1 ELSE 0 END) AS FLOAT) / COUNT(pc.MaTask) * 100, 2) AS TyLeHoanThanh
                                 FROM ThanhVien tv
                                 JOIN PhanCong pc ON tv.MaThanhVien = pc.MaThanhVien
                                 JOIN CongViec cv ON pc.MaTask = cv.MaTask
                                 WHERE (@MaDuAn = 0 OR cv.MaDuAn = @MaDuAn)
                                 GROUP BY tv.HoTen";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDuAn", maDuAn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Helper: Lấy danh sách Dự án để nạp vào ComboBox
        public DataTable GetAllProjects()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaDuAn, TenDuAn FROM DuAn", conn);
                da.Fill(dt);
            }
            return dt;
        }

        // Helper: Lấy danh sách Thành viên để nạp vào ComboBox
        public DataTable GetAllMembers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaThanhVien, HoTen FROM ThanhVien", conn);
                da.Fill(dt);
            }
            return dt;
        }
    }
}