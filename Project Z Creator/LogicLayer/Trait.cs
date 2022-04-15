using Project_Z_Creator.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Creator.InterfaceLayer;

namespace Project_Z_Creator
{
    public class Trait
    {
        public int TraitID { get; set; }
        public string Name { get; }
        public int Cost { get; set; }
        public bool PosNeg { get; }

        public Trait(TraitDTO Traits)
        {
            this.TraitID = Traits.TraitID;
            this.Name = Traits.Name;
            this.Cost = Traits.Cost;
            this.PosNeg = Traits.PosNeg;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
