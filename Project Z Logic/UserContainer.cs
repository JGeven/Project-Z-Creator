using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class UserContainer
    {
        private readonly IUserContainer _usercontainer;

        public UserContainer(IUserContainer usercontainer)
        {
            _usercontainer = usercontainer;
        }

        public bool RegisterUser(User user)
        {
            if (_usercontainer.EmailExist(user.Email))
            {
                return false;
            }
            UserDto dto = user.ToDto();
            _usercontainer.RegisterUser(dto);
            return true;
            
        }
        
        public User GetUserbyID(int userID)
        {
            UserDto dto = _usercontainer.GetUserbyID(userID);
            User user = new User(dto);
            return user;
        }

        public User Login(string? email, string? password)
        {
            UserDto dto = _usercontainer.Login(email, password);
            if (dto == null)
            {
                return null;
            }
            return new User(dto);
        }

        public void DeleteUser(int userID)
        {
            _usercontainer.DeleteUser(userID);
        }
    }
}
