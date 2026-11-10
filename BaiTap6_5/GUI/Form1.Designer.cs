namespace BaiTap6_5
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
            this.flpDanhSachPhong = new System.Windows.Forms.FlowLayoutPanel();
            this.grpChiTietPhong = new System.Windows.Forms.GroupBox();
            this.lblTenPhongChon = new System.Windows.Forms.Label();
            this.lblGioVao = new System.Windows.Forms.Label();
            this.lblDonGiaPhong = new System.Windows.Forms.Label();
            this.btnMoPhong = new System.Windows.Forms.Button();
            this.grpDichVu = new System.Windows.Forms.GroupBox();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.dgvChiTietDichVu = new System.Windows.Forms.DataGridView();
            this.lblTongTienDV = new System.Windows.Forms.Label();
            this.lblTongTienPhong = new System.Windows.Forms.Label();
            this.lblTongThanhToan = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpChiTietPhong.SuspendLayout();
            this.grpDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1000, 45);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "HỆ THỐNG QUẢN LÝ ĐẶT PHÒNG & DỊCH VỤ KARAOKE";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpDanhSachPhong
            // 
            this.flpDanhSachPhong.AutoScroll = true;
            this.flpDanhSachPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpDanhSachPhong.Location = new System.Drawing.Point(12, 55);
            this.flpDanhSachPhong.Name = "flpDanhSachPhong";
            this.flpDanhSachPhong.Size = new System.Drawing.Size(380, 520);
            this.flpDanhSachPhong.TabIndex = 1;
            // 
            // grpChiTietPhong
            // 
            this.grpChiTietPhong.Controls.Add(this.lblTenPhongChon);
            this.grpChiTietPhong.Controls.Add(this.lblGioVao);
            this.grpChiTietPhong.Controls.Add(this.lblDonGiaPhong);
            this.grpChiTietPhong.Controls.Add(this.btnMoPhong);
            this.grpChiTietPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpChiTietPhong.Location = new System.Drawing.Point(405, 55);
            this.grpChiTietPhong.Name = "grpChiTietPhong";
            this.grpChiTietPhong.Size = new System.Drawing.Size(580, 115);
            this.grpChiTietPhong.TabIndex = 2;
            this.grpChiTietPhong.TabStop = false;
            this.grpChiTietPhong.Text = "Thông tin phòng đang chọn";
            // 
            // lblTenPhongChon
            // 
            this.lblTenPhongChon.AutoSize = true;
            this.lblTenPhongChon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTenPhongChon.ForeColor = System.Drawing.Color.Crimson;
            this.lblTenPhongChon.Location = new System.Drawing.Point(15, 28);
            this.lblTenPhongChon.Name = "lblTenPhongChon";
            this.lblTenPhongChon.Size = new System.Drawing.Size(149, 20);
            this.lblTenPhongChon.TabIndex = 0;
            this.lblTenPhongChon.Text = "Chưa chọn phòng";
            // 
            // lblDonGiaPhong
            // 
            this.lblDonGiaPhong.AutoSize = true;
            this.lblDonGiaPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDonGiaPhong.Location = new System.Drawing.Point(15, 55);
            this.lblDonGiaPhong.Name = "lblDonGiaPhong";
            this.lblDonGiaPhong.Size = new System.Drawing.Size(102, 17);
            this.lblDonGiaPhong.TabIndex = 1;
            this.lblDonGiaPhong.Text = "Giá/giờ: 0 VNĐ";
            // 
            // lblGioVao
            // 
            this.lblGioVao.AutoSize = true;
            this.lblGioVao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGioVao.Location = new System.Drawing.Point(15, 80);
            this.lblGioVao.Name = "lblGioVao";
            this.lblGioVao.Size = new System.Drawing.Size(117, 17);
            this.lblGioVao.TabIndex = 2;
            this.lblGioVao.Text = "Giờ vào: Chưa hát";
            // 
            // btnMoPhong
            // 
            this.btnMoPhong.BackColor = System.Drawing.Color.ForestGreen;
            this.btnMoPhong.ForeColor = System.Drawing.Color.White;
            this.btnMoPhong.Location = new System.Drawing.Point(435, 25);
            this.btnMoPhong.Name = "btnMoPhong";
            this.btnMoPhong.Size = new System.Drawing.Size(130, 45);
            this.btnMoPhong.TabIndex = 3;
            this.btnMoPhong.Text = "MỞ PHÒNG";
            this.btnMoPhong.UseVisualStyleBackColor = false;
            this.btnMoPhong.Click += new System.EventHandler(this.btnMoPhong_Click);
            // 
            // grpDichVu
            // 
            this.grpDichVu.Controls.Add(this.cboDichVu);
            this.grpDichVu.Controls.Add(this.numSoLuong);
            this.grpDichVu.Controls.Add(this.btnThemDV);
            this.grpDichVu.Controls.Add(this.dgvChiTietDichVu);
            this.grpDichVu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDichVu.Location = new System.Drawing.Point(405, 176);
            this.grpDichVu.Name = "grpDichVu";
            this.grpDichVu.Size = new System.Drawing.Size(580, 275);
            this.grpDichVu.TabIndex = 3;
            this.grpDichVu.TabStop = false;
            this.grpDichVu.Text = "Gọi Dịch vụ / Đồ uống (Disconnected Model)";
            // 
            // cboDichVu
            // 
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDichVu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(15, 27);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(250, 25);
            this.cboDichVu.TabIndex = 0;
            // 
            // numSoLuong
            // 
            this.numSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numSoLuong.Location = new System.Drawing.Point(280, 27);
            this.numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(70, 24);
            this.numSoLuong.TabIndex = 1;
            this.numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThemDV
            // 
            this.btnThemDV.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThemDV.ForeColor = System.Drawing.Color.White;
            this.btnThemDV.Location = new System.Drawing.Point(365, 23);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(120, 32);
            this.btnThemDV.TabIndex = 2;
            this.btnThemDV.Text = "Thêm Dịch vụ";
            this.btnThemDV.UseVisualStyleBackColor = false;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // dgvChiTietDichVu
            // 
            this.dgvChiTietDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietDichVu.Location = new System.Drawing.Point(15, 63);
            this.dgvChiTietDichVu.Name = "dgvChiTietDichVu";
            this.dgvChiTietDichVu.ReadOnly = true;
            this.dgvChiTietDichVu.Size = new System.Drawing.Size(550, 200);
            this.dgvChiTietDichVu.TabIndex = 3;
            // 
            // lblTongTienDV
            // 
            this.lblTongTienDV.AutoSize = true;
            this.lblTongTienDV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTongTienDV.Location = new System.Drawing.Point(405, 460);
            this.lblTongTienDV.Name = "lblTongTienDV";
            this.lblTongTienDV.Size = new System.Drawing.Size(161, 17);
            this.lblTongTienDV.TabIndex = 4;
            this.lblTongTienDV.Text = "Tiền dịch vụ: 0 VNĐ";
            // 
            // lblTongTienPhong
            // 
            this.lblTongTienPhong.AutoSize = true;
            this.lblTongTienPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTongTienPhong.Location = new System.Drawing.Point(405, 485);
            this.lblTongTienPhong.Name = "lblTongTienPhong";
            this.lblTongTienPhong.Size = new System.Drawing.Size(155, 17);
            this.lblTongTienPhong.TabIndex = 5;
            this.lblTongTienPhong.Text = "Tiền giờ hát: 0 VNĐ";
            // 
            // lblTongThanhToan
            // 
            this.lblTongThanhToan.AutoSize = true;
            this.lblTongThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongThanhToan.ForeColor = System.Drawing.Color.Red;
            this.lblTongThanhToan.Location = new System.Drawing.Point(405, 512);
            this.lblTongThanhToan.Name = "lblTongThanhToan";
            this.lblTongThanhToan.Size = new System.Drawing.Size(225, 21);
            this.lblTongThanhToan.TabIndex = 6;
            this.lblTongThanhToan.Text = "TỔNG THANH TOÁN: 0 VNĐ";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.DarkOrange;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(760, 460);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(225, 75);
            this.btnThanhToan.TabIndex = 7;
            this.btnThanhToan.Text = "THANH TOÁN (SqlTransaction)";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1000, 590);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.flpDanhSachPhong);
            this.Controls.Add(this.grpChiTietPhong);
            this.Controls.Add(this.grpDichVu);
            this.Controls.Add(this.lblTongTienDV);
            this.Controls.Add(this.lblTongTienPhong);
            this.Controls.Add(this.lblTongThanhToan);
            this.Controls.Add(this.btnThanhToan);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 6.5 - Hệ Thống Quản Lý Phòng & Dịch Vụ Karaoke";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpChiTietPhong.ResumeLayout(false);
            this.grpChiTietPhong.PerformLayout();
            this.grpDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDichVu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.FlowLayoutPanel flpDanhSachPhong;
        private System.Windows.Forms.GroupBox grpChiTietPhong;
        private System.Windows.Forms.Label lblTenPhongChon;
        private System.Windows.Forms.Label lblDonGiaPhong;
        private System.Windows.Forms.Label lblGioVao;
        private System.Windows.Forms.Button btnMoPhong;
        private System.Windows.Forms.GroupBox grpDichVu;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.DataGridView dgvChiTietDichVu;
        private System.Windows.Forms.Label lblTongTienDV;
        private System.Windows.Forms.Label lblTongTienPhong;
        private System.Windows.Forms.Label lblTongThanhToan;
        private System.Windows.Forms.Button btnThanhToan;
    }
}