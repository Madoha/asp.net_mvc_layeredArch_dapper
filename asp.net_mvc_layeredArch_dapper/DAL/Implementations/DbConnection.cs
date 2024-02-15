using Microsoft.Data.SqlClient;

namespace asp.net_mvc_layeredArch_dapper.DAL.Implementations
{
    public class DbConnection
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection("Server=DESKTOP-162TCP9\\SQLEXPRESS; Database=mvcDapperLayeredArch; Trusted_Connection=true; TrustServerCertificate=True;");
        }
    }
}
