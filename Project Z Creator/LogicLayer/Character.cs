using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Creator.InterfaceLayer;

namespace Project_Z_Creator
{
    public class Character
    {
        public int CharacterID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Occupation { get; set; }
        public string OccupationName { get; set; }
        public List<Trait> Traits { get; set; }

        ICharacter ICharacter;

        public Character(ICharacter dal)
        {
            ICharacter = dal;
        }

        public Character(CharacterDTO Character)
        {
            this.CharacterID = Character.CharacterID;
            this.Name = Character.Name;
            this.Cost = Character.Cost;
            this.Occupation = Character.Occupation;
            this.OccupationName = Character.OccupationName;
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

        public Character(string name, int cost, int occcupation, List<Trait> traits, ICharacter dal)
        {
            
            this.Name = name;  
            this.Cost = cost;
            this.Occupation = occcupation;
            this.Traits = traits;
            this.ICharacter = dal;
        }

        private CharacterDTO ToDTO()
        {
            CharacterDTO DTO = new CharacterDTO();
            DTO.CharacterID = CharacterID;
            DTO.Name = Name;
            DTO.Cost = Cost;
            DTO.Occupation = Occupation;
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
