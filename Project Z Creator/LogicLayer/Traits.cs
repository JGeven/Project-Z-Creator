using Project_Z_Creator.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z_Creator
{
    public class Traits
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public Traits(PosTraitsDTO Trait)
        {
            this.Name = Trait.Name;
            this.Cost = Trait.Cost;
        }

        public Traits(NegTraitsDTO Trait)
        {
            this.Name = Trait.Name;
            this.Cost = Trait.Cost;
        }
    }
}
