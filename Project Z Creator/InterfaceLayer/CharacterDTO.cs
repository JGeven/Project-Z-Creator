using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z_Creator.InterfaceLayer
{
    public class CharacterDTO
    {
        public int CharacterID;
        public string Name;
        public int Cost;
        public int Occupation;
        public string OccupationName;
        public string Trait;
        public List<Trait> Traits;
    }
}
