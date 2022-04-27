using System.Collections.Generic;
using Project_Z_Interface;

namespace TestProject.Fakes
{
    public class TraitDALStub : ITraitsContainer
    {
        
        List<TraitDTO> list = new List<TraitDTO>();
        public List<TraitDTO> GetTraits()
        {
            TraitDTO dto = new TraitDTO();
            dto.TraitID = 1;
            dto.Name = "Lucky";
            dto.Cost = 12;
            
            list.Add(dto);
            return list;
        }
    }
}
