using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Creator.DatabaseLayer;

namespace Project_Z_Creator
{
    public class Occupations
    {
           
        public string Name { get; set; }
        public int Cost { get; set; }

        public Occupations(OccupationDTO Occupation)
        {
            this.Name = Occupation.Name;
            this.Cost = Occupation.Cost;
        }
    }
}
