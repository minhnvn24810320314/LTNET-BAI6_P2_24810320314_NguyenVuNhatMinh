using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BaiTap6_5.DTO;

namespace BaiTap6_5.DAL
{
    public class KaraokeDAL
    {
        // 1. Lấy danh sách toàn bộ Phòng hát (hiển thị button grid)
        public List<PhongHatDTO> GetAllPhongHat()
        {
            List<PhongHatDTO> list = new List<PhongHatDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaPhong, TenPhong, LoaiPhong, GiaTheoGio, TrangThai FROM PhongHat";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PhongHatDTO
                        {
                            MaPhong = Convert.ToInt32(reader["MaPhong"]),
                            TenPhong = reader["TenPhong"].ToString(),
                            LoaiPhong = reader["LoaiPhong"].ToString(),
                            GiaTheoGio = Convert.ToDecimal(reader["GiaTheoGio"]),
                            TrangThai = reader["TrangThai"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        // 2. Mở phòng hát (Tạo HoaDon mới + Đổi TrangThai phòng sang 'Đang hát')
        public bool MoPhongHat(int maPhong, out int maHDMoi)
        {
            maHDMoi = 0;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Tạo hóa đơn mới
                        string queryHD = @"INSERT INTO HoaDon (MaPhong, GioVao, TrangThai) 
                                           VALUES (@MaPhong, GETDATE(), 0);
                                           SELECT SCOPE_IDENTITY();";
                        SqlCommand cmdHD = new SqlCommand(queryHD, conn, trans);
                        cmdHD.Parameters.AddWithValue("@MaPhong", maPhong);
                        maHDMoi = Convert.ToInt32(cmdHD.ExecuteScalar());

                        // Cập nhật trạng thái phòng sang 'Đang hát'
                        string queryPhong = "UPDATE PhongHat SET TrangThai = N'Đang hát' WHERE MaPhong = @MaPhong";
                        SqlCommand cmdPhong = new SqlCommand(queryPhong, conn, trans);
                        cmdPhong.Parameters.AddWithValue("@MaPhong", maPhong);
                        cmdPhong.ExecuteNonQuery();

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

        // 3. Lấy Mã Hóa Đơn đang phục vụ của 1 Phòng
        public HoaDonDTO GetHoaDonDangHatByMaPhong(int maPhong)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaHD, MaPhong, GioVao, GioRa, TongTienPhong, TongTienDichVu, TrangThai " +
                               "FROM HoaDon WHERE MaPhong = @MaPhong AND TrangThai = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new HoaDonDTO
                        {
                            MaHD = Convert.ToInt32(reader["MaHD"]),
                            MaPhong = Convert.ToInt32(reader["MaPhong"]),
                            GioVao = Convert.ToDateTime(reader["GioVao"]),
                            GioRa = reader["GioRa"] != DBNull.Value ? (DateTime?)reader["GioRa"] : null,
                            TongTienPhong = Convert.ToDecimal(reader["TongTienPhong"]),
                            TongTienDichVu = Convert.ToDecimal(reader["TongTienDichVu"]),
                            TrangThai = Convert.ToBoolean(reader["TrangThai"])
                        };
                    }
                }
            }
            return null;
        }

        // 4. Lấy danh sách Dịch vụ (dùng cho ComboBox)
        public DataTable GetAllDichVu()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT MaDV, TenDV, DonGia, TonKho FROM DichVu";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // 5. Lấy Chi tiết Dịch vụ theo MaHD bằng SqlDataAdapter & DataTable (Disconnected Model)
        public DataTable GetChiTietDichVuByMaHD(int maHD)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT ct.MaHD, ct.MaDV, dv.TenDV, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
                                 FROM ChiTietDichVu ct
                                 JOIN DichVu dv ON ct.MaDV = dv.MaDV
                                 WHERE ct.MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // 6. Thêm/Cập nhật Dịch vụ vào Hóa đơn
        public bool ThemChiTietDichVu(int maHD, int maDV, int soLuong, decimal donGia)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // Kiểm tra xem đã có dịch vụ này trong hóa đơn chưa
                string checkQuery = "SELECT SoLuong FROM ChiTietDichVu WHERE MaHD = @MaHD AND MaDV = @MaDV";
                SqlCommand cmdCheck = new SqlCommand(checkQuery, conn);
                cmdCheck.Parameters.AddWithValue("@MaHD", maHD);
                cmdCheck.Parameters.AddWithValue("@MaDV", maDV);
                object result = cmdCheck.ExecuteScalar();

                if (result != null)
                {
                    // Đã có -> Cập nhật cộng dồn số lượng
                    string updateQuery = "UPDATE ChiTietDichVu SET SoLuong = SoLuong + @SoLuong WHERE MaHD = @MaHD AND MaDV = @MaDV";
                    SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn);
                    cmdUpdate.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdUpdate.Parameters.AddWithValue("@MaHD", maHD);
                    cmdUpdate.Parameters.AddWithValue("@MaDV", maDV);
                    return cmdUpdate.ExecuteNonQuery() > 0;
                }
                else
                {
                    // Chưa có -> Thêm mới
                    string insertQuery = "INSERT INTO ChiTietDichVu (MaHD, MaDV, SoLuong, DonGia) VALUES (@MaHD, @MaDV, @SoLuong, @DonGia)";
                    SqlCommand cmdInsert = new SqlCommand(insertQuery, conn);
                    cmdInsert.Parameters.AddWithValue("@MaHD", maHD);
                    cmdInsert.Parameters.AddWithValue("@MaDV", maDV);
                    cmdInsert.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdInsert.Parameters.AddWithValue("@DonGia", donGia);
                    return cmdInsert.ExecuteNonQuery() > 0;
                }
            }
        }

        // 7. Thanh toán Hóa đơn & Trừ kho (SqlTransaction)
        public bool ThanhToanHoaDonTransaction(int maHD, int maPhong, decimal tienPhong, decimal tienDV, out string error)
        {
            error = string.Empty;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiểm tra tồn kho trước khi trừ
                        string queryGetCT = "SELECT MaDV, SoLuong FROM ChiTietDichVu WHERE MaHD = @MaHD";
                        SqlCommand cmdGetCT = new SqlCommand(queryGetCT, conn, trans);
                        cmdGetCT.Parameters.AddWithValue("@MaHD", maHD);

                        List<KeyValuePair<int, int>> listDV = new List<KeyValuePair<int, int>>();
                        using (SqlDataReader reader = cmdGetCT.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listDV.Add(new KeyValuePair<int, int>(Convert.ToInt32(reader["MaDV"]), Convert.ToInt32(reader["SoLuong"])));
                            }
                        }

                        foreach (var item in listDV)
                        {
                            string checkTon = "SELECT TenDV, TonKho FROM DichVu WHERE MaDV = @MaDV";
                            SqlCommand cmdCheck = new SqlCommand(checkTon, conn, trans);
                            cmdCheck.Parameters.AddWithValue("@MaDV", item.Key);
                            using (SqlDataReader reader = cmdCheck.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int tonKho = Convert.ToInt32(reader["TonKho"]);
                                    string tenDV = reader["TenDV"].ToString();
                                    if (tonKho < item.Value)
                                    {
                                        reader.Close();
                                        trans.Rollback();
                                        error = $"Dịch vụ '{tenDV}' trong kho không đủ (Còn {tonKho}, gọi {item.Value})!";
                                        return false;
                                    }
                                }
                            }

                            // 2. Trừ tồn kho trong bảng DichVu
                            string updateKho = "UPDATE DichVu SET TonKho = TonKho - @SoLuong WHERE MaDV = @MaDV";
                            SqlCommand cmdKho = new SqlCommand(updateKho, conn, trans);
                            cmdKho.Parameters.AddWithValue("@SoLuong", item.Value);
                            cmdKho.Parameters.AddWithValue("@MaDV", item.Key);
                            cmdKho.ExecuteNonQuery();
                        }

                        // 3. Cập nhật Hóa đơn (GioRa, TongTienPhong, TongTienDichVu, TrangThai = 1)
                        string updateHD = @"UPDATE HoaDon 
                                            SET GioRa = GETDATE(), 
                                                TongTienPhong = @TongTienPhong, 
                                                TongTienDichVu = @TongTienDichVu, 
                                                TrangThai = 1 
                                            WHERE MaHD = @MaHD";
                        SqlCommand cmdHD = new SqlCommand(updateHD, conn, trans);
                        cmdHD.Parameters.AddWithValue("@TongTienPhong", tienPhong);
                        cmdHD.Parameters.AddWithValue("@TongTienDichVu", tienDV);
                        cmdHD.Parameters.AddWithValue("@MaHD", maHD);
                        cmdHD.ExecuteNonQuery();

                        // 4. Cập nhật trạng thái Phòng về 'Trống'
                        string updatePhong = "UPDATE PhongHat SET TrangThai = N'Trống' WHERE MaPhong = @MaPhong";
                        SqlCommand cmdPhong = new SqlCommand(updatePhong, conn, trans);
                        cmdPhong.Parameters.AddWithValue("@MaPhong", maPhong);
                        cmdPhong.ExecuteNonQuery();

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        error = "Lỗi giao dịch: " + ex.Message;
                        return false;
                    }
                }
            }
        }
    }
}