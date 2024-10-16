using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProCuaHangLinhKienLaptop.DB
{
    public class DataProvider
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=DESKTOP-C8B20IS;Initial Catalog=LinhkienLaptop;Integrated Security=True;Connect Timeout=30";
        public DataProvider() {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                Debug.WriteLine("Connected to SQL Server");
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Error connecting to SQL Server: " + ex.Message);
            }
        }
        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;

                if (commandParameters != null)
                {
                    foreach (SqlParameter parm in commandParameters)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public DataTable ExecuteReader(string cmdText, CommandType cmdType, params SqlParameter[] commandParameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = cmdType;

                    if (commandParameters != null)
                    {
                        foreach (SqlParameter parm in commandParameters)
                            cmd.Parameters.Add(parm);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable); 
                    }
                }
            }

            return dataTable;  
        }

        public object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;

                if (commandParameters != null)
                {
                    foreach (SqlParameter parm in commandParameters)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
    }
}
