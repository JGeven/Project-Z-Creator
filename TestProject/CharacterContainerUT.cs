﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface;
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
        CharacterDALStub stub = new CharacterDALStub();
        CharacterContainer container = new CharacterContainer(stub);
        List<Character> expected = new List<Character>();
        Character character = new Character();
        
        character.CharacterID = 420;
        character.Name = "test";
        character.Cost = 69;
        
        expected.Add(character);

        //Act
        List<Character> actual = container.GetCharacters();

        //Assert
        for (int i = 0; i <actual.Count; i++)
        {
            Assert.AreEqual(expected[i].CharacterID, actual[i].CharacterID);
            Assert.AreEqual(expected[i].Name, actual[i].Name);
            Assert.AreEqual(expected[i].Cost, actual[i].Cost);
        }
    }

}

