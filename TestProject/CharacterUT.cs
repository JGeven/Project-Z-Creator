using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using TestProject.Fakes;

namespace TestProject;

[TestClass]
public class UTCharacter
{

    [TestMethod] public void Test_ConvertOccupation()
    {
        //Arrange
        Character character = new Character();
        OccupationDTO dto = new OccupationDTO();

        character.occupationName = "Chef";
        character.occupationID = 1;

        string expectedName = "Chef";
        int expectedID = 1;

        //Act
        dto = character.ConvertOccupation();

        //Assert
        Assert.AreEqual(expectedName, dto.Name);
        Assert.AreEqual(expectedID, dto.ID);
    }
    
    [TestMethod] public void Test_ConvertUser()
    {
        //Arrange
        Character character = new Character();
        UserDTO dto = new UserDTO();

        character.userID = 1;
        
        int expectedID = 1;

        //Act
        dto = character.ConvertUser();

        //Assert
        Assert.AreEqual(expectedID, dto.UserID);
    }
    
    [TestMethod] public void Test_ToDO()
    {
        //Arrange
        Character character = new Character();
        CharacterDTO dto = new CharacterDTO();
        
        character.Name = "test persoon";
        character.Cost = 5;

        //Act
        dto = character.ToDTO();
        
        //Assert
        Assert.AreEqual(character.Name, dto.Name);
        Assert.AreEqual(character.Cost, dto.Cost);
    }
}
