using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using TestProject.Fakes;

namespace TestProject;

[TestClass] 
    
public class CharacterContainerUT
{

    private ICharacterContainer iCharacterContainer;

    [TestMethod] public void Test_GetCharacters()
    {
        //Arrange
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());
        List<Character> expected = new List<Character>();
        List<Character> actual = new List<Character>();

        Character character = new Character();
        character.CharacterID = 420;
        character.Name = "test";
        character.Cost = 69;
        
        expected.Add(character);

        //Act
        actual = container.GetCharacters();

        //Assert
        for (int i = 0; i <actual.Count; i++)
        {
            Assert.AreEqual(expected[i].CharacterID, actual[i].CharacterID);
            Assert.AreEqual(expected[i].Name, actual[i].Name);
            Assert.AreEqual(expected[i].Cost, actual[i].Cost);
        }
    }
    
    [TestMethod] public void Test_SaveChar_True()
    {
        //Arrange
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());
        
        int characterID = 31;
        string name = "Jesse Leppens";
        int cost = 5;
        int occupationID = 2;
        int userID = 4;
        
        List<int> traits = new List<int>();
        int chef = 1;
        int smoker = 6;
        
        traits.Add(chef);
        traits.Add(smoker);

        int[] arraytraits;
        arraytraits = traits.ToArray();
        
        bool expected = true;

        //Act
        Character character = new Character(name, cost, occupationID, arraytraits, userID);
        bool actual = container.SaveCharacter(character);

        //Assert
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod] public void Test_SaveChar_False()
    {
        //Arrange
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());
        
        int characterID = 31;
        string name = "Test";
        int cost = 5;
        int occupationID = 2;
        int userID = 4;
        
        List<int> traits = new List<int>();
        int chef = 1;
        int smoker = 6;
        
        traits.Add(chef);
        traits.Add(smoker);

        int[] arraytraits;
        arraytraits = traits.ToArray();
        
        bool expected = false;

        //Act
        Character character = new Character(name, cost, occupationID, arraytraits, userID);
        bool actual = container.SaveCharacter(character);

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test_DeleteChar_True()
    {
        //Arrange
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());
        bool expected = true;

        int characterID = 31;

        //Act
        bool actual = container.DeleteCharacter(characterID);

        //Assert
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod] public void Test_DeleteChar_False()
    {
        //Arrange
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());

        int characterID = 64;
        
        bool expected = false;

        //Act
        bool actual = container.DeleteCharacter(characterID);

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test_UpdateCharacter_True()
    {
        //Arrange
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());
        bool expected = true;
        
        List<int> traits = new List<int>();
        int unlucky = 3;
        int fit = 8;
        
        traits.Add(fit);
        traits.Add(unlucky);

        int[] arraytraits;
        arraytraits = traits.ToArray();

        OccupationDTO occupations = new OccupationDTO();
        occupations.ID = 2;
        occupations.Name = "Chef";
            
        Character character = new Character();
        character.Name = "William James Charles";
        character.Cost = 14;
        character.Occupation = occupations;
        character.arraytraits = arraytraits;

        int characterID = 31;
        
        //Act
        bool actual = container.UpdateCharacter(character, characterID);

        //Assert
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod] public void Test_UpdateCharacter_False()
    {
        //Arrange
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());

        List<int> traits = new List<int>();
        int unlucky = 3;
        int fit = 8;
        
        traits.Add(fit);
        traits.Add(unlucky);

        int[] arraytraits;
        arraytraits = traits.ToArray();

        OccupationDTO occupations = new OccupationDTO();
        occupations.ID = 2;
        occupations.Name = "Chef";
            
        Character character = new Character();
        character.Name = "William James Charles";
        character.Cost = 14;
        character.Occupation = occupations;
        character.arraytraits = arraytraits;

        int characterID = 65;
        
        bool expected = false;
        
        //Act
        bool actual = container.UpdateCharacter(character, characterID);

        //Assert
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod] public void Test_GetCharacterbyID_True()
    {
        //Arrange
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());
        Character expected = new Character();
        Character actual = new Character();
        
        OccupationDTO occupations = new OccupationDTO();
        occupations.ID = 2;
        occupations.Name = "Chef";
        
        List<int> traits = new List<int>();
        int chef = 1;
        int smoker = 6;
        
        traits.Add(chef);
        traits.Add(smoker);

        int[] arraytraits;
        arraytraits = traits.ToArray();
        
        expected.CharacterID = 31;
        expected.Name = "Jesse Leppens";
        expected.Cost = 5;
        expected.Occupation = occupations;
        expected.arraytraits = arraytraits;

        int characterID = 31;
        
        //Act
        actual = container.GetCharacterbyID(characterID);
        
        //Assert
        
        Assert.AreEqual(expected.CharacterID, actual.CharacterID);
        Assert.AreEqual(expected.Name, actual.Name);
        Assert.AreEqual(expected.Cost, actual.Cost);
        Assert.AreEqual(expected.Occupation.ID, actual.Occupation.ID);
        CollectionAssert.AreEqual(expected.arraytraits, actual.arraytraits);
    }
    
    [TestMethod] public void Test_GetCharacterbyID_False()
    {
        //Arrange
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());
        Character expected = new Character();
        OccupationDTO occupations = new OccupationDTO();

        occupations.ID = 2;
        occupations.Name = "Chef";
        
        List<int> traits = new List<int>();
        int chef = 1;
        int smoker = 6;
        
        traits.Add(chef);
        traits.Add(smoker);

        int[] arraytraits;
        arraytraits = traits.ToArray();
        
        expected.CharacterID = 31;
        expected.Name = "Jesse Leppens";
        expected.Cost = 5;
        expected.Occupation = occupations;
        expected.arraytraits = arraytraits;

        int characterID = 65;
        
        //Act
        //Act is below with exceptioncheck
        
        //Assert
        Assert.ThrowsException<NullReferenceException>(() => container.GetCharacterbyID(characterID));

    }

    [TestMethod] public void Test_GetCharacterbyUserID_True()
    {
        //Arrange 
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());
        List<Character> expected = new List<Character>();
        List<Character> actual = new List<Character>();

        Random random = new Random();

        UserDTO dto = new UserDTO();
        dto.UserID = random.Next(1, 10);

        int userID = dto.UserID;

        Character character = new Character();
        character.User = dto;
        
        expected.Add(character);

        //Act
        actual = container.GetCharacterbyUserID(userID);

        //Assert
        for (int i = 0; i <actual.Count; i++)
        {
            Assert.AreEqual(userID, actual[i].User.UserID);
        }
    }
    
    [TestMethod] public void Test_GetCharacterbyUserID_False()
    {
        //Arrange 
        CharacterContainer container = new CharacterContainer(new CharacterDALStub());
        List<Character> expected = new List<Character>();
        List<Character> actual = new List<Character>();

        UserDTO dto = new UserDTO();
        dto.UserID = 9658;

        int userID = dto.UserID;

        Character character = new Character();
        character.User = dto;
        
        expected.Add(character);

        //Act
        actual = container.GetCharacterbyUserID(userID);

        //Assert
        for (int i = 0; i <actual.Count; i++)
        {
            Assert.AreNotEqual(userID, actual[i].User.UserID);
        }
    }
}

