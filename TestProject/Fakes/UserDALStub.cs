using System.Collections.Generic;
using System.Web.Helpers;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace TestProject.Fakes
{
    public class UserDalStub : IUserContainer
    {
        public UserDto StubDto = new UserDto();
        public List<UserDto> StubDtOs = new List<UserDto>();

        public bool PasswordCheck(string? email, string? password)
        {
            string newpassword = "welkom";
            string hashpassword = Crypto.HashPassword(password);
            
            if (Crypto.VerifyHashedPassword(hashpassword, password))
            {
                return true;
            }
            return false;
        }
        
        public UserDto Login(string? email, string? password)
        {
            UserDto user = new UserDto();
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
        public bool RegisterUser(UserDto dto)
        {
            StubDto = dto;
            return true;
        }
        public bool EmailExist(string? email)
        {
            StubDto.Email = email;
            
            UserDto user1 = new UserDto
            {
                Email = "test@email.com",
                Name = "test123",
                Password = "welkom"
            };
            
            UserDto user2 = new UserDto
            {
                Email = "ditisfout@email.com",
                Name = "test43",
                Password = "welkom"
            };
            
            UserDto user3 = new UserDto
            {
                Email = "nietgoed@email.com",
                Name = "test123",
                Password = "welkom"
            };
            StubDtOs.Add(user1);
            StubDtOs.Add(user2);
            StubDtOs.Add(user3);

            StubDto = StubDtOs.Find(user => user.Email == email);

            if (StubDto != null)
            {
                return true;
            }
            return false;
        }
        public UserDto GetUserbyID(int userID)
        {

            UserDto user1 = new UserDto
            {
                UserID = 1,
                Name = "Test",
                Email = "test@email.com",
                Password = "welkom"
            };
            
            UserDto user2 = new UserDto
            {
                UserID = 2,
                Name = "Test123",
                Email = "ditisfout@email.com",
                Password = "welkom"
            };
            
            UserDto user3 = new UserDto
            {
                UserID = 3,
                Name = "Test567",
                Email = "nietgoed@email.com",
                Password = "welkom"
            };
            
            StubDtOs.Add(user1);
            StubDtOs.Add(user2);
            StubDtOs.Add(user3);

            StubDto = StubDtOs.Find(user => user.UserID == userID);
            return StubDto;
        }

        public bool DeleteUser(int userID)
        {
            StubDto.UserID = userID;
            return true;
        }
    }
}
