using System.Data.SqlClient;

namespace Project_Z_Database
{
    
    public class SqlConnect
    {
        internal SqlCommand Cmd;
        public SqlConnection Conn;

        public void Initialize()
        {
            string connectionString = "Server=mssqlstud.fhict.local;Database=dbi495808;User Id=dbi495808;Password=Welkom01;";
            Conn = new SqlConnection(connectionString);
            Cmd = Conn.CreateCommand();
        }

        public bool OpenConnect()
        {
            try
            {
                Conn.Open();
                return true;
            }
            catch (SqlException)
            {
                throw new Exception("Connection could not be established");
            }
        }

        public bool CloseConnect()
        {
            try
            {
                Conn.Close();
                return true;
            }
            catch (SqlException)
            {
                throw new Exception("Connection could not be established");
            }
        }
    }
}   
