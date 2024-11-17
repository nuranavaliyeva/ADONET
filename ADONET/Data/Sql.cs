using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ADONET.Data
{
    internal class Sql
    {
        private const string ConnectionString = "server=HP\\SQLEXPRESS;database=ADONET;trusted_connection=true;integrated security=true;";
        private  static SqlConnection connection = new SqlConnection(ConnectionString);

        public int ExecuteCommand(string command)
        {
            int result = 0;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(command, connection);
                 result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
           finally { connection.Close(); }
          
            return result;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(table);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close(); 
            }

            return table;
        }


       
    }
}
