using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class Trait
    {
        public int TraitID { get; }
        public string? Name { get; }
        public int Cost { get; }
        public bool PosNeg { get; }

        public Trait(TraitDto traits)
        {
            TraitID = traits.TraitID;
            Name = traits.Name;
            Cost = traits.Cost;
            PosNeg = traits.PosNeg;
        }
    }
}
