using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    internal class CharacterContainer
    {
        ICharacterContainer IcharacterContainer;

        public CharacterContainer()
        {
        }

        public CharacterContainer(ICharacterContainer dal)
        {
            IcharacterContainer = dal;
        }

        public List<Character> GetCharacters()
        {
            List<Character> characters = new List<Character>();
            List<CharacterDTO> list = IcharacterContainer.GetCharacters();
            foreach (CharacterDTO character in list)
            {
                Character newCharacter = new Character(character);
                characters.Add(newCharacter);
            }
            return characters;
        }           
    }
}
