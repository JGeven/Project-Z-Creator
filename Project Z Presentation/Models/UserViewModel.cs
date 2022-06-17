namespace Project_Z_Presentation.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public UserViewModel()
        {
            
        }
        
        public UserViewModel(int userID, string? name, string? email, string? password)
        {
            UserID = userID;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
