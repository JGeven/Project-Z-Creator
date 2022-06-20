using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using TestProject.Fakes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class ReviewContainerUT
    {

        [TestMethod] public void Test_CreateReview()
        {
            //Arrange
            ReviewDALSub stub = new ReviewDALSub();
            ReviewContainer container = new ReviewContainer(stub);
            
            bool expected = true;

            Review review = new Review()
            {
                Rating = 5,
                Comment = "Test",
            };

            int characterID = 5;
            int userID = 2;
            
            //Act
            bool actual = container.CreateReview(review, characterID, userID);

            //Assert
            Assert.AreEqual(expected,actual);
            Assert.AreEqual(review.Rating, stub.mockDTO.Rating);
            Assert.AreEqual(review.Comment, stub.mockDTO.Comment);
        }

        [TestMethod] public void Test_DeleteReview()
        {
            //Arrange
            ReviewDALSub stub = new ReviewDALSub();
            ReviewContainer container = new ReviewContainer(stub);
            
            bool expected = true;

            int reviewID = 5;

            //Act
            bool actual = container.DeleteReview(reviewID);

            //Assert
            Assert.AreEqual(expected,actual);
            Assert.AreEqual(reviewID, stub.mockDTO.ReviewID);
        }

        [TestMethod] public void Test_UpdateReview()
        {
            //Arrange
            ReviewDALSub stub = new ReviewDALSub();
            ReviewContainer container = new ReviewContainer(stub);
            
            bool expected = true;

            Review review = new Review()
            {
                Rating = 5,
                Comment = "Test",
            };

            //Act
            bool actual = container.UpdateReview(review);

            //Assert
            Assert.AreEqual(expected,actual);
            Assert.AreEqual(review.Rating, stub.mockDTO.Rating);
            Assert.AreEqual(review.Comment, stub.mockDTO.Comment);
        }

        [TestMethod] public void Test_GetReviewbyID()
        {
            //Arrange
            ReviewDALSub stub = new ReviewDALSub();
            ReviewContainer container = new ReviewContainer(stub);

            ReviewDTO review = new ReviewDTO()
            {
                ReviewID = 1,
                Comment = "correct",
                Rating = 5,
            };

            //Act
            Review actual = container.GetReviewbyID(review.ReviewID);

            //Assert
            Assert.AreEqual(review.ReviewID, actual.ReviewID);
            Assert.AreEqual(review.Rating, actual.Rating);
            Assert.AreEqual(review.Comment, actual.Comment);
        }
    }
}
