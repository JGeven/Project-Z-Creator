using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class Review
    {
        public int ReviewID { get; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public Review()
        {
            
        }

        public Review(int rating, string comment)
        {
            Rating = rating;
            Comment = comment;
        }
        
        public Review(int reviewID, int rating, string comment)
        {
            ReviewID = reviewID;
            Rating = rating;
            Comment = comment;
        }

        public Review(ReviewDTO dto)
        {
            ReviewID = dto.ReviewID;
            Rating = dto.Rating;
            Comment = dto.Comment;
        }

        public ReviewDTO ToDO()
        {
            ReviewDTO dto = new ReviewDTO()
            {
                ReviewID = ReviewID,
                Rating = Rating,
                Comment = Comment,
            };
            return dto;
        }
    }
}
