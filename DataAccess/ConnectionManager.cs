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

            ConnectionString = "Data Source=SQL8001.site4now.net;Initial Catalog=db_a8588d_kwikmart;User Id=db_a8588d_kwikmart_admin;Password=mlpnko123";//builder.ConnectionString;
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
