using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BaiTap6_3.BUS;
using BaiTap6_3.DTO;

namespace BaiTap6_3
{
    public partial class Form1 : Form
    {
        private TaskBUS taskBUS = new TaskBUS();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
            LoadGridTask();
        }

        // Load dữ liệu lên các ComboBox
        private void LoadComboboxData()
        {
            try
            {
                // ComboBox Dự án
                DataTable dtDuAn = taskBUS.GetAllProjects();
                cboDuAn.DataSource = dtDuAn;
                cboDuAn.DisplayMember = "TenDuAn";
                cboDuAn.ValueMember = "MaDuAn";

                // ComboBox Thành viên
                DataTable dtTV = taskBUS.GetAllMembers();
                cboPhanCongThanhVien.DataSource = dtTV;
                cboPhanCongThanhVien.DisplayMember = "HoTen";
                cboPhanCongThanhVien.ValueMember = "MaThanhVien";

                // ComboBox Bộ lọc Trạng thái
                cboTrangThaiLoc.Items.Clear();
                cboTrangThaiLoc.Items.AddRange(new string[] { "Tất cả", "To Do", "In Progress", "Done" });
                cboTrangThaiLoc.SelectedIndex = 0;

                // ComboBox Đổi Trạng thái
                cboCapNhatTrangThai.Items.Clear();
                cboCapNhatTrangThai.Items.AddRange(new string[] { "To Do", "In Progress", "Done" });
                cboCapNhatTrangThai.SelectedIndex = 0;

                // ComboBox Độ ưu tiên
                cboDoUuTien.Items.Clear();
                cboDoUuTien.Items.AddRange(new string[] { "Cao", "Trung bình", "Thấp" });
                cboDoUuTien.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Thông báo Lỗi");
            }
        }

        // Load danh sách Task lên DataGridView
        private void LoadGridTask()
        {
            if (cboDuAn.SelectedValue == null || cboDuAn.SelectedValue is DataRowView) return;

            int maDuAn = Convert.ToInt32(cboDuAn.SelectedValue);
            string trangThai = cboTrangThaiLoc.SelectedItem != null ? cboTrangThaiLoc.SelectedItem.ToString() : "Tất cả";

            dgvTask.DataSource = taskBUS.GetTasksByFilter(maDuAn, trangThai);
        }

        // Sự kiện lọc danh sách khi đổi Dự án hoặc Trạng thái
        private void cboDuAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridTask();
        }

        private void cboTrangThaiLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridTask();
        }

        // 1. Thêm Task mới & Phân công
        private void btnThemTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenTask.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên công việc!", "Cảnh báo");
                return;
            }

            CongViecDTO task = new CongViecDTO
            {
                MaDuAn = Convert.ToInt32(cboDuAn.SelectedValue),
                TenTask = txtTenTask.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                HanNop = dtpHanNop.Value,
                DoUuTien = cboDoUuTien.SelectedItem.ToString(),
                TrangThai = "To Do"
            };

            int maThanhVien = Convert.ToInt32(cboPhanCongThanhVien.SelectedValue);

            if (taskBUS.AddTask(task, maThanhVien))
            {
                MessageBox.Show("Thêm công việc và phân công thành công!", "Thông báo");
                txtTenTask.Clear();
                txtMoTa.Clear();
                LoadGridTask();
            }
            else
            {
                MessageBox.Show("Thêm công việc thất bại!", "Lỗi");
            }
        }

        // 2. Cập nhật Trạng thái Task (Parameterized Update)
        private void btnCapNhatTrangThai_Click(object sender, EventArgs e)
        {
            if (dgvTask.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 công việc trên bảng để cập nhật!", "Thông báo");
                return;
            }

            int maTask = Convert.ToInt32(dgvTask.CurrentRow.Cells["MaTask"].Value);
            string trangThaiMoi = cboCapNhatTrangThai.SelectedItem.ToString();

            if (taskBUS.UpdateStatus(maTask, trangThaiMoi))
            {
                MessageBox.Show("Cập nhật trạng thái công việc thành công!", "Thông báo");
                LoadGridTask();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi");
            }
        }

        // 3. Kiểm tra Cảnh báo Trễ hạn bằng SqlDataReader (Tab 2)
        private void btnKiemTraOverdue_Click(object sender, EventArgs e)
        {
            DataTable dtOverdue = taskBUS.GetOverdueTasks();
            dgvOverdue.DataSource = dtOverdue;

            if (dtOverdue.Rows.Count > 0)
            {
                MessageBox.Show($"Phát hiện {dtOverdue.Rows.Count} công việc quá hạn cần xử lý!", "Cảnh báo Overdue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Không có công việc nào bị quá hạn!", "Thông báo");
            }
        }

        // 4. Xem Báo cáo % Hoàn thành theo Thành viên bằng GROUP BY (Tab 3)
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            int maDuAn = cboDuAn.SelectedValue != null ? Convert.ToInt32(cboDuAn.SelectedValue) : 0;
            dgvBaoCao.DataSource = taskBUS.GetMemberCompletionRate(maDuAn);
        }
    }
}