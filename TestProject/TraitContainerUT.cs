﻿using System;
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
        TraitDALStub stub = new TraitDALStub();
        TraitDTO trait = new TraitDTO();
        TraitsContainer container = new TraitsContainer(stub);
        List<TraitDTO> expected = new List<TraitDTO>();
        
        trait.TraitID = 1;
        trait.Name = "Lucky";
        trait.Cost = 12;
        
        expected.Add(trait);

        //Act
        List<Trait> actual = container.GetTraits();
        
        //Assert
        Assert.AreEqual(expected.Count, actual.Count);
    }
}


