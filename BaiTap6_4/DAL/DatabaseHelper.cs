using Microsoft.Data.SqlClient;

namespace BaiTap6_4.DAL
{
    public static class DatabaseHelper
    {
        private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GarageDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}