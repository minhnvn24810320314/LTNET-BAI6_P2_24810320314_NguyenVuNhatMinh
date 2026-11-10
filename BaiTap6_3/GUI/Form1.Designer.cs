namespace BaiTap6_3
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
            this.tabTask = new System.Windows.Forms.TabPage();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.grpCapNhat = new System.Windows.Forms.GroupBox();
            this.btnCapNhatTrangThai = new System.Windows.Forms.Button();
            this.cboCapNhatTrangThai = new System.Windows.Forms.ComboBox();
            this.lblCapNhatTrangThai = new System.Windows.Forms.Label();
            this.grpThemTask = new System.Windows.Forms.GroupBox();
            this.btnThemTask = new System.Windows.Forms.Button();
            this.cboPhanCongThanhVien = new System.Windows.Forms.ComboBox();
            this.lblPhanCong = new System.Windows.Forms.Label();
            this.cboDoUuTien = new System.Windows.Forms.ComboBox();
            this.lblDoUuTien = new System.Windows.Forms.Label();
            this.dtpHanNop = new System.Windows.Forms.DateTimePicker();
            this.lblHanNop = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtTenTask = new System.Windows.Forms.TextBox();
            this.lblTenTask = new System.Windows.Forms.Label();
            this.cboTrangThaiLoc = new System.Windows.Forms.ComboBox();
            this.lblTrangThaiLoc = new System.Windows.Forms.Label();
            this.cboDuAn = new System.Windows.Forms.ComboBox();
            this.lblDuAn = new System.Windows.Forms.Label();
            this.tabOverdue = new System.Windows.Forms.TabPage();
            this.dgvOverdue = new System.Windows.Forms.DataGridView();
            this.btnKiemTraOverdue = new System.Windows.Forms.Button();
            this.tabBaoCao = new System.Windows.Forms.TabPage();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.btnXemBaoCao = new System.Windows.Forms.Button();

            this.tabControlMain.SuspendLayout();
            this.tabTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.grpCapNhat.SuspendLayout();
            this.grpThemTask.SuspendLayout();
            this.tabOverdue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdue)).BeginInit();
            this.tabBaoCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();

            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabTask);
            this.tabControlMain.Controls.Add(this.tabOverdue);
            this.tabControlMain.Controls.Add(this.tabBaoCao);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(984, 611);
            this.tabControlMain.TabIndex = 0;

            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.dgvTask);
            this.tabTask.Controls.Add(this.grpCapNhat);
            this.tabTask.Controls.Add(this.grpThemTask);
            this.tabTask.Location = new System.Drawing.Point(4, 24);
            this.tabTask.Name = "tabTask";
            this.tabTask.Padding = new System.Windows.Forms.Padding(3);
            this.tabTask.Size = new System.Drawing.Size(976, 583);
            this.tabTask.TabIndex = 0;
            this.tabTask.Text = "1. Quản lý & Chuyển trạng thái Task";
            this.tabTask.UseVisualStyleBackColor = true;

            // 
            // grpThemTask
            // 
            this.grpThemTask.Controls.Add(this.btnThemTask);
            this.grpThemTask.Controls.Add(this.cboPhanCongThanhVien);
            this.grpThemTask.Controls.Add(this.lblPhanCong);
            this.grpThemTask.Controls.Add(this.cboDoUuTien);
            this.grpThemTask.Controls.Add(this.lblDoUuTien);
            this.grpThemTask.Controls.Add(this.dtpHanNop);
            this.grpThemTask.Controls.Add(this.lblHanNop);
            this.grpThemTask.Controls.Add(this.txtMoTa);
            this.grpThemTask.Controls.Add(this.lblMoTa);
            this.grpThemTask.Controls.Add(this.txtTenTask);
            this.grpThemTask.Controls.Add(this.lblTenTask);
            this.grpThemTask.Controls.Add(this.cboTrangThaiLoc);
            this.grpThemTask.Controls.Add(this.lblTrangThaiLoc);
            this.grpThemTask.Controls.Add(this.cboDuAn);
            this.grpThemTask.Controls.Add(this.lblDuAn);
            this.grpThemTask.Location = new System.Drawing.Point(12, 10);
            this.grpThemTask.Name = "grpThemTask";
            this.grpThemTask.Size = new System.Drawing.Size(952, 160);
            this.grpThemTask.TabIndex = 0;
            this.grpThemTask.TabStop = false;
            this.grpThemTask.Text = "Bộ lọc & Thêm mới Task";

            // lblDuAn & cboDuAn
            this.lblDuAn.AutoSize = true;
            this.lblDuAn.Location = new System.Drawing.Point(15, 25);
            this.lblDuAn.Name = "lblDuAn";
            this.lblDuAn.Size = new System.Drawing.Size(42, 15);
            this.lblDuAn.Text = "Dự án:";

            this.cboDuAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDuAn.FormattingEnabled = true;
            this.cboDuAn.Location = new System.Drawing.Point(80, 22);
            this.cboDuAn.Name = "cboDuAn";
            this.cboDuAn.Size = new System.Drawing.Size(220, 23);
            this.cboDuAn.TabIndex = 1;
            this.cboDuAn.SelectedIndexChanged += new System.EventHandler(this.cboDuAn_SelectedIndexChanged);

            // lblTrangThaiLoc & cboTrangThaiLoc
            this.lblTrangThaiLoc.AutoSize = true;
            this.lblTrangThaiLoc.Location = new System.Drawing.Point(320, 25);
            this.lblTrangThaiLoc.Name = "lblTrangThaiLoc";
            this.lblTrangThaiLoc.Size = new System.Drawing.Size(81, 15);
            this.lblTrangThaiLoc.Text = "Lọc Trạng thái:";

            this.cboTrangThaiLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiLoc.FormattingEnabled = true;
            this.cboTrangThaiLoc.Location = new System.Drawing.Point(405, 22);
            this.cboTrangThaiLoc.Name = "cboTrangThaiLoc";
            this.cboTrangThaiLoc.Size = new System.Drawing.Size(150, 23);
            this.cboTrangThaiLoc.TabIndex = 2;
            this.cboTrangThaiLoc.SelectedIndexChanged += new System.EventHandler(this.cboTrangThaiLoc_SelectedIndexChanged);

            // lblTenTask & txtTenTask
            this.lblTenTask.AutoSize = true;
            this.lblTenTask.Location = new System.Drawing.Point(15, 60);
            this.lblTenTask.Name = "lblTenTask";
            this.lblTenTask.Size = new System.Drawing.Size(53, 15);
            this.lblTenTask.Text = "Tên Task:";

            this.txtTenTask.Location = new System.Drawing.Point(80, 57);
            this.txtTenTask.Name = "txtTenTask";
            this.txtTenTask.Size = new System.Drawing.Size(220, 23);
            this.txtTenTask.TabIndex = 3;

            // lblMoTa & txtMoTa
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(320, 60);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(41, 15);
            this.lblMoTa.Text = "Mô tả:";

            this.txtMoTa.Location = new System.Drawing.Point(405, 57);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(530, 23);
            this.txtMoTa.TabIndex = 4;

            // lblHanNop & dtpHanNop
            this.lblHanNop.AutoSize = true;
            this.lblHanNop.Location = new System.Drawing.Point(15, 95);
            this.lblHanNop.Name = "lblHanNop";
            this.lblHanNop.Size = new System.Drawing.Size(56, 15);
            this.lblHanNop.Text = "Hạn nộp:";

            this.dtpHanNop.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHanNop.Location = new System.Drawing.Point(80, 92);
            this.dtpHanNop.Name = "dtpHanNop";
            this.dtpHanNop.Size = new System.Drawing.Size(220, 23);
            this.dtpHanNop.TabIndex = 5;

            // lblDoUuTien & cboDoUuTien
            this.lblDoUuTien.AutoSize = true;
            this.lblDoUuTien.Location = new System.Drawing.Point(320, 95);
            this.lblDoUuTien.Name = "lblDoUuTien";
            this.lblDoUuTien.Size = new System.Drawing.Size(65, 15);
            this.lblDoUuTien.Text = "Độ ưu tiên:";

            this.cboDoUuTien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoUuTien.FormattingEnabled = true;
            this.cboDoUuTien.Location = new System.Drawing.Point(405, 92);
            this.cboDoUuTien.Name = "cboDoUuTien";
            this.cboDoUuTien.Size = new System.Drawing.Size(150, 23);
            this.cboDoUuTien.TabIndex = 6;

            // lblPhanCong & cboPhanCongThanhVien
            this.lblPhanCong.AutoSize = true;
            this.lblPhanCong.Location = new System.Drawing.Point(575, 95);
            this.lblPhanCong.Name = "lblPhanCong";
            this.lblPhanCong.Size = new System.Drawing.Size(67, 15);
            this.lblPhanCong.Text = "Phân công:";

            this.cboPhanCongThanhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhanCongThanhVien.FormattingEnabled = true;
            this.cboPhanCongThanhVien.Location = new System.Drawing.Point(650, 92);
            this.cboPhanCongThanhVien.Name = "cboPhanCongThanhVien";
            this.cboPhanCongThanhVien.Size = new System.Drawing.Size(285, 23);
            this.cboPhanCongThanhVien.TabIndex = 7;

            // btnThemTask
            this.btnThemTask.Location = new System.Drawing.Point(750, 122);
            this.btnThemTask.Name = "btnThemTask";
            this.btnThemTask.Size = new System.Drawing.Size(185, 30);
            this.btnThemTask.TabIndex = 8;
            this.btnThemTask.Text = "Thêm Task & Phân công";
            this.btnThemTask.UseVisualStyleBackColor = true;
            this.btnThemTask.Click += new System.EventHandler(this.btnThemTask_Click);

            // 
            // grpCapNhat
            // 
            this.grpCapNhat.Controls.Add(this.btnCapNhatTrangThai);
            this.grpCapNhat.Controls.Add(this.cboCapNhatTrangThai);
            this.grpCapNhat.Controls.Add(this.lblCapNhatTrangThai);
            this.grpCapNhat.Location = new System.Drawing.Point(12, 175);
            this.grpCapNhat.Name = "grpCapNhat";
            this.grpCapNhat.Size = new System.Drawing.Size(952, 60);
            this.grpCapNhat.TabIndex = 1;
            this.grpCapNhat.TabStop = false;
            this.grpCapNhat.Text = "Chuyển Trạng thái Task đang chọn";

            // lblCapNhatTrangThai & cboCapNhatTrangThai
            this.lblCapNhatTrangThai.AutoSize = true;
            this.lblCapNhatTrangThai.Location = new System.Drawing.Point(15, 25);
            this.lblCapNhatTrangThai.Name = "lblCapNhatTrangThai";
            this.lblCapNhatTrangThai.Size = new System.Drawing.Size(91, 15);
            this.lblCapNhatTrangThai.Text = "Trạng thái mới:";

            this.cboCapNhatTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCapNhatTrangThai.FormattingEnabled = true;
            this.cboCapNhatTrangThai.Location = new System.Drawing.Point(115, 22);
            this.cboCapNhatTrangThai.Name = "cboCapNhatTrangThai";
            this.cboCapNhatTrangThai.Size = new System.Drawing.Size(180, 23);
            this.cboCapNhatTrangThai.TabIndex = 1;

            // btnCapNhatTrangThai
            this.btnCapNhatTrangThai.Location = new System.Drawing.Point(310, 20);
            this.btnCapNhatTrangThai.Name = "btnCapNhatTrangThai";
            this.btnCapNhatTrangThai.Size = new System.Drawing.Size(180, 28);
            this.btnCapNhatTrangThai.TabIndex = 2;
            this.btnCapNhatTrangThai.Text = "Cập nhật Trạng thái";
            this.btnCapNhatTrangThai.UseVisualStyleBackColor = true;
            this.btnCapNhatTrangThai.Click += new System.EventHandler(this.btnCapNhatTrangThai_Click);

            // 
            // dgvTask
            // 
            this.dgvTask.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.Location = new System.Drawing.Point(12, 242);
            this.dgvTask.MultiSelect = false;
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.ReadOnly = true;
            this.dgvTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTask.Size = new System.Drawing.Size(952, 330);
            this.dgvTask.TabIndex = 2;

            // 
            // tabOverdue
            // 
            this.tabOverdue.Controls.Add(this.dgvOverdue);
            this.tabOverdue.Controls.Add(this.btnKiemTraOverdue);
            this.tabOverdue.Location = new System.Drawing.Point(4, 24);
            this.tabOverdue.Name = "tabOverdue";
            this.tabOverdue.Padding = new System.Windows.Forms.Padding(3);
            this.tabOverdue.Size = new System.Drawing.Size(976, 583);
            this.tabOverdue.TabIndex = 1;
            this.tabOverdue.Text = "2. Cảnh báo Task Trễ hạn (SqlDataReader)";
            this.tabOverdue.UseVisualStyleBackColor = true;

            // btnKiemTraOverdue
            this.btnKiemTraOverdue.Location = new System.Drawing.Point(15, 15);
            this.btnKiemTraOverdue.Name = "btnKiemTraOverdue";
            this.btnKiemTraOverdue.Size = new System.Drawing.Size(250, 35);
            this.btnKiemTraOverdue.TabIndex = 0;
            this.btnKiemTraOverdue.Text = "Tải danh sách Task Quá hạn";
            this.btnKiemTraOverdue.UseVisualStyleBackColor = true;
            this.btnKiemTraOverdue.Click += new System.EventHandler(this.btnKiemTraOverdue_Click);

            // dgvOverdue
            this.dgvOverdue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOverdue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdue.Location = new System.Drawing.Point(15, 60);
            this.dgvOverdue.Name = "dgvOverdue";
            this.dgvOverdue.ReadOnly = true;
            this.dgvOverdue.Size = new System.Drawing.Size(945, 505);
            this.dgvOverdue.TabIndex = 1;

            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.dgvBaoCao);
            this.tabBaoCao.Controls.Add(this.btnXemBaoCao);
            this.tabBaoCao.Location = new System.Drawing.Point(4, 24);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaoCao.Size = new System.Drawing.Size(976, 583);
            this.tabBaoCao.TabIndex = 2;
            this.tabBaoCao.Text = "3. Thống kê % Hoàn thành (GROUP BY)";
            this.tabBaoCao.UseVisualStyleBackColor = true;

            // btnXemBaoCao
            this.btnXemBaoCao.Location = new System.Drawing.Point(15, 15);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(250, 35);
            this.btnXemBaoCao.TabIndex = 0;
            this.btnXemBaoCao.Text = "Xem Báo cáo % Hoàn thành";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);

            // dgvBaoCao
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(15, 60);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.Size = new System.Drawing.Size(945, 505);
            this.dgvBaoCao.TabIndex = 1;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 6.3 - Hệ thống Quản lý Công việc & Tiến độ Dự án (ProjectTaskDB)";
            this.tabControlMain.ResumeLayout(false);
            this.tabTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.grpCapNhat.ResumeLayout(false);
            this.grpCapNhat.PerformLayout();
            this.grpThemTask.ResumeLayout(false);
            this.grpThemTask.PerformLayout();
            this.tabOverdue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdue)).EndInit();
            this.tabBaoCao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabTask;
        private System.Windows.Forms.TabPage tabOverdue;
        private System.Windows.Forms.TabPage tabBaoCao;

        private System.Windows.Forms.GroupBox grpThemTask;
        private System.Windows.Forms.Label lblDuAn;
        private System.Windows.Forms.ComboBox cboDuAn;
        private System.Windows.Forms.Label lblTrangThaiLoc;
        private System.Windows.Forms.ComboBox cboTrangThaiLoc;
        private System.Windows.Forms.Label lblTenTask;
        private System.Windows.Forms.TextBox txtTenTask;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblHanNop;
        private System.Windows.Forms.DateTimePicker dtpHanNop;
        private System.Windows.Forms.Label lblDoUuTien;
        private System.Windows.Forms.ComboBox cboDoUuTien;
        private System.Windows.Forms.Label lblPhanCong;
        private System.Windows.Forms.ComboBox cboPhanCongThanhVien;
        private System.Windows.Forms.Button btnThemTask;

        private System.Windows.Forms.GroupBox grpCapNhat;
        private System.Windows.Forms.Label lblCapNhatTrangThai;
        private System.Windows.Forms.ComboBox cboCapNhatTrangThai;
        private System.Windows.Forms.Button btnCapNhatTrangThai;

        private System.Windows.Forms.DataGridView dgvTask;

        private System.Windows.Forms.Button btnKiemTraOverdue;
        private System.Windows.Forms.DataGridView dgvOverdue;

        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.DataGridView dgvBaoCao;
    }
}