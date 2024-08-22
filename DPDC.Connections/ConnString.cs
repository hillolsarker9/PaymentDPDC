using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPDC.Connections
{
    public abstract class ConnString
    {
        //private static SqlConnection GetConnectionString(string dbName)
        //{
        //    SqlConnection conn = new SqlConnection();

        //    conn.ConnectionString = @"Data Source=192.168.50.77;Initial Catalog=" + dbName + "; PersistSecurityInfo = false; Integrated Security = false; Pooling = true; User id=sa;Password=1ndex@2023%24#new; Connect Timeout=0;";

        //    return conn;
        //}

        protected static SqlConnection GetConnection(string dbName)
        {
            // Create a connection string properly formatted
            string connectionString = $@"Data Source=192.168.50.77;
                                     Initial Catalog={dbName};
                                     Persist Security Info=false;
                                     Integrated Security=false;
                                     Pooling=true;
                                     User ID=sa;
                                     Password=1ndex@2023%24#new;
                                     Connect Timeout=0;";

            // Initialize the SqlConnection with the correct connection string
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
