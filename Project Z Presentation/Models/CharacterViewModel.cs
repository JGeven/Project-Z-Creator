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
        public OccupationViewModel Occupation { get; set; }
        public int[] arraytraits { get; set; }
        public List<TraitViewModel> Traits { get; set; }
        
        public int occupationID { get; set; }
    }
}
