using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Creator.InterfaceLayer;

namespace Project_Z_Creator
{
    public class Occupations
    {
        public int ID { get; set; }   
        public string Name { get; set; }
        public int Cost { get; set; }

        public Occupations(OccupationDTO Occupation)
        {
            this.ID = Occupation.ID;
            this.Name = Occupation.Name;
            this.Cost = Occupation.Cost;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
