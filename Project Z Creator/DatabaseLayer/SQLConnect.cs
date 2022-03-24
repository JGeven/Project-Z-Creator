using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace Project_Z_Creator.DatabaseLayer
{
    
    public class SQLConnect
    {
        internal SqlCommand cmd;
        internal SqlConnection conn;

        public void Initialize()
        {
            string connectionString = "Server=mssqlstud.fhict.local;Database=dbi495808;User Id=dbi495808;Password=Welkom01;";
            conn = new SqlConnection(connectionString); ;
            cmd = conn.CreateCommand();
        }

        public bool OpenConnect()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool CloseConnect()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}   
