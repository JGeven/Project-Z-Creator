using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Creator.DatabaseLayer;

namespace Project_Z_Creator
{
    public class Character
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Traits { get; set; }

        public Character(CharacterDTO Character)
        {
            this.Name = Character.Name;
            this.Cost = Character.Cost;
        }
        public Character()
        {
            this.Cost = 8;
        }

        public void SetName();
    }


}
