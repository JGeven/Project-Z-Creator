using System.Collections.Generic;
using Project_Z_Interface;

namespace TestProject.Fakes
{
    public class OccupationDALStub : IOccupationContainer
    {
        
        List<OccupationDTO> list = new List<OccupationDTO>();
        public List<OccupationDTO> GetOccupations()
        {
            OccupationDTO dto = new OccupationDTO();
            dto.OccupationID = 1;
            dto.Name = "Chef";
            dto.Cost = 12;

            list.Add(dto);
            return list;
        }
    }
}
