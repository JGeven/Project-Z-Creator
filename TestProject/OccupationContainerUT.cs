using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;
using TestProject.Fakes;

namespace TestProject
{
    [TestClass]

    public class OccupationContainerUt
    {

        private IOccupationContainer _iOccupationContainer;

        [TestMethod] public void Test_GetOccupations()
        {
            //Arrange
            OccupationDalStub stub = new OccupationDalStub();
            OccupationDto occupation = new OccupationDto();
            OccupationContainer container = new OccupationContainer(stub);
            List<OccupationDto> expected = new List<OccupationDto>();
        
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
}
