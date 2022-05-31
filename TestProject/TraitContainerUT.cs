using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using TestProject.Fakes;

namespace TestProject;

[TestClass]

public class TraitContainerUT
{

    private ITraitsContainer iTraitsContainer;

    [TestMethod] public void Test_GetTraits()
    {
        //Arrange
        TraitsContainer container = new TraitsContainer(new TraitDALStub());
        List<TraitDTO> expected = new List<TraitDTO>();
        TraitDTO trait = new TraitDTO();
        
        trait.TraitID = 1;
        trait.Name = "Lucky";
        trait.Cost = 12;
        
        expected.Add(trait);

        //Act
        List<Trait> actual = container.GetTraits();
        
        //Assert
        for (int i = 0; i <actual.Count; i++)
        {
            Assert.AreEqual(expected[i].TraitID, actual[i].TraitID);
            Assert.AreEqual(expected[i].Name, actual[i].Name);
            Assert.AreEqual(expected[i].Cost, actual[i].Cost);
        }
    }
}


