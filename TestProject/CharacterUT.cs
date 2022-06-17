using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface.DTO;
using Project_Z_Logic;

namespace TestProject
{
    [TestClass]
    public class UtCharacter
    {
        [TestMethod] public void Test_ToDO()
        {
            //Arrange
            Character character = new Character();
            CharacterDto dto = new CharacterDto();
        
            character.Name = "test persoon";
            character.Cost = 5;

            //Act
            dto = character.ToDto();
        
            //Assert
            Assert.AreEqual(character.Name, dto.Name);
            Assert.AreEqual(character.Cost, dto.Cost);
        }
    }
}
