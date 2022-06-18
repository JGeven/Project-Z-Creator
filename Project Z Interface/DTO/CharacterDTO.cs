namespace Project_Z_Interface.DTO
{
    public class CharacterDto
    {
        public int CharacterID;
        public string? Name;
        public int Cost;
        public OccupationDto? Occupations;
        public int[]? Arraytraits;
        public List<TraitDto>? Traits;
        public UserDto? User;
        public List<ReviewDTO> Reviews;
    }
}
