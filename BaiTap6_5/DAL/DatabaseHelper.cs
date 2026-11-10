using Microsoft.Data.SqlClient;

namespace BaiTap6_5.DAL
{
    public class DatabaseHelper
    {
        // Connection String kết nối CSDL KaraokeDB trên localdb
        private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=KaraokeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}