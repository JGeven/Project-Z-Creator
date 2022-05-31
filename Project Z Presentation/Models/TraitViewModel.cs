using Project_Z_Logic;

namespace Project_Z_Presentation.Models
{
    public class TraitViewModel
    {
        public int TraitID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public bool PosNeg { get; set; }

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
