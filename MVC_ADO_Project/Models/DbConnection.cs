using Microsoft.Data.SqlClient;

namespace MVC_ADO_Project.Models
{
    public class DbConnection
    {
        public SqlConnection Connection;
        public DbConnection()
        {
            Connection = new SqlConnection(DbConfig.Connectionstr);
        }
    }
}
