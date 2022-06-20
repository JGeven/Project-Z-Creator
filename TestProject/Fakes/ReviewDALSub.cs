using System.Collections.Generic;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace TestProject.Fakes
{
    public class ReviewDALSub : IReviewContainer
    {

        public ReviewDTO mockDTO = new ReviewDTO();
        public List<ReviewDTO> mockDTOs = new List<ReviewDTO>();

        public bool CreateReview(ReviewDTO dto, int characterID, int userID)
        {
            mockDTO = dto;
            return true;
        }
        public bool DeleteReview(int reviewID)
        {
            mockDTO.ReviewID = reviewID;
            return true;
        }
        public ReviewDTO GetReviewbyID(int reviewID)
        {
            ReviewDTO review1 = new ReviewDTO()
            {
                ReviewID = 1,
                Comment = "correct",
                Rating = 5,
            };
            
            ReviewDTO review2 = new ReviewDTO()
            {
                ReviewID = 2,
                Comment = "fouut",
                Rating = 2,
            };
            
            ReviewDTO review3 = new ReviewDTO()
            {
                ReviewID = 1,
                Comment = "nee",
                Rating = 3,
            };
            
            mockDTOs.Add(review1);
            mockDTOs.Add(review2);
            mockDTOs.Add(review3);

            mockDTO = mockDTOs.Find(review => review.ReviewID == reviewID);
            return mockDTO;
        }
        public bool UpdateReview(ReviewDTO dto)
        {
            mockDTO = dto;
            return true;
        }
    }
}
