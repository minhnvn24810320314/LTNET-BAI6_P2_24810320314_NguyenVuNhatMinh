namespace BaiTap6_4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabTiepNhan = new System.Windows.Forms.TabPage();
            this.grpQuanLyPhuTung = new System.Windows.Forms.GroupBox();
            this.btnCapNhatPhuTung = new System.Windows.Forms.Button();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtTenPhuTung = new System.Windows.Forms.TextBox();
            this.lblTenPhuTung = new System.Windows.Forms.Label();
            this.dgvPhuTung = new System.Windows.Forms.DataGridView();
            this.grpTiepNhanXe = new System.Windows.Forms.GroupBox();
            this.btnDangKyXe = new System.Windows.Forms.Button();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtNamSX = new System.Windows.Forms.TextBox();
            this.lblNamSX = new System.Windows.Forms.Label();
            this.txtHieuXe = new System.Windows.Forms.TextBox();
            this.lblHieuXe = new System.Windows.Forms.Label();
            this.btnTimXe = new System.Windows.Forms.Button();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.lblBienSo = new System.Windows.Forms.Label();
            this.tabLapPhieu = new System.Windows.Forms.TabPage();
            this.btnXacNhanLapPhieu = new System.Windows.Forms.Button();
            this.lblTongTienTemp = new System.Windows.Forms.Label();
            this.dgvChiTietPhieu = new System.Windows.Forms.DataGridView();
            this.grpThemPhuTungChon = new System.Windows.Forms.GroupBox();
            this.btnThemPhuTungVaoPhieu = new System.Windows.Forms.Button();
            this.txtTienCong = new System.Windows.Forms.TextBox();
            this.lblTienCong = new System.Windows.Forms.Label();
            this.txtSoLuongMua = new System.Windows.Forms.TextBox();
            this.lblSoLuongMua = new System.Windows.Forms.Label();
            this.cboPhuTungChon = new System.Windows.Forms.ComboBox();
            this.lblPhuTungChon = new System.Windows.Forms.Label();
            this.grpThongTinPhieu = new System.Windows.Forms.GroupBox();
            this.txtNoiDungSua = new System.Windows.Forms.TextBox();
            this.lblNoiDungSua = new System.Windows.Forms.Label();
            this.txtBienSoLapPhieu = new System.Windows.Forms.TextBox();
            this.lblBienSoLapPhieu = new System.Windows.Forms.Label();
            this.tabThanhToan = new System.Windows.Forms.TabPage();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.dgvPhieuChuaThanhToan = new System.Windows.Forms.DataGridView();
            this.tabControlMain.SuspendLayout();
            this.tabTiepNhan.SuspendLayout();
            this.grpQuanLyPhuTung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuTung)).BeginInit();
            this.grpTiepNhanXe.SuspendLayout();
            this.tabLapPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).BeginInit();
            this.grpThemPhuTungChon.SuspendLayout();
            this.grpThongTinPhieu.SuspendLayout();
            this.tabThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChuaThanhToan)).BeginInit();
            this.SuspendLayout();

            // tabControlMain
            this.tabControlMain.Controls.Add(this.tabTiepNhan);
            this.tabControlMain.Controls.Add(this.tabLapPhieu);
            this.tabControlMain.Controls.Add(this.tabThanhToan);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(984, 611);
            this.tabControlMain.TabIndex = 0;

            // tabTiepNhan
            this.tabTiepNhan.Controls.Add(this.grpQuanLyPhuTung);
            this.tabTiepNhan.Controls.Add(this.grpTiepNhanXe);
            this.tabTiepNhan.Location = new System.Drawing.Point(4, 24);
            this.tabTiepNhan.Name = "tabTiepNhan";
            this.tabTiepNhan.Padding = new System.Windows.Forms.Padding(3);
            this.tabTiepNhan.Size = new System.Drawing.Size(976, 583);
            this.tabTiepNhan.TabIndex = 0;
            this.tabTiepNhan.Text = "1. Tiếp nhận Xe & Quản lý Phụ tùng";
            this.tabTiepNhan.UseVisualStyleBackColor = true;

            // grpTiepNhanXe
            this.grpTiepNhanXe.Controls.Add(this.btnDangKyXe);
            this.grpTiepNhanXe.Controls.Add(this.txtDiaChi);
            this.grpTiepNhanXe.Controls.Add(this.lblDiaChi);
            this.grpTiepNhanXe.Controls.Add(this.txtDienThoai);
            this.grpTiepNhanXe.Controls.Add(this.lblDienThoai);
            this.grpTiepNhanXe.Controls.Add(this.txtTenKH);
            this.grpTiepNhanXe.Controls.Add(this.lblTenKH);
            this.grpTiepNhanXe.Controls.Add(this.txtNamSX);
            this.grpTiepNhanXe.Controls.Add(this.lblNamSX);
            this.grpTiepNhanXe.Controls.Add(this.txtHieuXe);
            this.grpTiepNhanXe.Controls.Add(this.lblHieuXe);
            this.grpTiepNhanXe.Controls.Add(this.btnTimXe);
            this.grpTiepNhanXe.Controls.Add(this.txtBienSo);
            this.grpTiepNhanXe.Controls.Add(this.lblBienSo);
            this.grpTiepNhanXe.Location = new System.Drawing.Point(12, 12);
            this.grpTiepNhanXe.Name = "grpTiepNhanXe";
            this.grpTiepNhanXe.Size = new System.Drawing.Size(952, 175);
            this.grpTiepNhanXe.TabIndex = 0;
            this.grpTiepNhanXe.TabStop = false;
            this.grpTiepNhanXe.Text = "Tra cứu & Đăng ký Tiếp nhận Xe (SqlParameter)";

            // Control chi tiết trong grpTiepNhanXe
            this.lblBienSo.AutoSize = true;
            this.lblBienSo.Location = new System.Drawing.Point(15, 30);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size = new System.Drawing.Size(48, 15);
            this.lblBienSo.Text = "Biển số:";

            this.txtBienSo.Location = new System.Drawing.Point(80, 27);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(150, 23);
            this.txtBienSo.TabIndex = 1;

            this.btnTimXe.Location = new System.Drawing.Point(240, 25);
            this.btnTimXe.Name = "btnTimXe";
            this.btnTimXe.Size = new System.Drawing.Size(120, 25);
            this.btnTimXe.TabIndex = 2;
            this.btnTimXe.Text = "Tra cứu Biển số";
            this.btnTimXe.UseVisualStyleBackColor = true;
            this.btnTimXe.Click += new System.EventHandler(this.btnTimXe_Click);

            this.lblHieuXe.AutoSize = true;
            this.lblHieuXe.Location = new System.Drawing.Point(400, 30);
            this.lblHieuXe.Name = "lblHieuXe";
            this.lblHieuXe.Size = new System.Drawing.Size(50, 15);
            this.lblHieuXe.Text = "Hiệu xe:";

            this.txtHieuXe.Location = new System.Drawing.Point(460, 27);
            this.txtHieuXe.Name = "txtHieuXe";
            this.txtHieuXe.Size = new System.Drawing.Size(160, 23);
            this.txtHieuXe.TabIndex = 3;

            this.lblNamSX.AutoSize = true;
            this.lblNamSX.Location = new System.Drawing.Point(650, 30);
            this.lblNamSX.Name = "lblNamSX";
            this.lblNamSX.Size = new System.Drawing.Size(53, 15);
            this.lblNamSX.Text = "Năm SX:";

            this.txtNamSX.Location = new System.Drawing.Point(715, 27);
            this.txtNamSX.Name = "txtNamSX";
            this.txtNamSX.Size = new System.Drawing.Size(100, 23);
            this.txtNamSX.TabIndex = 4;

            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(15, 75);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(51, 15);
            this.lblTenKH.Text = "Chủ xe:";

            this.txtTenKH.Location = new System.Drawing.Point(80, 72);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(280, 23);
            this.txtTenKH.TabIndex = 5;

            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(400, 75);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(64, 15);
            this.lblDienThoai.Text = "Điện thoại:";

            this.txtDienThoai.Location = new System.Drawing.Point(460, 72);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(160, 23);
            this.txtDienThoai.TabIndex = 6;

            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 120);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(46, 15);
            this.lblDiaChi.Text = "Địa chỉ:";

            this.txtDiaChi.Location = new System.Drawing.Point(80, 117);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(540, 23);
            this.txtDiaChi.TabIndex = 7;

            this.btnDangKyXe.Location = new System.Drawing.Point(650, 115);
            this.btnDangKyXe.Name = "btnDangKyXe";
            this.btnDangKyXe.Size = new System.Drawing.Size(280, 30);
            this.btnDangKyXe.TabIndex = 8;
            this.btnDangKyXe.Text = "Đăng ký Xe & Chủ xe mới";
            this.btnDangKyXe.UseVisualStyleBackColor = true;
            this.btnDangKyXe.Click += new System.EventHandler(this.btnDangKyXe_Click);

            // grpQuanLyPhuTung
            this.grpQuanLyPhuTung.Controls.Add(this.btnCapNhatPhuTung);
            this.grpQuanLyPhuTung.Controls.Add(this.txtSoLuongTon);
            this.grpQuanLyPhuTung.Controls.Add(this.lblSoLuongTon);
            this.grpQuanLyPhuTung.Controls.Add(this.txtDonGia);
            this.grpQuanLyPhuTung.Controls.Add(this.lblDonGia);
            this.grpQuanLyPhuTung.Controls.Add(this.txtTenPhuTung);
            this.grpQuanLyPhuTung.Controls.Add(this.lblTenPhuTung);
            this.grpQuanLyPhuTung.Controls.Add(this.dgvPhuTung);
            this.grpQuanLyPhuTung.Location = new System.Drawing.Point(12, 195);
            this.grpQuanLyPhuTung.Name = "grpQuanLyPhuTung";
            this.grpQuanLyPhuTung.Size = new System.Drawing.Size(952, 375);
            this.grpQuanLyPhuTung.TabIndex = 1;
            this.grpQuanLyPhuTung.TabStop = false;
            this.grpQuanLyPhuTung.Text = "Danh mục Phụ tùng & Tồn kho";

            this.lblTenPhuTung.AutoSize = true;
            this.lblTenPhuTung.Location = new System.Drawing.Point(15, 30);
            this.lblTenPhuTung.Name = "lblTenPhuTung";
            this.lblTenPhuTung.Size = new System.Drawing.Size(78, 15);
            this.lblTenPhuTung.Text = "Tên phụ tùng:";

            this.txtTenPhuTung.Location = new System.Drawing.Point(95, 27);
            this.txtTenPhuTung.Name = "txtTenPhuTung";
            this.txtTenPhuTung.Size = new System.Drawing.Size(200, 23);
            this.txtTenPhuTung.TabIndex = 0;

            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(320, 30);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(51, 15);
            this.lblDonGia.Text = "Đơn giá:";

            this.txtDonGia.Location = new System.Drawing.Point(375, 27);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(120, 23);
            this.txtDonGia.TabIndex = 1;

            this.lblSoLuongTon.AutoSize = true;
            this.lblSoLuongTon.Location = new System.Drawing.Point(520, 30);
            this.lblSoLuongTon.Name = "lblSoLuongTon";
            this.lblSoLuongTon.Size = new System.Drawing.Size(77, 15);
            this.lblSoLuongTon.Text = "Số lượng tồn:";

            this.txtSoLuongTon.Location = new System.Drawing.Point(600, 27);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(100, 23);
            this.txtSoLuongTon.TabIndex = 2;

            this.btnCapNhatPhuTung.Location = new System.Drawing.Point(720, 24);
            this.btnCapNhatPhuTung.Name = "btnCapNhatPhuTung";
            this.btnCapNhatPhuTung.Size = new System.Drawing.Size(210, 28);
            this.btnCapNhatPhuTung.TabIndex = 3;
            this.btnCapNhatPhuTung.Text = "Cập nhật Giá / Kho Phụ tùng";
            this.btnCapNhatPhuTung.UseVisualStyleBackColor = true;
            this.btnCapNhatPhuTung.Click += new System.EventHandler(this.btnCapNhatPhuTung_Click);

            this.dgvPhuTung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhuTung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhuTung.Location = new System.Drawing.Point(15, 65);
            this.dgvPhuTung.MultiSelect = false;
            this.dgvPhuTung.Name = "dgvPhuTung";
            this.dgvPhuTung.ReadOnly = true;
            this.dgvPhuTung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhuTung.Size = new System.Drawing.Size(915, 295);
            this.dgvPhuTung.TabIndex = 4;
            this.dgvPhuTung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhuTung_CellClick);

            // tabLapPhieu
            this.tabLapPhieu.Controls.Add(this.btnXacNhanLapPhieu);
            this.tabLapPhieu.Controls.Add(this.lblTongTienTemp);
            this.tabLapPhieu.Controls.Add(this.dgvChiTietPhieu);
            this.tabLapPhieu.Controls.Add(this.grpThemPhuTungChon);
            this.tabLapPhieu.Controls.Add(this.grpThongTinPhieu);
            this.tabLapPhieu.Location = new System.Drawing.Point(4, 24);
            this.tabLapPhieu.Name = "tabLapPhieu";
            this.tabLapPhieu.Padding = new System.Windows.Forms.Padding(3);
            this.tabLapPhieu.Size = new System.Drawing.Size(976, 583);
            this.tabLapPhieu.TabIndex = 1;
            this.tabLapPhieu.Text = "2. Lập Phiếu Sửa chữa & Trừ kho (SqlTransaction)";
            this.tabLapPhieu.UseVisualStyleBackColor = true;

            // grpThongTinPhieu
            this.grpThongTinPhieu.Controls.Add(this.txtNoiDungSua);
            this.grpThongTinPhieu.Controls.Add(this.lblNoiDungSua);
            this.grpThongTinPhieu.Controls.Add(this.txtBienSoLapPhieu);
            this.grpThongTinPhieu.Controls.Add(this.lblBienSoLapPhieu);
            this.grpThongTinPhieu.Location = new System.Drawing.Point(12, 12);
            this.grpThongTinPhieu.Name = "grpThongTinPhieu";
            this.grpThongTinPhieu.Size = new System.Drawing.Size(952, 70);
            this.grpThongTinPhieu.TabIndex = 0;
            this.grpThongTinPhieu.TabStop = false;
            this.grpThongTinPhieu.Text = "Thông tin Phiếu sửa chữa";

            this.lblBienSoLapPhieu.AutoSize = true;
            this.lblBienSoLapPhieu.Location = new System.Drawing.Point(15, 30);
            this.lblBienSoLapPhieu.Name = "lblBienSoLapPhieu";
            this.lblBienSoLapPhieu.Size = new System.Drawing.Size(48, 15);
            this.lblBienSoLapPhieu.Text = "Biển số:";

            this.txtBienSoLapPhieu.Location = new System.Drawing.Point(80, 27);
            this.txtBienSoLapPhieu.Name = "txtBienSoLapPhieu";
            this.txtBienSoLapPhieu.Size = new System.Drawing.Size(150, 23);
            this.txtBienSoLapPhieu.TabIndex = 1;

            this.lblNoiDungSua.AutoSize = true;
            this.lblNoiDungSua.Location = new System.Drawing.Point(260, 30);
            this.lblNoiDungSua.Name = "lblNoiDungSua";
            this.lblNoiDungSua.Size = new System.Drawing.Size(81, 15);
            this.lblNoiDungSua.Text = "Nội dung sửa:";

            this.txtNoiDungSua.Location = new System.Drawing.Point(345, 27);
            this.txtNoiDungSua.Name = "txtNoiDungSua";
            this.txtNoiDungSua.Size = new System.Drawing.Size(585, 23);
            this.txtNoiDungSua.TabIndex = 2;

            // grpThemPhuTungChon
            this.grpThemPhuTungChon.Controls.Add(this.btnThemPhuTungVaoPhieu);
            this.grpThemPhuTungChon.Controls.Add(this.txtTienCong);
            this.grpThemPhuTungChon.Controls.Add(this.lblTienCong);
            this.grpThemPhuTungChon.Controls.Add(this.txtSoLuongMua);
            this.grpThemPhuTungChon.Controls.Add(this.lblSoLuongMua);
            this.grpThemPhuTungChon.Controls.Add(this.cboPhuTungChon);
            this.grpThemPhuTungChon.Controls.Add(this.lblPhuTungChon);
            this.grpThemPhuTungChon.Location = new System.Drawing.Point(12, 90);
            this.grpThemPhuTungChon.Name = "grpThemPhuTungChon";
            this.grpThemPhuTungChon.Size = new System.Drawing.Size(952, 70);
            this.grpThemPhuTungChon.TabIndex = 1;
            this.grpThemPhuTungChon.TabStop = false;
            this.grpThemPhuTungChon.Text = "Thêm Dịch vụ / Phụ tùng vào danh sách";

            this.lblPhuTungChon.AutoSize = true;
            this.lblPhuTungChon.Location = new System.Drawing.Point(15, 30);
            this.lblPhuTungChon.Name = "lblPhuTungChon";
            this.lblPhuTungChon.Size = new System.Drawing.Size(89, 15);
            this.lblPhuTungChon.Text = "Chọn phụ tùng:";

            this.cboPhuTungChon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuTungChon.FormattingEnabled = true;
            this.cboPhuTungChon.Location = new System.Drawing.Point(110, 27);
            this.cboPhuTungChon.Name = "cboPhuTungChon";
            this.cboPhuTungChon.Size = new System.Drawing.Size(220, 23);
            this.cboPhuTungChon.TabIndex = 1;

            this.lblSoLuongMua.AutoSize = true;
            this.lblSoLuongMua.Location = new System.Drawing.Point(350, 30);
            this.lblSoLuongMua.Name = "lblSoLuongMua";
            this.lblSoLuongMua.Size = new System.Drawing.Size(57, 15);
            this.lblSoLuongMua.Text = "Số lượng:";

            this.txtSoLuongMua.Location = new System.Drawing.Point(415, 27);
            this.txtSoLuongMua.Name = "txtSoLuongMua";
            this.txtSoLuongMua.Size = new System.Drawing.Size(80, 23);
            this.txtSoLuongMua.TabIndex = 2;
            this.txtSoLuongMua.Text = "1";

            this.lblTienCong.AutoSize = true;
            this.lblTienCong.Location = new System.Drawing.Point(520, 30);
            this.lblTienCong.Name = "lblTienCong";
            this.lblTienCong.Size = new System.Drawing.Size(62, 15);
            this.lblTienCong.Text = "Tiền công:";

            this.txtTienCong.Location = new System.Drawing.Point(590, 27);
            this.txtTienCong.Name = "txtTienCong";
            this.txtTienCong.Size = new System.Drawing.Size(120, 23);
            this.txtTienCong.TabIndex = 3;
            this.txtTienCong.Text = "50000";

            this.btnThemPhuTungVaoPhieu.Location = new System.Drawing.Point(730, 24);
            this.btnThemPhuTungVaoPhieu.Name = "btnThemPhuTungVaoPhieu";
            this.btnThemPhuTungVaoPhieu.Size = new System.Drawing.Size(200, 28);
            this.btnThemPhuTungVaoPhieu.TabIndex = 4;
            this.btnThemPhuTungVaoPhieu.Text = "Thêm vào Danh sách phiếu";
            this.btnThemPhuTungVaoPhieu.UseVisualStyleBackColor = true;
            this.btnThemPhuTungVaoPhieu.Click += new System.EventHandler(this.btnThemPhuTungVaoPhieu_Click);

            // dgvChiTietPhieu
            this.dgvChiTietPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieu.Location = new System.Drawing.Point(12, 170);
            this.dgvChiTietPhieu.Name = "dgvChiTietPhieu";
            this.dgvChiTietPhieu.ReadOnly = true;
            this.dgvChiTietPhieu.Size = new System.Drawing.Size(952, 350);
            this.dgvChiTietPhieu.TabIndex = 2;

            // lblTongTienTemp
            this.lblTongTienTemp.AutoSize = true;
            this.lblTongTienTemp.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTienTemp.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongTienTemp.Location = new System.Drawing.Point(12, 535);
            this.lblTongTienTemp.Name = "lblTongTienTemp";
            this.lblTongTienTemp.Size = new System.Drawing.Size(171, 20);
            this.lblTongTienTemp.Text = "Tổng chi phí tính toán: 0 VNĐ";

            // btnXacNhanLapPhieu
            this.btnXacNhanLapPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXacNhanLapPhieu.Location = new System.Drawing.Point(664, 530);
            this.btnXacNhanLapPhieu.Name = "btnXacNhanLapPhieu";
            this.btnXacNhanLapPhieu.Size = new System.Drawing.Size(300, 35);
            this.btnXacNhanLapPhieu.TabIndex = 3;
            this.btnXacNhanLapPhieu.Text = "XÁC NHẬN LẬP PHIẾU (SqlTransaction)";
            this.btnXacNhanLapPhieu.UseVisualStyleBackColor = true;
            this.btnXacNhanLapPhieu.Click += new System.EventHandler(this.btnXacNhanLapPhieu_Click);

            // tabThanhToan
            this.tabThanhToan.Controls.Add(this.btnThanhToan);
            this.tabThanhToan.Controls.Add(this.dgvPhieuChuaThanhToan);
            this.tabThanhToan.Location = new System.Drawing.Point(4, 24);
            this.tabThanhToan.Name = "tabThanhToan";
            this.tabThanhToan.Padding = new System.Windows.Forms.Padding(3);
            this.tabThanhToan.Size = new System.Drawing.Size(976, 583);
            this.tabThanhToan.TabIndex = 2;
            this.tabThanhToan.Text = "3. Thanh toán & Xuất Hóa đơn";
            this.tabThanhToan.UseVisualStyleBackColor = true;

            // dgvPhieuChuaThanhToan
            this.dgvPhieuChuaThanhToan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuChuaThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuChuaThanhToan.Location = new System.Drawing.Point(12, 12);
            this.dgvPhieuChuaThanhToan.MultiSelect = false;
            this.dgvPhieuChuaThanhToan.Name = "dgvPhieuChuaThanhToan";
            this.dgvPhieuChuaThanhToan.ReadOnly = true;
            this.dgvPhieuChuaThanhToan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuChuaThanhToan.Size = new System.Drawing.Size(952, 500);
            this.dgvPhieuChuaThanhToan.TabIndex = 0;

            // btnThanhToan
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.Location = new System.Drawing.Point(664, 525);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(300, 40);
            this.btnThanhToan.TabIndex = 1;
            this.btnThanhToan.Text = "THANH TOÁN & XUẤT HÓA ĐƠN";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 6.4 - Hệ thống Quản lý Garage & Bảo dưỡng Xe Ô tô (GarageDB)";
            this.tabControlMain.ResumeLayout(false);
            this.tabTiepNhan.ResumeLayout(false);
            this.grpQuanLyPhuTung.ResumeLayout(false);
            this.grpQuanLyPhuTung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuTung)).EndInit();
            this.grpTiepNhanXe.ResumeLayout(false);
            this.grpTiepNhanXe.PerformLayout();
            this.tabLapPhieu.ResumeLayout(false);
            this.tabLapPhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).EndInit();
            this.grpThemPhuTungChon.ResumeLayout(false);
            this.grpThemPhuTungChon.PerformLayout();
            this.grpThongTinPhieu.ResumeLayout(false);
            this.grpThongTinPhieu.PerformLayout();
            this.tabThanhToan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChuaThanhToan)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabTiepNhan;
        private System.Windows.Forms.TabPage tabLapPhieu;
        private System.Windows.Forms.TabPage tabThanhToan;

        private System.Windows.Forms.GroupBox grpTiepNhanXe;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Button btnTimXe;
        private System.Windows.Forms.Label lblHieuXe;
        private System.Windows.Forms.TextBox txtHieuXe;
        private System.Windows.Forms.Label lblNamSX;
        private System.Windows.Forms.TextBox txtNamSX;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnDangKyXe;

        private System.Windows.Forms.GroupBox grpQuanLyPhuTung;
        private System.Windows.Forms.Label lblTenPhuTung;
        private System.Windows.Forms.TextBox txtTenPhuTung;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.Button btnCapNhatPhuTung;
        private System.Windows.Forms.DataGridView dgvPhuTung;

        private System.Windows.Forms.GroupBox grpThongTinPhieu;
        private System.Windows.Forms.Label lblBienSoLapPhieu;
        private System.Windows.Forms.TextBox txtBienSoLapPhieu;
        private System.Windows.Forms.Label lblNoiDungSua;
        private System.Windows.Forms.TextBox txtNoiDungSua;

        private System.Windows.Forms.GroupBox grpThemPhuTungChon;
        private System.Windows.Forms.Label lblPhuTungChon;
        private System.Windows.Forms.ComboBox cboPhuTungChon;
        private System.Windows.Forms.Label lblSoLuongMua;
        private System.Windows.Forms.TextBox txtSoLuongMua;
        private System.Windows.Forms.Label lblTienCong;
        private System.Windows.Forms.TextBox txtTienCong;
        private System.Windows.Forms.Button btnThemPhuTungVaoPhieu;

        private System.Windows.Forms.DataGridView dgvChiTietPhieu;
        private System.Windows.Forms.Label lblTongTienTemp;
        private System.Windows.Forms.Button btnXacNhanLapPhieu;

        private System.Windows.Forms.DataGridView dgvPhieuChuaThanhToan;
        private System.Windows.Forms.Button btnThanhToan;
    }
}