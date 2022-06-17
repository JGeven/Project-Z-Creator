using System.Data.SqlClient;
using System.Web.Helpers;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Database
{
    public class UserSql : SqlConnect, IUserContainer
    {
        public UserSql()
        {
            Initialize();
        }

        public UserDto GetUserbyID(int userID)
        {
            try
            {
                OpenConnect();
                Cmd.CommandText = "SELECT * FROM [User] WHERE UserID = @UserID";
                Cmd.Parameters.AddWithValue("@UserID", userID);

                UserDto userDto = null;
                using SqlDataReader rdr = Cmd.ExecuteReader();

                while (rdr.Read())
                {
                    userDto = new UserDto
                    {
                        UserID = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Email = rdr.GetString(2),
                        Password = rdr.GetString(3),
                    };
                }
                return userDto;
            }
            catch (SqlException)
            {
                throw new Exception("No data could be found");
            }
            finally
            {
                CloseConnect();
            }
        }

        public bool EmailExist(string? email)
        {
            try
            {
                OpenConnect();
                Cmd.CommandText = "SELECT Count(1) FROM [User] WHERE Email = @Email";
                Cmd.Parameters.AddWithValue("@Email", email);

                int inUse = (int)Cmd.ExecuteScalar();

                if (inUse > 0)
                {
                    return true;
                }
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                CloseConnect();
            }
            
        }

        public bool RegisterUser(UserDto dto)
        {
            try
            {
                OpenConnect();
                Cmd.Parameters.Clear();
                Cmd.CommandText = "INSERT INTO [User] (Name, Email, Password) VALUES (@Name, @Email, @Password)";
                Cmd.Parameters.AddWithValue("@Name", dto.Name);
                Cmd.Parameters.AddWithValue("@Email", dto.Email);
                Cmd.Parameters.AddWithValue("@Password", Crypto.HashPassword(dto.Password));

                Cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                CloseConnect();
            }
        }

        private bool PasswordCheck(string? email, string? password)
        {
            OpenConnect();
            Cmd.Parameters.Clear();
            Cmd.CommandText = "SELECT Password FROM [User] WHERE Email = @Email";
            Cmd.Parameters.AddWithValue("@Email", email);

            var hashpassword = "";

            using SqlDataReader rdr = Cmd.ExecuteReader();

            while (rdr.Read())
            {
                hashpassword = rdr.GetString(0);
            }

            CloseConnect();

            if (Crypto.VerifyHashedPassword(hashpassword, password))
            {
                return true;
            }
            return false;
            
        }

        public UserDto Login(string? email, string? password)
        {
            try
            {
                UserDto userDto = null;
                if (PasswordCheck(email, password))
                {
                    OpenConnect();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "SELECT * FROM [User] WHERE Email = @Email";
                    Cmd.Parameters.AddWithValue("@Email", email);

                    using SqlDataReader rdr = Cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        userDto = new UserDto
                        {
                            UserID = rdr.GetInt32(0),
                            Name = rdr.GetString(1),
                            Email = rdr.GetString(2)
                        };
                    }
                }
                return userDto;
            }
            catch (SqlException)
            {
                throw new Exception("No data could be found");
            }
            finally
            {
                CloseConnect();
            }
            
        }

        public bool DeleteUser(int userID)
        {
            try
            {
                OpenConnect();

                Cmd.CommandText = "DELETE FROM [User] WHERE UserID = @UserID";
                Cmd.Parameters.AddWithValue("@UserID", userID);

                Cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                CloseConnect();
            }
        }
    }
}
