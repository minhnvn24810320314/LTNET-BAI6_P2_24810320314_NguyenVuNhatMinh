using Microsoft.Data.SqlClient;

namespace BaiTap6_3.DAL
{
    public static class DatabaseHelper
    {
        // Sử dụng đúng tên Server LocalDB hiển thị trên SQL Server Object Explorer
        private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=ProjectTaskDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}