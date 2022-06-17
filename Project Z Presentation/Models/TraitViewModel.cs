using Project_Z_Logic;

namespace Project_Z_Presentation.Models
{
    public class TraitViewModel
    {
        public int TraitID { get; init; }
        public string? Name { get; init; }
        public int Cost { get; set; }
        public bool PosNeg { get; init; }

        public TraitViewModel()
        {
            
        }

        public TraitViewModel(Trait trait)
        {
            TraitID = trait.TraitID;
            Name = trait.Name;
            Cost = trait.Cost;
            PosNeg = trait.PosNeg;
        }
    }
}
