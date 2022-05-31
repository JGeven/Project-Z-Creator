using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Frameworks;
using Project_Z_Interface;

namespace TestProject.Fakes
{
    public class TraitDALStub : ITraitsContainer
    {
        public List<TraitDTO> GetTraits()
        {
            List<TraitDTO> list = new List<TraitDTO>();
            TraitDTO dto = new TraitDTO();
            dto.TraitID = 1;
            dto.Name = "Lucky";
            dto.Cost = 12;
            
            list.Add(dto);
            return list;
        }
    }
}
