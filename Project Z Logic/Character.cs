using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class Character
    {
        public int CharacterID { get; set; }
        public string? Name { get; set; }
        public int Cost { get; set; }
        public OccupationDto? Occupation { get; set; }
        public int[]? Arraytraits { get; set; }
        public List<TraitDto>? Traits { get; set; }
        public UserDto? User { get; set; }
        public List<ReviewDTO> Reviews { get; set; }

        ICharacterContainer _character;

        public Character(ICharacterContainer dal)
        {
            _character = dal;
        }

        public Character()
        {
            
        }
        
        public Character(CharacterDto character)
        {
            CharacterID = character.CharacterID;
            Name = character.Name;
            Cost = character.Cost;
            Occupation = character.Occupations;
            Traits = character.Traits;
            Arraytraits = character.Arraytraits;
            User = character.User;
            Reviews = character.Reviews;
        }

        public Character(string? name, int cost, int occupationID, int[]? traits, int userID)
        {
            Name = name;
            Cost = cost;
            Occupation = new OccupationDto
            {
                OccupationID = occupationID,
            };
            User = new UserDto
            {
                UserID = userID,
            };
            Arraytraits = traits;
        }
        
        public Character(int characterID,string? name, int cost, int occupationID, int[]? traits, int userID)
        {
            CharacterID = characterID;
            Name = name;
            Cost = cost;
            Occupation = new OccupationDto
            {
                OccupationID = occupationID,
            };
            User = new UserDto
            {
                UserID = userID,
            };
            Arraytraits = traits;
        }

        public CharacterDto ToDto()
        {
            CharacterDto dto = new CharacterDto
            {
                CharacterID = CharacterID,
                Name = Name,
                Cost = Cost,
                Occupations = Occupation,
                Traits = Traits,
                Arraytraits = Arraytraits,
                User = User,
            };
            return dto;
        }
    }
}
