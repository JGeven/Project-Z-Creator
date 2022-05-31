using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class UserContainer
    {
        private IUserContainer IUsercontainer;

        public UserContainer(IUserContainer IUsercontainer)
        {
            this.IUsercontainer = IUsercontainer;
        }

        public bool RegisterUser(User user)
        {
            if (IUsercontainer.EmailExist(user.Email))
            {
                return false;
            }
            else
            {
                UserDTO dto = user.ToDTO();
                IUsercontainer.RegisterUser(dto);
                return true;
            }
        }
        
        public User GetUserbyID(int userID)
        {
            UserDTO dto = IUsercontainer.GetUserbyID(userID);
            User user = new User(dto);
            return user;
        }

        public User Login(string email, string password)
        {
            UserDTO dto = IUsercontainer.Login(email, password);
            User user = new User(dto);
            return user;
        }
    }
}
