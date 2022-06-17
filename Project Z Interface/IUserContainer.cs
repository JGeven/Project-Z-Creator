using Project_Z_Interface.DTO;

namespace Project_Z_Interface
{
    public interface IUserContainer
    {
        public UserDto Login(string? email, string? password);
        public bool RegisterUser(UserDto dto);
        public bool EmailExist(string? email);
        public UserDto GetUserbyID(int userID);
        public bool DeleteUser(int userID);
    }
}
