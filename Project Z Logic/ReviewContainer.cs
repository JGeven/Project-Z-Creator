using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class ReviewContainer
    {
        IReviewContainer _iratingContainer;

        public ReviewContainer(IReviewContainer dal)
        {
            _iratingContainer = dal;
        }
        
        public bool CreateReview(Review review, int characterID, int userID)
        {
            ReviewDTO reviewDto = review.ToDO();
            return _iratingContainer.CreateReview(reviewDto, characterID, userID);
        }

        public bool DeleteReview(int reviewID)
        {
            return _iratingContainer.DeleteReview(reviewID);
        }

        public bool UpdateReview(Review review)
        {
            ReviewDTO dto = review.ToDO();
            return _iratingContainer.UpdateReview(dto);
        }

        public Review GetReviewbyID(int reviewID)
        {
            ReviewDTO dto = _iratingContainer.GetReviewbyID(reviewID);
            Review review = new Review(dto);

            return review;
        }
    }
}
