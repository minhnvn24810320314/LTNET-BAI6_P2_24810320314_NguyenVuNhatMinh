using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BaiTap6_5.BUS;
using BaiTap6_5.DTO;

namespace BaiTap6_5
{
    public partial class Form1 : Form
    {
        private KaraokeBUS bus = new KaraokeBUS();
        private PhongHatDTO phongDangChon = null;
        private HoaDonDTO hoaDonHienTai = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSodoPhong();
            LoadDanhSachDichVu();
        }

        // 1. Tạo Button Grid danh sách phòng hát động
        private void LoadSodoPhong()
        {
            flpDanhSachPhong.Controls.Clear();
            List<PhongHatDTO> listPhong = bus.GetAllPhongHat();

            foreach (var p in listPhong)
            {
                Button btn = new Button
                {
                    Width = 110,
                    Height = 90,
                    Tag = p,
                    Text = $"{p.TenPhong}\n({p.LoaiPhong})\n[{p.TrangThai}]",
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    Margin = new Padding(5)
                };

                // Đổi màu theo trạng thái phòng
                if (p.TrangThai == "Trống")
                {
                    btn.BackColor = Color.LightGreen;
                    btn.ForeColor = Color.DarkGreen;
                }
                else
                {
                    btn.BackColor = Color.LightCoral;
                    btn.ForeColor = Color.DarkRed;
                }

                btn.Click += BtnPhong_Click;
                flpDanhSachPhong.Controls.Add(btn);
            }
        }

        // 2. Sự kiện khi Click chọn 1 phòng trên Grid
        private void BtnPhong_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            phongDangChon = btn.Tag as PhongHatDTO;

            lblTenPhongChon.Text = phongDangChon.TenPhong + $" ({phongDangChon.LoaiPhong})";
            lblDonGiaPhong.Text = $"Giá/giờ: {phongDangChon.GiaTheoGio:N0} VNĐ";

            if (phongDangChon.TrangThai == "Đang hát")
            {
                btnMoPhong.Enabled = false;
                btnThemDV.Enabled = true;
                btnThanhToan.Enabled = true;

                // Lấy thông tin hóa đơn hiện tại
                hoaDonHienTai = bus.GetHoaDonDangHatByMaPhong(phongDangChon.MaPhong);
                if (hoaDonHienTai != null)
                {
                    lblGioVao.Text = $"Giờ vào: {hoaDonHienTai.GioVao:HH:mm - dd/MM/yyyy}";
                    LoadChiTietDichVu(hoaDonHienTai.MaHD);
                }
            }
            else
            {
                btnMoPhong.Enabled = true;
                btnThemDV.Enabled = false;
                btnThanhToan.Enabled = false;
                lblGioVao.Text = "Giờ vào: Chưa hát";
                hoaDonHienTai = null;
                dgvChiTietDichVu.DataSource = null;
                TinhTongTienTamTinh(0, 0);
            }
        }

        // 3. Load danh mục dịch vụ vào ComboBox
        private void LoadDanhSachDichVu()
        {
            DataTable dt = bus.GetAllDichVu();
            cboDichVu.DataSource = dt;
            cboDichVu.DisplayMember = "TenDV";
            cboDichVu.ValueMember = "MaDV";
        }

        // 4. Load chi tiết dịch vụ của phòng hát (Disconnected Model)
        private void LoadChiTietDichVu(int maHD)
        {
            DataTable dt = bus.GetChiTietDichVuByMaHD(maHD);
            dgvChiTietDichVu.DataSource = dt;

            // Đổi tên cột DataGridView cho đẹp
            if (dgvChiTietDichVu.Columns["MaHD"] != null) dgvChiTietDichVu.Columns["MaHD"].Visible = false;
            if (dgvChiTietDichVu.Columns["MaDV"] != null) dgvChiTietDichVu.Columns["MaDV"].Visible = false;
            if (dgvChiTietDichVu.Columns["TenDV"] != null) dgvChiTietDichVu.Columns["TenDV"].HeaderText = "Tên Dịch Vụ";
            if (dgvChiTietDichVu.Columns["SoLuong"] != null) dgvChiTietDichVu.Columns["SoLuong"].HeaderText = "Số Lượng";
            if (dgvChiTietDichVu.Columns["DonGia"] != null) dgvChiTietDichVu.Columns["DonGia"].HeaderText = "Đơn Giá";
            if (dgvChiTietDichVu.Columns["ThanhTien"] != null) dgvChiTietDichVu.Columns["ThanhTien"].HeaderText = "Thành Tiền";

            // Tính tổng tiền dịch vụ
            decimal tongDV = 0;
            foreach (DataRow row in dt.Rows)
            {
                tongDV += Convert.ToDecimal(row["ThanhTien"]);
            }

            // Tính tiền phòng tạm tính đến hiện tại
            decimal tienPhong = 0;
            if (hoaDonHienTai != null)
            {
                tienPhong = bus.TinhTienPhong(hoaDonHienTai.GioVao, DateTime.Now, phongDangChon.GiaTheoGio);
            }

            TinhTongTienTamTinh(tienPhong, tongDV);
        }

        private void TinhTongTienTamTinh(decimal tienPhong, decimal tienDV)
        {
            lblTongTienPhong.Text = $"Tiền giờ hát: {tienPhong:N0} VNĐ";
            lblTongTienDV.Text = $"Tiền dịch vụ: {tienDV:N0} VNĐ";
            lblTongThanhToan.Text = $"TỔNG THANH TOÁN: {(tienPhong + tienDV):N0} VNĐ";
        }

        // 5. Nút Mở phòng
        private void btnMoPhong_Click(object sender, EventArgs e)
        {
            if (phongDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn 1 phòng trống từ sơ đồ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bus.MoPhongHat(phongDangChon.MaPhong, out int maHDMoi))
            {
                MessageBox.Show($"Mở phòng '{phongDangChon.TenPhong}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSodoPhong();
                // Reset giao diện
                phongDangChon = null;
                lblTenPhongChon.Text = "Chưa chọn phòng";
                lblGioVao.Text = "Giờ vào: Chưa hát";
            }
            else
            {
                MessageBox.Show("Mở phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 6. Nút Thêm Dịch vụ
        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (hoaDonHienTai == null)
            {
                MessageBox.Show("Vui lòng chọn phòng đang hát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDV = Convert.ToInt32(cboDichVu.SelectedValue);
            int soLuong = Convert.ToInt32(numSoLuong.Value);

            // Lấy đơn giá dịch vụ
            DataRowView rowSelected = cboDichVu.SelectedItem as DataRowView;
            decimal donGia = Convert.ToDecimal(rowSelected["DonGia"]);

            if (bus.ThemChiTietDichVu(hoaDonHienTai.MaHD, maDV, soLuong, donGia))
            {
                LoadChiTietDichVu(hoaDonHienTai.MaHD);
            }
            else
            {
                MessageBox.Show("Không thể thêm dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 7. Nút Thanh toán (SqlTransaction)
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (hoaDonHienTai == null || phongDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn phòng đang hát để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime gioRa = DateTime.Now;
            decimal tienPhong = bus.TinhTienPhong(hoaDonHienTai.GioVao, gioRa, phongDangChon.GiaTheoGio);

            // Lấy tổng tiền dịch vụ hiện tại
            DataTable dtDV = bus.GetChiTietDichVuByMaHD(hoaDonHienTai.MaHD);
            decimal tienDV = 0;
            foreach (DataRow row in dtDV.Rows)
            {
                tienDV += Convert.ToDecimal(row["ThanhTien"]);
            }

            decimal tongThanhToan = tienPhong + tienDV;

            DialogResult dr = MessageBox.Show(
                $"Xác nhận thanh toán cho '{phongDangChon.TenPhong}'?\n\n" +
                $"- Giờ vào: {hoaDonHienTai.GioVao:HH:mm:ss}\n" +
                $"- Giờ ra: {gioRa:HH:mm:ss}\n" +
                $"- Tiền phòng: {tienPhong:N0} VNĐ\n" +
                $"- Tiền dịch vụ: {tienDV:N0} VNĐ\n" +
                $"-----------------------------------\n" +
                $"TỔNG THU: {tongThanhToan:N0} VNĐ",
                "Xác nhận Thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (bus.ThanhToanHoaDonTransaction(hoaDonHienTai.MaHD, phongDangChon.MaPhong, tienPhong, tienDV, out string error))
                {
                    MessageBox.Show($"Thanh toán thành công Hóa đơn #{hoaDonHienTai.MaHD}!\nTổng tiền đã thu: {tongThanhToan:N0} VNĐ.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSodoPhong();
                    // Clear thông tin
                    phongDangChon = null;
                    hoaDonHienTai = null;
                    lblTenPhongChon.Text = "Chưa chọn phòng";
                    lblGioVao.Text = "Giờ vào: Chưa hát";
                    dgvChiTietDichVu.DataSource = null;
                    TinhTongTienTamTinh(0, 0);
                }
                else
                {
                    MessageBox.Show($"Lỗi SqlTransaction: {error}", "Thanh toán thất bại (Rollback)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}