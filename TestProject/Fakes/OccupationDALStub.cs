using System.Collections.Generic;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace TestProject.Fakes
{
    public class OccupationDalStub : IOccupationContainer
    {
        
        List<OccupationDto> _list = new List<OccupationDto>();
        public List<OccupationDto> GetOccupations()
        {
            OccupationDto dto = new OccupationDto();
            dto.OccupationID = 1;
            dto.Name = "Chef";
            dto.Cost = 12;

            _list.Add(dto);
            return _list;
        }
    }
}
