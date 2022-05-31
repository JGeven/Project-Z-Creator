using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {
            
        }
        
        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public User(UserDTO dto)
        {
            this.UserID = dto.UserID;
            this.Name = dto.Name;
            this.Email = dto.Email;
            this.Password = dto.Password;
        }

        public UserDTO ToDTO()
        {
            UserDTO dto = new UserDTO();
            dto.UserID = this.UserID;
            dto.Name = this.Name;
            dto.Email = this.Email;
            dto.Password = this.Password;

            return dto;
        }
    }
}
