using Project_Z_Logic;

namespace Project_Z_Presentation.Models
{
    public class OccupationViewModel
    {
        public int OccupationID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public OccupationViewModel()
        {
            
        }
        
        public OccupationViewModel(Occupations occupations)
        {
            OccupationID = occupations.ID;
            Name = occupations.Name;
            Cost = occupations.Cost;
        }
    }
}
