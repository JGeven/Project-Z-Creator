using System.Collections.Generic;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace TestProject.Fakes
{
    public class TraitDalStub : ITraitsContainer
    {
        public List<TraitDto> GetTraits()
        {
            List<TraitDto> list = new List<TraitDto>();
            TraitDto dto = new TraitDto();
            dto.TraitID = 1;
            dto.Name = "Lucky";
            dto.Cost = 12;
            
            list.Add(dto);
            return list;
        }
    }
}
