using System.Collections.Generic;
using System.Data;
using BaiTap6_4.DAL;
using BaiTap6_4.DTO;

namespace BaiTap6_4.BUS
{
    public class GarageBUS
    {
        private GarageDAL garageDAL = new GarageDAL();

        // 1. Tra cứu thông tin xe & khách hàng theo Biển Số
        public DataTable GetXeByBienSo(string bienSo)
        {
            if (string.IsNullOrWhiteSpace(bienSo))
                return new DataTable();

            return garageDAL.GetXeByBienSo(bienSo.Trim());
        }

        // 2. Thêm Chủ xe mới & Đăng ký Xe mới
        public bool InsertKhachHangAndXe(KhachHangDTO khach, XeDTO xe)
        {
            if (string.IsNullOrWhiteSpace(xe.BienSo) || string.IsNullOrWhiteSpace(khach.TenKH))
                return false;

            return garageDAL.InsertKhachHangAndXe(khach, xe);
        }

        // 3. Lấy danh sách Phụ tùng
        public DataTable GetAllPhuTung()
        {
            return garageDAL.GetAllPhuTung();
        }

        // 4. Cập nhật Phụ tùng (Đơn giá, Tồn kho)
        public bool UpdatePhuTung(PhuTungDTO pt)
        {
            if (pt.MaPhuTung <= 0 || string.IsNullOrWhiteSpace(pt.TenPhuTung) || pt.SoLuongTon < 0)
                return false;

            return garageDAL.UpdatePhuTung(pt);
        }

        // 5. Lập Phiếu sửa chữa & Trừ kho (SqlTransaction)
        public bool TaoPhieuSuaChuaTransaction(PhieuSuaChuaDTO phieu, List<ChiTietSuaChuaDTO> listChiTiet, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(phieu.BienSo) || listChiTiet == null || listChiTiet.Count == 0)
            {
                errorMessage = "Thông tin phiếu hoặc danh sách phụ tùng không hợp lệ!";
                return false;
            }

            return garageDAL.TaoPhieuSuaChuaTransaction(phieu, listChiTiet, out errorMessage);
        }

        // 6. Lấy danh sách phiếu chưa thanh toán
        public DataTable GetPhieuSuaChuaChuaThanhToan()
        {
            return garageDAL.GetPhieuSuaChuaChuaThanhToan();
        }

        // 7. Thanh toán phiếu sửa chữa
        public bool ThanhToanPhieuSuaChua(int maPhieu)
        {
            if (maPhieu <= 0)
                return false;

            return garageDAL.ThanhToanPhieuSuaChua(maPhieu);
        }
    }
}