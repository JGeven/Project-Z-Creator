using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using TestProject.Fakes;

namespace TestProject;

[TestClass]
public class UTCharacter
{

    private ICharacter iCharacter;
    
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
    
    [TestMethod] public void Test_ToDO()
    {
        //Arrange
        Character character = new Character();
        CharacterDTO dto = new CharacterDTO();
        
        character.CharacterID = 31;
        character.Name = "Jesse Leppens";
        character.Cost = 5;
        character.Occupation = null;
        character.Traits = null;

        string expected = "Jesse Leppens";
        //Act
        
        dto = character.ToDTO();
        
        //Assert
        Assert.AreEqual(expected,dto.Name);
    }

    [TestMethod] public void Test_SaveChar()
    {
        //Arrange
        CharacterDALStub stub = new CharacterDALStub();
        
        int characterID = 31;
        string name = "Jesse Leppens";
        int cost = 5;
        
        bool expected = true;

        //Act
        Character character = new Character(characterID, name, cost, stub);
        bool actual = character.SaveChar();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test_DeleteChar()
    {
        //Arrange
        CharacterDALStub stub = new CharacterDALStub();
        
        int characterID = 31;
        string name = "Jesse Leppens";
        int cost = 5;
        
        bool expected = true;

        //Act
        Character character = new Character(characterID, name, cost, stub);
        bool actual = character.DeleteChar();

        //Assert
        Assert.AreEqual(expected, actual);
    }
}
