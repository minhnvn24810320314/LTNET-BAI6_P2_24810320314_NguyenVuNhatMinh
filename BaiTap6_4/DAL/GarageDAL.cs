using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BaiTap6_4.DTO;

namespace BaiTap6_4.DAL
{
    public class GarageDAL
    {
        // =============================================
        // 1. TIẾP NHẬN XE & KHÁCH HÀNG (SqlParameter)
        // =============================================

        // Tra cứu thông tin xe & khách hàng theo Biển Số
        public DataTable GetXeByBienSo(string bienSo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT x.BienSo, x.HieuXe, x.NamSanXuat, k.MaKH, k.TenKH, k.DienThoai, k.DiaChi 
                                FROM Xe x 
                                JOIN KhachHang k ON x.MaKH = k.MaKH 
                                WHERE x.BienSo = @BienSo";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BienSo", bienSo);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Thêm Chủ xe mới & Đăng ký Xe mới
        public bool InsertKhachHangAndXe(KhachHangDTO khach, XeDTO xe)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Thêm Khách hàng
                        string queryKH = @"INSERT INTO KhachHang (TenKH, DienThoai, DiaChi) 
                                           VALUES (@TenKH, @DienThoai, @DiaChi);
                                           SELECT SCOPE_IDENTITY();";
                        SqlCommand cmdKH = new SqlCommand(queryKH, conn, trans);
                        cmdKH.Parameters.AddWithValue("@TenKH", khach.TenKH);
                        cmdKH.Parameters.AddWithValue("@DienThoai", khach.DienThoai ?? (object)DBNull.Value);
                        cmdKH.Parameters.AddWithValue("@DiaChi", khach.DiaChi ?? (object)DBNull.Value);

                        int maKH = Convert.ToInt32(cmdKH.ExecuteScalar());

                        // Thêm Xe
                        string queryXe = @"INSERT INTO Xe (BienSo, MaKH, HieuXe, NamSanXuat) 
                                           VALUES (@BienSo, @MaKH, @HieuXe, @NamSanXuat)";
                        SqlCommand cmdXe = new SqlCommand(queryXe, conn, trans);
                        cmdXe.Parameters.AddWithValue("@BienSo", xe.BienSo);
                        cmdXe.Parameters.AddWithValue("@MaKH", maKH);
                        cmdXe.Parameters.AddWithValue("@HieuXe", xe.HieuXe);
                        cmdXe.Parameters.AddWithValue("@NamSanXuat", xe.NamSanXuat);
                        cmdXe.ExecuteNonQuery();

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

        // =============================================
        // 2. QUẢN LÝ PHỤ TÙNG
        // =============================================

        public DataTable GetAllPhuTung()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PhuTung", conn);
                da.Fill(dt);
            }
            return dt;
        }

        public bool UpdatePhuTung(PhuTungDTO pt)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE PhuTung 
                                SET TenPhuTung = @TenPhuTung, DonGia = @DonGia, SoLuongTon = @SoLuongTon 
                                WHERE MaPhuTung = @MaPhuTung";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenPhuTung", pt.TenPhuTung);
                    cmd.Parameters.AddWithValue("@DonGia", pt.DonGia);
                    cmd.Parameters.AddWithValue("@SoLuongTon", pt.SoLuongTon);
                    cmd.Parameters.AddWithValue("@MaPhuTung", pt.MaPhuTung);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // =============================================
        // 3. LẬP PHIẾU SỬA CHỮA & TRỪ KHO (SqlTransaction)
        // =============================================

        public bool TaoPhieuSuaChuaTransaction(PhieuSuaChuaDTO phieu, List<ChiTietSuaChuaDTO> listChiTiet, out string errorMessage)
        {
            errorMessage = string.Empty;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiểm tra tồn kho trước khi thực hiện
                        foreach (var item in listChiTiet)
                        {
                            string checkQuery = "SELECT TenPhuTung, SoLuongTon FROM PhuTung WHERE MaPhuTung = @MaPT";
                            SqlCommand cmdCheck = new SqlCommand(checkQuery, conn, trans);
                            cmdCheck.Parameters.AddWithValue("@MaPT", item.MaPhuTung);

                            using (SqlDataReader reader = cmdCheck.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int tonKho = Convert.ToInt32(reader["SoLuongTon"]);
                                    string tenPT = reader["TenPhuTung"].ToString();
                                    if (tonKho < item.SoLuong)
                                    {
                                        reader.Close();
                                        trans.Rollback();
                                        errorMessage = $"Phụ tùng '{tenPT}' không đủ tồn kho (Còn {tonKho}, yêu cầu {item.SoLuong})!";
                                        return false;
                                    }
                                }
                            }
                        }

                        // 2. Tạo bản ghi PhieuSuaChua
                        string queryPhieu = @"INSERT INTO PhieuSuaChua (BienSo, NoiDungSua, TongTien, TrangThai) 
                                              VALUES (@BienSo, @NoiDungSua, @TongTien, @TrangThai);
                                              SELECT SCOPE_IDENTITY();";
                        SqlCommand cmdPhieu = new SqlCommand(queryPhieu, conn, trans);
                        cmdPhieu.Parameters.AddWithValue("@BienSo", phieu.BienSo);
                        cmdPhieu.Parameters.AddWithValue("@NoiDungSua", phieu.NoiDungSua ?? (object)DBNull.Value);
                        cmdPhieu.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                        cmdPhieu.Parameters.AddWithValue("@TrangThai", "Đang sửa");

                        int maPhieuMoi = Convert.ToInt32(cmdPhieu.ExecuteScalar());

                        // 3. Tạo bản ghi ChiTietSuaChua & 4. Trừ số lượng kho phụ tùng
                        foreach (var item in listChiTiet)
                        {
                            // Thêm chi tiết phiếu
                            string queryCT = @"INSERT INTO ChiTietSuaChua (MaPhieu, MaPhuTung, SoLuong, TienCong) 
                                               VALUES (@MaPhieu, @MaPhuTung, @SoLuong, @TienCong)";
                            SqlCommand cmdCT = new SqlCommand(queryCT, conn, trans);
                            cmdCT.Parameters.AddWithValue("@MaPhieu", maPhieuMoi);
                            cmdCT.Parameters.AddWithValue("@MaPhuTung", item.MaPhuTung);
                            cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            cmdCT.Parameters.AddWithValue("@TienCong", item.TienCong);
                            cmdCT.ExecuteNonQuery();

                            // Trừ phụ tùng trong kho
                            string queryTruKho = @"UPDATE PhuTung 
                                                   SET SoLuongTon = SoLuongTon - @SoLuong 
                                                   WHERE MaPhuTung = @MaPhuTung";
                            SqlCommand cmdKho = new SqlCommand(queryTruKho, conn, trans);
                            cmdKho.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            cmdKho.Parameters.AddWithValue("@MaPhuTung", item.MaPhuTung);
                            cmdKho.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        errorMessage = "Lỗi hệ thống: " + ex.Message;
                        return false;
                    }
                }
            }
        }

        // =============================================
        // 4. THANH TOÁN & HÓA ĐƠN
        // =============================================

        public DataTable GetPhieuSuaChuaChuaThanhToan()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT p.MaPhieu, p.BienSo, x.HieuXe, k.TenKH, p.NgayNhan, p.NoiDungSua, p.TongTien, p.TrangThai 
                                FROM PhieuSuaChua p 
                                JOIN Xe x ON p.BienSo = x.BienSo 
                                JOIN KhachHang k ON x.MaKH = k.MaKH 
                                WHERE p.TrangThai != N'Đã thanh toán'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public bool ThanhToanPhieuSuaChua(int maPhieu)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE PhieuSuaChua SET TrangThai = N'Đã thanh toán' WHERE MaPhieu = @MaPhieu";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}