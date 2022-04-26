using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z_Interface.DTO
{
    public class CharacterDTO
    {
        public int CharacterID;
        public string Name;
        public int Cost;
        public OccupationDTO Occupations;
        public List<TraitDTO> Traits;
    }
}
