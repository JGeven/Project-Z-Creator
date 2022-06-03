using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Interface;

namespace Project_Z_Logic
{
    public class Occupations
    {
        public int ID { get; set; }   
        public string Name { get; set; }
        public int Cost { get; set; }

        public Occupations()
        {
            
        }
        
        public Occupations(OccupationDTO Occupation)
        {
            this.ID = Occupation.OccupationID;
            this.Name = Occupation.Name;
            this.Cost = Occupation.Cost;
        }
    }
}
