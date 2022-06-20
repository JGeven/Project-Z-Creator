using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using TestProject.Fakes;

namespace TestProject
{
    [TestClass]
    public class UserContainerUt
    {
        [TestMethod] public void Email_Exist_True()
        {
            //Arrange
            IUserContainer iContainer = new UserDalStub();
            
            bool expected;
            bool actual;

            User user = new User();
            user.Email = "test@email.com";

            expected = true;

            //Act
            actual = iContainer.EmailExist(user.Email);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void Test_GetUserbyID_True()
        {
            //Arrange 
            UserDalStub stub = new UserDalStub();
            UserContainer container = new UserContainer(stub);
            User actual = new User();

            User expected = new User();
            expected.UserID = 1;
            expected.Name = "Test";
            expected.Email = "test@email.com";
            expected.Password = "welkom";
            
            //Act
            actual = container.GetUserbyID(expected.UserID);

            //Assert
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
        }
        
        [TestMethod] public void Test_GetUserbyID_False()
        {
            //Arrange 
            UserContainer container = new UserContainer(new UserDalStub());

            User expected = new User
            {
                UserID = 5,
                Name = "Test",
                Email = "test@email.com",
                Password = "welkom",
            };

            //Act
            //Act is below by ExceptionCheck

            //Assert
            Assert.ThrowsException<NullReferenceException>(() => container.GetUserbyID(expected.UserID));
        }

        [TestMethod] public void Test_RegisterUser_True()
        {
            //Arrange
            IUserContainer iContainer = new UserDalStub();
            bool expected;
            bool actual;

            UserDto user = new UserDto();
            user.Name = "Test";
            user.Email = "test@email.com";
            user.Password = "welkom";

            expected = true;

            //Act
            actual = iContainer.RegisterUser(user);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void Test_Login_True()
        {
            //Arrange
            UserContainer container = new UserContainer(new UserDalStub());
            User actual = new User();

            User expected = new User();
            expected.Email = "test@email.com";
            expected.Password = "welkom";
            
            //Act
            actual = container.Login(expected.Email, expected.Password);

            //Assert
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
        }
    }
}
