using Project_Z_Interface.DTO;

namespace Project_Z_Interface
{
    public interface IReviewContainer
    {
        public bool CreateReview(ReviewDTO dto, int characterID, int userID);
    }
}
