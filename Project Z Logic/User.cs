using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class User
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public User()
        {
            
        }
        
        public User(string? name, string? email, string? password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public User(UserDto dto)
        {
            UserID = dto.UserID;
            Name = dto.Name;
            Email = dto.Email;
            Password = dto.Password;
        }

        public UserDto ToDto()
        {
            UserDto dto = new UserDto
            {
                UserID = UserID,
                Name = Name,
                Email = Email,
                Password = Password,
            };

            return dto;
        }
    }
}
