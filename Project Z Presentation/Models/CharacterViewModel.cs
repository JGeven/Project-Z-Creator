namespace Project_Z_Presentation.Models
{
    public class CharacterViewModel
    {
        public int CharacterID { get; set; }
        public string? Name { get; set; }
        public int Cost { get; set; }
        public OccupationViewModel? Occupation { get; set; }
        public int[]? Arraytraits { get; set; }
        public List<TraitViewModel>? Traits { get; set; }
        public UserViewModel User { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }

        public int OccupationID { get; set; }
    }
}
