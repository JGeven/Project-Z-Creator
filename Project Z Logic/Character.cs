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
        public List<TraitDTO> Traits { get; set; }

        ICharacter ICharacter;

        public int occupationID;
        public string occupationName;

        public Character(ICharacter dal)
        {
            ICharacter = dal;
        }

        public Character(CharacterDTO Character)
        {
            this.CharacterID = Character.CharacterID;
            this.Name = Character.Name;
            this.Cost = Character.Cost;
            this.Occupation = Character.Occupations;
            this.Traits = Character.Traits;

        }
        public Character()
        {
            this.Cost = 8;
        }

        public Character(int characterid, ICharacter dal)
        {
            this.CharacterID = characterid;
            this.ICharacter = dal;
        }

        public Character(string name, int cost, Occupations occupation, List<TraitDTO> traits, ICharacter dal)
        {
            this.Name = name;  
            this.Cost = cost;
            this.occupationName = occupation.Name;
            this.occupationID = occupation.ID;
            this.Traits = traits;
            this.ICharacter = dal;
        }

        public OccupationDTO ConvertOccupation()
        {
            OccupationDTO dto = new OccupationDTO();
            dto.ID = occupationID;
            dto.Name = occupationName;
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
            return DTO;
        }

        public bool SaveChar()
        {
            CharacterDTO DTO = ToDTO();
            return ICharacter.SaveCharacter(DTO);
        }

        public bool DeleteChar()
        {
            CharacterDTO DTO = ToDTO();
            return ICharacter.DeleteCharacter(DTO);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
