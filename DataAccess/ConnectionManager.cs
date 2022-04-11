using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class ConnectionManager
    {
        private static string ConnectionString { get; set; }

        private static void init()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            //builder.DataSource = "ASUS-VIVOBOOK";
            builder.DataSource = "ASUSVIVO";
            builder.InitialCatalog = "Kwik4";
            builder.IntegratedSecurity = true;

            ConnectionString = builder.ConnectionString;
        }


        public static SqlConnection CreateConnection()
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                init();
            }
            return new SqlConnection(ConnectionString);
        }
    }
}
