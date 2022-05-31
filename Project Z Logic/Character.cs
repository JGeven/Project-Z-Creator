using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class Character
    {
        public int CharacterID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public OccupationDTO Occupation { get; set; }
        public int[] arraytraits { get; set; }
        public List<TraitDTO> Traits { get; set; }
        public UserDTO User { get; set; }

        ICharacterContainer ICharacter;
        
        //Ready for convert
        public int occupationID;
        public string occupationName;
        public int userID;

        public Character(ICharacterContainer dal)
        {
            ICharacter = dal;
        }

        public Character()
        {
            
        }
        
        public Character(CharacterDTO Character)
        {
            this.CharacterID = Character.CharacterID;
            this.Name = Character.Name;
            this.Cost = Character.Cost;
            this.Occupation = Character.Occupations;
            this.Traits = Character.Traits;
            this.arraytraits = Character.arraytraits;
            this.User = Character.User;

        }

        public Character(string name, int cost, int occupationID, int[] traits, int userID)
        {
            this.Name = name;
            this.Cost = cost;
            this.occupationID = occupationID;
            this.arraytraits = traits;
            this.userID = userID;

        }
        
        public OccupationDTO ConvertOccupation()
        {
            OccupationDTO dto = new OccupationDTO();
            dto.ID = occupationID;
            dto.Name = occupationName;
            return dto;
        }

        public UserDTO ConvertUser()
        {
            UserDTO dto = new UserDTO();
            dto.UserID = userID;
            return dto;
        }
        
        public CharacterDTO ToDTO()
        {
            CharacterDTO DTO = new CharacterDTO();
            DTO.CharacterID = CharacterID;
            DTO.Name = Name;
            DTO.Cost = Cost;
            DTO.Occupations = ConvertOccupation();
            DTO.Traits = Traits;
            DTO.arraytraits = arraytraits;
            DTO.User = ConvertUser();
            return DTO;
        }
    }
}
