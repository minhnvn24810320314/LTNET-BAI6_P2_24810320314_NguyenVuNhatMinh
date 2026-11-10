using System;
using System.Collections.Generic;
using System.Data;
using BaiTap6_5.DAL;
using BaiTap6_5.DTO;

namespace BaiTap6_5.BUS
{
    public class KaraokeBUS
    {
        private KaraokeDAL dal = new KaraokeDAL();

        // 1. Lấy danh sách toàn bộ phòng hát
        public List<PhongHatDTO> GetAllPhongHat()
        {
            return dal.GetAllPhongHat();
        }

        // 2. Mở phòng hát
        public bool MoPhongHat(int maPhong, out int maHDMoi)
        {
            return dal.MoPhongHat(maPhong, out maHDMoi);
        }

        // 3. Lấy thông tin hóa đơn đang hát của phòng
        public HoaDonDTO GetHoaDonDangHatByMaPhong(int maPhong)
        {
            return dal.GetHoaDonDangHatByMaPhong(maPhong);
        }

        // 4. Lấy danh mục Dịch vụ
        public DataTable GetAllDichVu()
        {
            return dal.GetAllDichVu();
        }

        // 5. Lấy danh sách chi tiết dịch vụ gọi của Hóa đơn (Disconnected Model)
        public DataTable GetChiTietDichVuByMaHD(int maHD)
        {
            return dal.GetChiTietDichVuByMaHD(maHD);
        }

        // 6. Thêm dịch vụ vào hóa đơn
        public bool ThemChiTietDichVu(int maHD, int maDV, int soLuong, decimal donGia)
        {
            if (soLuong <= 0) return false;
            return dal.ThemChiTietDichVu(maHD, maDV, soLuong, donGia);
        }

        // 7. Tính tiền phòng dựa trên số giờ đã hát (đơn vị giờ, làm tròn hoặc lẻ theo phút)
        public decimal TinhTienPhong(DateTime gioVao, DateTime gioRa, decimal giaTheoGio)
        {
            TimeSpan duration = gioRa - gioVao;
            double tongSoGio = duration.TotalHours;

            // Tính chính xác theo số giờ (ví dụ: 1 giờ 30 phút = 1.5 giờ)
            // Nếu thời gian hát < 15 phút, tính tối thiểu 0.25 giờ (15 phút)
            if (tongSoGio < 0.25)
            {
                tongSoGio = 0.25;
            }

            return (decimal)tongSoGio * giaTheoGio;
        }

        // 8. Thực hiện Thanh toán Hóa đơn & Trừ kho bằng SqlTransaction
        public bool ThanhToanHoaDonTransaction(int maHD, int maPhong, decimal tienPhong, decimal tienDV, out string error)
        {
            return dal.ThanhToanHoaDonTransaction(maHD, maPhong, tienPhong, tienDV, out error);
        }
    }
}