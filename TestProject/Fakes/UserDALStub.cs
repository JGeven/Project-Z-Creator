using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Frameworks;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using System.Web.Helpers;

namespace TestProject.Fakes
{
    public class UserDALStub : IUserContainer
    {
        public bool PasswordCheck(string email, string password)
        {
            string newpassword = "welkom";
            string hashpassword = Crypto.HashPassword(password);
            
            if (Crypto.VerifyHashedPassword(hashpassword, password))
            {
                return true;
            }
            return false;
        }
        
        public UserDTO Login(string email, string password)
        {
            UserDTO user = new UserDTO();
            user.Email = "test@email.com";
            user.Password = "welkom";

            if (PasswordCheck(email, password))
            {
                if (user.Email == email)
                {
                    return user;
                }
                return null;
            }
            return null;
        }
        public bool RegisterUser(UserDTO dto)
        {
            UserDTO user = new UserDTO();
            user.Name = "Test";
            user.Email = "test@email.com";
            user.Password = "welkom";

            if (user.Name == dto.Name)
            {
                return true;
            }
            return false;
        }
        public bool EmailExist(string email)
        {
            UserDTO dto = new UserDTO();
            dto.Email = "test@email.com";
            
            if (dto.Email == email)
            {
                return true;
            }
            return false;
        }
        public UserDTO GetUserbyID(int userID)
        {
            
            UserDTO user = new UserDTO();
            user.UserID = 1;
            user.Name = "Test";
            user.Email = "test@email.com";
            user.Password = "welkom";
            
            if (user.UserID == userID)
            {
                return user;
            }
            return null;
        }
    }
}
