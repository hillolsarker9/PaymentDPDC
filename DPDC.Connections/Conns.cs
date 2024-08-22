using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DPDC.Connections
{
    public class Conns : ConnString, IDisposable
    {
        private SqlConnection _connection;
        
        protected static IDbConnection LiveConnection(string dbName)
        {
            SqlConnection connection = GetConnection(dbName); // Get a connection for the provided database name
            connection.Open(); // Open the connection
            return connection; // Return the live connection
        }

        //private static IDbConnection OpenConnection(SqlConnection conn)
        //{
        //    return new SqlConnection(conn.ConnectionString);
        //}

        public void OpenConnection(string dbName)
        {
            _connection = GetConnection(dbName);
            Console.WriteLine(_connection.ConnectionString); // Verify connection string
            _connection.Open();
        }

        protected static bool CloseConnection(IDbConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
                // connection.Dispose();
            }
            return true;
        }
        private static void ClearPool()
        {
            SqlConnection.ClearAllPools();
        }

        public void Dispose()
        {
            _connection.Close(); // Close the connection
            _connection.Dispose(); // Dispose the connection
            _connection = null; // Nullify the connection object to prevent further use
            ClearPool();
        }
    }
}
