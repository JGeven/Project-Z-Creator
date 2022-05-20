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
        
        //occupation ready for convert
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

        public Character(int characterid)
        {
            this.CharacterID = characterid;
        }
        public Character(string name, int cost, Occupations occupations, List<TraitDTO> traits)
        {
            this.Name = name;
            this.Cost = cost;
            this.occupationName = occupations.Name;
            this.occupationID = occupations.ID;
            this.Traits = traits;
        }

        public Character(string name, int cost, OccupationDTO occupations)
        {
            this.Name = name;
            this.Cost = cost;
            this.occupationName = occupations.Name;
            this.occupationID = occupations.ID;
        }

        public Character(int id, string name, int cost, OccupationDTO occupation)
        {
            this.CharacterID = id;
            this.Name = name;
            this.Cost = cost;
            this.occupationName = occupation.Name;
            this.occupationID = occupation.ID;
        }

       // public Character(int characterid, string name, int cost, ICharacter dal)
       // {
       ///     this.CharacterID = characterid;
       //     this.Name = name;
       //     this.Cost = cost;
        //    this.ICharacter = dal;
       // }

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

        public override string ToString()
        {
            return Name;
        }
    }
}
