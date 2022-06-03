using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using TestProject.Fakes;

namespace TestProject
{
    [TestClass]
    public class UserContainerUT
    {
        [TestMethod] public void Email_Exist_True()
        {
            //Arrange
            IUserContainer iContainer = new UserDALStub();
            
            bool expected;
            bool actual;

            string email = "test@email.com";

            expected = true;

            //Act
            actual = iContainer.EmailExist(email);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod] public void Email_Exist_False()
        {
            //Arrange
            IUserContainer iContainer = new UserDALStub();
            
            bool expected;
            bool actual;

            string email = "ditgaatfout@email.com";

            expected = false;

            //Act
            actual = iContainer.EmailExist(email);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod] public void Test_GetUserbyID_True()
        {
            //Arrange 
            UserContainer container = new UserContainer(new UserDALStub());
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
            UserContainer container = new UserContainer(new UserDALStub());
            User actual = new User();

            User expected = new User();
            expected.UserID = 5;
            expected.Name = "Test";
            expected.Email = "test@email.com";
            expected.Password = "welkom";
            
            //Act
            //Act is below by ExceptionCheck

            //Assert
            Assert.ThrowsException<NullReferenceException>(() => container.GetUserbyID(expected.UserID));
        }

        [TestMethod] public void Test_RegisterUser_True()
        {
            //Arrange
            IUserContainer iContainer = new UserDALStub();
            bool expected;
            bool actual;

            UserDTO user = new UserDTO();
            user.Name = "Test";
            user.Email = "test@email.com";
            user.Password = "welkom";

            expected = true;

            //Act
            actual = iContainer.RegisterUser(user);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod] public void Test_RegisterUser_False()
        {
            //Arrange
            IUserContainer iContainer = new UserDALStub();
            bool expected;
            bool actual;

            UserDTO user = new UserDTO();
            user.Name = "ndawd";
            user.Email = "test@email.com";
            user.Password = "welkom";

            expected = false;

            //Act
            actual = iContainer.RegisterUser(user);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void Test_Login_True()
        {
            //Arrange
            UserContainer container = new UserContainer(new UserDALStub());
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
        
        [TestMethod] public void Test_Login_False()
        {
            //Arrange
            UserContainer container = new UserContainer(new UserDALStub());
            User actual = new User();

            User expected = new User();
            expected.Email = "ditgaatfout@email.com";
            expected.Password = "welkom";
            

            //Act
            //Act is below with ExceptionCheck

            //Assert
            Assert.ThrowsException<NullReferenceException>(() => container.Login(expected.Email, expected.Password));
        }
    }
}
