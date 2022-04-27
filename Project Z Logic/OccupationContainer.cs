using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Interface;

namespace Project_Z_Logic
{
    public class OccupationContainer
    {
        IOccupationContainer ioccupationContainer;

        public OccupationContainer(IOccupationContainer dal)
        {
            ioccupationContainer = dal;
        }
         
        public List<Occupations> GetOccupations()
        {
            List<Occupations> Occupations = new List<Occupations>(); 
            List<OccupationDTO> list = ioccupationContainer.GetOccupations();
            foreach (OccupationDTO occupations in list)
            {
                Occupations newoccupation = new Occupations(occupations);
                Occupations.Add(newoccupation);
            }
            return Occupations;
        }

    }
}
