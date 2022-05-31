using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Frameworks;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace TestProject.Fakes
{
    public class UserDALStub : IUserContainer
    {
        public UserDTO Login(string email, string password)
        {
            return null;
        }
        public bool RegisterUser(UserDTO dto)
        {
            return false;
        }
        public bool EmailExist(string email)
        {
            UserDTO dto = new UserDTO();
            dto.Email = "test@email.com";
            return true;
        }
        public UserDTO GetUserbyID(int userID)
        {
            return null;
        }
    }
}
