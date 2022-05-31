using Project_Z_Interface.DTO;

namespace Project_Z_Interface
{
    public interface IUserContainer
    {
        public UserDTO Login(string email, string password);
        public bool RegisterUser(UserDTO dto);
        public bool EmailExist(string email);
        public UserDTO GetUserbyID(int userID);
    }
}
