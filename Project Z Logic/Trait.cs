using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Interface;

namespace Project_Z_Logic
{
    public class Trait
    {
        public int TraitID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public bool PosNeg { get; }

        public Trait(TraitDTO Traits)
        {
            this.TraitID = Traits.TraitID;
            this.Name = Traits.Name;
            this.Cost = Traits.Cost;
            this.PosNeg = Traits.PosNeg;
        }
    }
}
