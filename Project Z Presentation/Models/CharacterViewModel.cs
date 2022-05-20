using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Z_Database;
using Project_Z_Interface;
using Project_Z_Logic;

namespace Project_Z_Presentation.Models
{
    public class CharacterViewModel
    {
        public int CharacterID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public OccupationDTO Occupation { get; set; }
        public List<Trait> Traits { get; set; }

        public CharacterViewModel()
        {
            
        }

        public CharacterViewModel(Character character)
        {
            this.CharacterID = character.CharacterID;
            this.Name = character.Name;
            this.Cost = character.Cost;
            this.Occupation = character.Occupation;
        }
        
        public CharacterViewModel(int characterId, string name, int cost, OccupationDTO occupation)
        {
            this.CharacterID = characterId;
            this.Name = name;
            this.Cost = cost;
            this.Occupation = occupation;
        }

        public CharacterViewModel(string name, int cost, OccupationDTO occupation)
        {
            this.Name = name;
            this.Cost = cost;
            this.Occupation = occupation;
        }
    }
}
