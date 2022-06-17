using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class OccupationContainer
    {
        IOccupationContainer _ioccupationContainer;

        public OccupationContainer(IOccupationContainer dal)
        {
            _ioccupationContainer = dal;
        }
         
        public List<Occupations> GetOccupations()
        {
            List<Occupations> occupations = new List<Occupations>(); 
            List<OccupationDto> list = _ioccupationContainer.GetOccupations();
            foreach (OccupationDto occupationDto in list)
            {
                Occupations newoccupation = new Occupations(occupationDto);
                occupations.Add(newoccupation);
            }
            return occupations;
        }

    }
}
