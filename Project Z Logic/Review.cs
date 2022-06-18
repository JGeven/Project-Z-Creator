using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class Review
    {
        public int ReviewID { get; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public Review(int rating, string comment)
        {
            Rating = rating;
            Comment = comment;
        }

        public ReviewDTO ToDO()
        {
            ReviewDTO dto = new ReviewDTO()
            {
                Rating = Rating,
                Comment = Comment,
            };
            return dto;
        }
    }
}
