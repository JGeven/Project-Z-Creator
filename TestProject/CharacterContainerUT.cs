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
    
    public class CharacterContainerUt
    {

        private ICharacterContainer _iCharacterContainer;

        [TestMethod] public void Test_GetCharacters()
        {
            //Arrange
            CharacterContainer container = new CharacterContainer(new CharacterDalStub());
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
    
        [TestMethod] public void Test_SaveChar()
        {
            //Arrange
            CharacterDalStub stub = new CharacterDalStub();
            CharacterContainer container = new CharacterContainer(stub);

            UserDto? user = new UserDto();
            user.UserID = 4;
        
            OccupationDto? occupations = new OccupationDto();
            occupations.OccupationID = 2;

            List<int> traits = new List<int>();
            int chef = 1;
            int smoker = 6;
        
            traits.Add(chef);
            traits.Add(smoker);

            int[]? arraytraits;
            arraytraits = traits.ToArray();
        
            Character character = new Character();
            character.CharacterID = 31;
            character.Name = "test123";
            character.Cost = 5;
            character.Occupation = occupations;
            character.Arraytraits = arraytraits;
            character.User = user;

            bool expected = true;

            //Act
            bool actual = container.SaveCharacter(character);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(character.CharacterID, stub.StubDto.CharacterID);
            Assert.AreEqual(character.Name, stub.StubDto.Name);
            Assert.AreEqual(character.Cost, stub.StubDto.Cost);
            Assert.AreEqual(character.Occupation.OccupationID, stub.StubDto.Occupations.OccupationID);
            Assert.AreEqual(character.Arraytraits, stub.StubDto.Arraytraits);
            Assert.AreEqual(character.User.UserID, stub.StubDto.User.UserID);
        }

        [TestMethod] public void Test_DeleteChar()
        {
            //Arrange
            CharacterDalStub stub = new CharacterDalStub();
            CharacterContainer container = new CharacterContainer(stub);
            bool expected;
            bool actual;

            Character character = new Character
            {
                CharacterID = 31,
            };

            expected = true;
            //Act
            actual = container.DeleteCharacter(character.CharacterID);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(character.CharacterID, stub.StubDto.CharacterID);
        
        }

        [TestMethod] public void Test_UpdateCharacter()
        {
            //Arrange
            CharacterDalStub stub = new CharacterDalStub();
            CharacterContainer container = new CharacterContainer(stub);
            bool expected = true;
        
            List<int> traits = new List<int>();
            int unlucky = 3;
            int fit = 8;
        
            traits.Add(fit);
            traits.Add(unlucky);

            int[]? arraytraits;
            arraytraits = traits.ToArray();

            OccupationDto? occupations = new OccupationDto();
            occupations.OccupationID = 2;
            occupations.Name = "Chef";

            UserDto? user = new UserDto();
            user.UserID = 5;
            
            Character character = new Character();
            character.CharacterID = 31;
            character.Name = "William James Charles";
            character.Cost = 14;
            character.Occupation = occupations;
            character.Arraytraits = arraytraits;
            character.User = user;

            //Act
            bool actual = container.UpdateCharacter(character);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(character.CharacterID, stub.StubDto.CharacterID);
            Assert.AreEqual(character.Name, stub.StubDto.Name);
            Assert.AreEqual(character.Cost, stub.StubDto.Cost);
            Assert.AreEqual(character.Occupation.OccupationID, stub.StubDto.Occupations.OccupationID);
            Assert.AreEqual(character.Arraytraits, stub.StubDto.Arraytraits);
            Assert.AreEqual(character.User.UserID, stub.StubDto.User.UserID);
        }

        [TestMethod] public void Test_GetCharacterbyID_True()
        {
            //Arrange
            CharacterDalStub stub = new CharacterDalStub();
            CharacterContainer container = new CharacterContainer(stub);
            Character expected = new Character();
            Character actual = new Character();
        
            OccupationDto? occupations = new OccupationDto
            {
                OccupationID = 2,
                Name = "Chef",
            };

            expected.CharacterID = 1;
            expected.Name = "test123";
            expected.Cost = 5;
            expected.Occupation = occupations;

            //Act
            actual = container.GetCharacterbyID(expected.CharacterID);
        
            //Assert
            Assert.AreEqual(expected.CharacterID, actual.CharacterID);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Cost, actual.Cost);
        }
    
        [TestMethod] public void Test_GetCharacterbyID_False()
        {
            //Arrange
            CharacterDalStub stub = new CharacterDalStub();
            CharacterContainer container = new CharacterContainer(stub);
            Character expected = new Character();
            Character actual = new Character();
        
            OccupationDto? occupations = new OccupationDto();
            occupations.OccupationID = 2;
            occupations.Name = "Chef";
        
            expected.CharacterID = 5;
            expected.Name = "test123";
            expected.Cost = 5;
            expected.Occupation = occupations;

            //Act
            //Act below by exceptioncheck
        
            //Assert
            Assert.ThrowsException<NullReferenceException>(() => container.GetCharacterbyID(expected.CharacterID));
        }

        [TestMethod] public void Test_GetCharacterbyUserID()
        {
            //Arrange 
            CharacterDalStub stub = new CharacterDalStub();
            CharacterContainer container = new CharacterContainer(stub);
            List<Character> expected = new List<Character>();
            List<Character> actual = new List<Character>();

            UserDto? user = new UserDto();
            user.UserID = 1;

            Character character = new Character();
            character.User = user;
        
            expected.Add(character);

            //Act
            actual = container.GetCharacterbyUserID(character.User.UserID);

            //Assert
            for (int i = 0; i <stub.StubDtOs.Count; i++)
            {
                Assert.AreEqual(character.User.UserID, actual[i].User.UserID);
            }
        }
    }
}

