using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BaiTap6_4.BUS;
using BaiTap6_4.DTO;

namespace BaiTap6_4
{
    public partial class Form1 : Form
    {
        private GarageBUS garageBUS = new GarageBUS();
        private List<ChiTietSuaChuaTamDTO> listChiTietTam = new List<ChiTietSuaChuaTamDTO>();
        private int selectedMaPhuTung = 0;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGridPhuTung();
            LoadComboPhuTung();
            InitGridChiTietPhieu();
            LoadGridPhieuChuaThanhToan();
        }

        // =============================================
        // TAB 1: TIẾP NHẬN XE & PHỤ TÙNG
        // =============================================

        private void LoadGridPhuTung()
        {
            dgvPhuTung.DataSource = garageBUS.GetAllPhuTung();
        }

        private void LoadComboPhuTung()
        {
            DataTable dt = garageBUS.GetAllPhuTung();
            cboPhuTungChon.DataSource = dt;
            cboPhuTungChon.DisplayMember = "TenPhuTung";
            cboPhuTungChon.ValueMember = "MaPhuTung";
        }

        private void btnTimXe_Click(object sender, EventArgs e)
        {
            string bienSo = txtBienSo.Text.Trim();
            if (string.IsNullOrEmpty(bienSo))
            {
                MessageBox.Show("Vui lòng nhập Biển số xe để tra cứu!", "Cảnh báo");
                return;
            }

            DataTable dt = garageBUS.GetXeByBienSo(bienSo);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                txtHieuXe.Text = r["HieuXe"].ToString();
                txtNamSX.Text = r["NamSanXuat"].ToString();
                txtTenKH.Text = r["TenKH"].ToString();
                txtDienThoai.Text = r["DienThoai"].ToString();
                txtDiaChi.Text = r["DiaChi"].ToString();
                txtBienSoLapPhieu.Text = bienSo;
                MessageBox.Show("Tìm thấy thông tin xe và chủ xe!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xe mới chưa có trong hệ thống. Vui lòng nhập thông tin Chủ xe để đăng ký!", "Thông báo");
                txtHieuXe.Clear();
                txtNamSX.Clear();
                txtTenKH.Clear();
                txtDienThoai.Clear();
                txtDiaChi.Clear();
            }
        }

        private void btnDangKyXe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBienSo.Text) || string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Biển số xe và Tên chủ xe!", "Cảnh báo");
                return;
            }

            XeDTO xe = new XeDTO
            {
                BienSo = txtBienSo.Text.Trim(),
                HieuXe = txtHieuXe.Text.Trim(),
                NamSanXuat = int.TryParse(txtNamSX.Text, out int nsx) ? nsx : DateTime.Now.Year
            };

            KhachHangDTO khach = new KhachHangDTO
            {
                TenKH = txtTenKH.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            if (garageBUS.InsertKhachHangAndXe(khach, xe))
            {
                MessageBox.Show("Đăng ký Chủ xe & Xe mới thành công!", "Thông báo");
                txtBienSoLapPhieu.Text = xe.BienSo;
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Biển số hoặc Số điện thoại có thể đã tồn tại.", "Lỗi");
            }
        }

        private void dgvPhuTung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvPhuTung.Rows[e.RowIndex];
                selectedMaPhuTung = Convert.ToInt32(r.Cells["MaPhuTung"].Value);
                txtTenPhuTung.Text = r.Cells["TenPhuTung"].Value.ToString();
                txtDonGia.Text = r.Cells["DonGia"].Value.ToString();
                txtSoLuongTon.Text = r.Cells["SoLuongTon"].Value.ToString();
            }
        }

        private void btnCapNhatPhuTung_Click(object sender, EventArgs e)
        {
            if (selectedMaPhuTung <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 phụ tùng từ danh sách để cập nhật!", "Thông báo");
                return;
            }

            PhuTungDTO pt = new PhuTungDTO
            {
                MaPhuTung = selectedMaPhuTung,
                TenPhuTung = txtTenPhuTung.Text.Trim(),
                DonGia = decimal.TryParse(txtDonGia.Text, out decimal dg) ? dg : 0,
                SoLuongTon = int.TryParse(txtSoLuongTon.Text, out int sl) ? sl : 0
            };

            if (garageBUS.UpdatePhuTung(pt))
            {
                MessageBox.Show("Cập nhật thông tin phụ tùng thành công!", "Thông báo");
                LoadGridPhuTung();
                LoadComboPhuTung();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi");
            }
        }

        // =============================================
        // TAB 2: LẬP PHIẾU SỬA CHỮA (SqlTransaction)
        // =============================================

        private void InitGridChiTietPhieu()
        {
            dgvChiTietPhieu.DataSource = null;
        }

        private void btnThemPhuTungVaoPhieu_Click(object sender, EventArgs e)
        {
            if (cboPhuTungChon.SelectedValue == null) return;

            int maPT = Convert.ToInt32(cboPhuTungChon.SelectedValue);
            string tenPT = cboPhuTungChon.Text;
            int sl = int.TryParse(txtSoLuongMua.Text, out int s) ? s : 1;
            decimal tienCong = decimal.TryParse(txtTienCong.Text, out decimal tc) ? tc : 0;

            DataRowView rowView = cboPhuTungChon.SelectedItem as DataRowView;
            decimal donGia = rowView != null ? Convert.ToDecimal(rowView["DonGia"]) : 0;

            ChiTietSuaChuaTamDTO itemExisted = listChiTietTam.FirstOrDefault(x => x.MaPhuTung == maPT);
            if (itemExisted != null)
            {
                itemExisted.SoLuong += sl;
                itemExisted.TienCong += tienCong;
            }
            else
            {
                listChiTietTam.Add(new ChiTietSuaChuaTamDTO
                {
                    MaPhuTung = maPT,
                    TenPhuTung = tenPT,
                    DonGia = donGia,
                    SoLuong = sl,
                    TienCong = tienCong
                });
            }

            RefreshGridChiTietTam();
        }

        private void RefreshGridChiTietTam()
        {
            dgvChiTietPhieu.DataSource = null;
            dgvChiTietPhieu.DataSource = listChiTietTam;
            decimal tongTien = listChiTietTam.Sum(x => x.ThanhTien);
            lblTongTienTemp.Text = $"Tổng chi phí tính toán: {tongTien:N0} VNĐ";
        }

        private void btnXacNhanLapPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBienSoLapPhieu.Text))
            {
                MessageBox.Show("Vui lòng nhập Biển số xe cần lập phiếu!", "Cảnh báo");
                return;
            }

            if (listChiTietTam.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 phụ tùng/dịch vụ vào phiếu!", "Cảnh báo");
                return;
            }

            PhieuSuaChuaDTO phieu = new PhieuSuaChuaDTO
            {
                BienSo = txtBienSoLapPhieu.Text.Trim(),
                NoiDungSua = txtNoiDungSua.Text.Trim(),
                TongTien = listChiTietTam.Sum(x => x.ThanhTien)
            };

            List<ChiTietSuaChuaDTO> listReal = listChiTietTam.Select(x => new ChiTietSuaChuaDTO
            {
                MaPhuTung = x.MaPhuTung,
                SoLuong = x.SoLuong,
                TienCong = x.TienCong
            }).ToList();

            if (garageBUS.TaoPhieuSuaChuaTransaction(phieu, listReal, out string error))
            {
                MessageBox.Show("Lập phiếu sửa chữa thành công & Kho phụ tùng đã tự động trừ!", "Thông báo");
                listChiTietTam.Clear();
                RefreshGridChiTietTam();
                txtNoiDungSua.Clear();
                LoadGridPhuTung();
                LoadGridPhieuChuaThanhToan();
            }
            else
            {
                MessageBox.Show("Lập phiếu thất bại (SqlTransaction Rollback):\n" + error, "Lỗi Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================================
        // TAB 3: THANH TOÁN & HÓA ĐƠN
        // =============================================

        private void LoadGridPhieuChuaThanhToan()
        {
            dgvPhieuChuaThanhToan.DataSource = garageBUS.GetPhieuSuaChuaChuaThanhToan();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvPhieuChuaThanhToan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu sửa chữa để thanh toán!", "Thông báo");
                return;
            }

            int maPhieu = Convert.ToInt32(dgvPhieuChuaThanhToan.CurrentRow.Cells["MaPhieu"].Value);
            decimal tongTien = Convert.ToDecimal(dgvPhieuChuaThanhToan.CurrentRow.Cells["TongTien"].Value);

            if (garageBUS.ThanhToanPhieuSuaChua(maPhieu))
            {
                MessageBox.Show($"Thanh toán thành công phiếu sửa chữa #{maPhieu}!\nTổng tiền thu: {tongTien:N0} VNĐ", "Hóa Đơn Thanh Toán");
                LoadGridPhieuChuaThanhToan();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi");
            }
        }
    }

    // DTO phụ trợ hiển thị lưới lập phiếu tạm
    public class ChiTietSuaChuaTamDTO
    {
        public int MaPhuTung { get; set; }
        public string TenPhuTung { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal TienCong { get; set; }
        public decimal ThanhTien => (SoLuong * DonGia) + TienCong;
    }
}