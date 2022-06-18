using Project_Z_Interface.DTO;

namespace Project_Z_Interface
{
    public interface IReviewContainer
    {
        public bool CreateReview(ReviewDTO dto, int characterID, int userID);
        public bool DeleteReview(int reviewID);
        public ReviewDTO GetReviewbyID(int reviewID);
        public bool UpdateReview(ReviewDTO dto);
    }
}
