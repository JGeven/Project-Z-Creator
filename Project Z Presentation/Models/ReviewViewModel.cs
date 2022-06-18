using System.Security.Permissions;
using Project_Z_Logic;

namespace Project_Z_Presentation.Models
{
    public class ReviewViewModel
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        
        public int UserID { get; set; }
        public string UserName { get; set; }
        
        public int CharacterID { get; set; }

        public ReviewViewModel()
        {
            
        }
        
        public ReviewViewModel(Review review)
        {
            ReviewID = review.ReviewID;
            Rating = review.Rating;
            Comment = review.Comment;
        }
    }
}
