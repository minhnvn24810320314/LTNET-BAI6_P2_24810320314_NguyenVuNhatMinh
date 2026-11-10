using System.Data;
using BaiTap6_3.DAL;
using BaiTap6_3.DTO;

namespace BaiTap6_3.BUS
{
    public class TaskBUS
    {
        private TaskDAL taskDAL = new TaskDAL();

        // 1. Lấy danh sách Task theo bộ lọc Dự án & Trạng thái
        public DataTable GetTasksByFilter(int maDuAn, string trangThai)
        {
            return taskDAL.GetTasksByFilter(maDuAn, trangThai);
        }

        // 2. Thêm Task mới & Phân công cho Thành viên
        public bool AddTask(CongViecDTO task, int maThanhVien)
        {
            if (string.IsNullOrWhiteSpace(task.TenTask))
                return false;

            return taskDAL.InsertTask(task, maThanhVien);
        }

        // 3. Cập nhật Trạng thái Task
        public bool UpdateStatus(int maTask, string trangThaiMoi)
        {
            if (maTask <= 0 || string.IsNullOrEmpty(trangThaiMoi))
                return false;

            return taskDAL.UpdateTaskStatus(maTask, trangThaiMoi);
        }

        // 4. Lấy danh sách Task bị quá hạn (SqlDataReader)
        public DataTable GetOverdueTasks()
        {
            return taskDAL.GetOverdueTasks();
        }

        // 5. Thống kê tỷ lệ % hoàn thành theo Thành viên (GROUP BY)
        public DataTable GetMemberCompletionRate(int maDuAn)
        {
            return taskDAL.GetMemberCompletionRate(maDuAn);
        }

        // Helper: Lấy danh sách Dự án
        public DataTable GetAllProjects()
        {
            return taskDAL.GetAllProjects();
        }

        // Helper: Lấy danh sách Thành viên
        public DataTable GetAllMembers()
        {
            return taskDAL.GetAllMembers();
        }
    }
}