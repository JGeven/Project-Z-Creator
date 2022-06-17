using Project_Z_Logic;

namespace Project_Z_Presentation.Models
{
    public class OccupationViewModel
    {
        public int OccupationID { get; init; }
        public string? Name { get; init; }
        public int Cost { get; init; }

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
