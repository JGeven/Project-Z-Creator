using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface.DTO;
using Project_Z_Logic;

namespace TestProject
{
    [TestClass]
    public class UserUt
    {
        [TestMethod] public void Test_ToDO()
        {
            //Arrange
            User user = new User();
            UserDto dto = new UserDto();

            user.Name = "Test Persoon";
            user.Email = "test@email.com";
            user.Password = "welkom";

            //Act
            dto = user.ToDto();
        
            //Assert
            Assert.AreEqual(user.Name, dto.Name);
            Assert.AreEqual(user.Email, dto.Email);
            Assert.AreEqual(user.Password, dto.Password);
        }
    }
}
