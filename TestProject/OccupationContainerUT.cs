using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using TestProject.Fakes;

namespace TestProject;

[TestClass]

public class OccupationContainerUT
{

    private IOccupationContainer iOccupationContainer;

    [TestMethod] public void Test_GetOccupations()
    {
        //Arrange
        OccupationDALStub stub = new OccupationDALStub();
        OccupationDTO occupation = new OccupationDTO();
        OccupationContainer container = new OccupationContainer(stub);
        List<OccupationDTO> expected = new List<OccupationDTO>();
        
        occupation.OccupationID = 1;
        occupation.Name = "Chef";
        occupation.Cost = 12;
        
        expected.Add(occupation);

        //Act
        List<Occupations> actual = container.GetOccupations();
        
        //Assert
        Assert.AreEqual(expected.Count, actual.Count);

        for (int i = 0; i <actual.Count; i++)
        {
            Assert.AreEqual(expected[i].OccupationID, actual[i].ID);
            Assert.AreEqual(expected[i].Name, actual[i].Name);
            Assert.AreEqual(expected[i].Cost, actual[i].Cost);
        }
        }
}
