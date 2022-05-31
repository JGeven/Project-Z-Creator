using System.Data.SqlClient;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using System.Web.Helpers;

namespace Project_Z_Database
{
    public class UserSQL : SQLConnect, IUserContainer
    {
        public UserSQL()
        {
            Initialize();
        }
        
        public List<UserDTO> GetUsers()
        {
            OpenConnect();
            cmd.CommandText = "SELECT * FROM [User]";

            List<UserDTO> users = new List<UserDTO>();
            using SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                UserDTO userDTO = new UserDTO()
                {
                    UserID = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Email = rdr.GetString(2),
                    Password = rdr.GetString(3)
                };
                    users.Add(userDTO);
            }
            CloseConnect();
            return users;
        }
        
        public UserDTO GetUserbyID(int userID)
        {
            OpenConnect();
            cmd.CommandText = "SELECT * FROM [User] WHERE UserID = @UserID";
            cmd.Parameters.AddWithValue("@UserID", userID);

            UserDTO userDTO = null;
            using SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                userDTO = new UserDTO()
                {
                    UserID = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Email = rdr.GetString(2),
                    Password = rdr.GetString(3)
                };
            }
            CloseConnect();
            return userDTO;
        }

        public bool EmailExist(string email)
        {
            OpenConnect();
            cmd.CommandText = "SELECT Count(1) FROM [User] WHERE Email = @Email";
            cmd.Parameters.AddWithValue("@Email", email);
            
            int inUse = (int)cmd.ExecuteScalar();

            CloseConnect();

            if (inUse > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RegisterUser(UserDTO dto)
        {
            OpenConnect();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO [User] (Name, Email, Password) VALUES (@Name, @Email, @Password)";
            cmd.Parameters.AddWithValue("@Name", dto.Name);
            cmd.Parameters.AddWithValue("@Email", dto.Email);
            cmd.Parameters.AddWithValue("@Password", Crypto.HashPassword(dto.Password));
                
            cmd.ExecuteNonQuery();
            CloseConnect();
            return true;
        }

        private bool PasswordCheck(string email, string password)
        {
            OpenConnect();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT Password FROM [User] WHERE Email = @Email";
            cmd.Parameters.AddWithValue("@Email", email);

            var hashpassword = "";

            using SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                hashpassword = rdr.GetString(0);
            }

            CloseConnect();

            if (Crypto.VerifyHashedPassword(hashpassword, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserDTO Login(string email, string password)
        {
            UserDTO userDTO = new UserDTO();
            if (PasswordCheck(email, password))
            {
                OpenConnect();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM [User] WHERE Email = @Email";
                cmd.Parameters.AddWithValue("@Email", email);

                using SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    userDTO = new UserDTO()
                    {
                        UserID = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Email = rdr.GetString(2)
                    };
                }
            }
            CloseConnect();
            return userDTO;
        }
    }
}
