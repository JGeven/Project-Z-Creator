using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class CharacterContainer
    {
        ICharacterContainer IcharacterContainer;

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
        
        public Character GetCharacterbyID(int CharacterID)
        {
            CharacterDTO characterDTO = IcharacterContainer.GetCharacterbyID(CharacterID);
            Character character = new Character(characterDTO);
            return character;
        }

        public List<Character> GetCharacterbyUserID(int userID)
        {
            List<CharacterDTO> characterDTOs = IcharacterContainer.GetCharacterbyUserID(userID);
            List<Character> characters = new List<Character>();
            foreach (CharacterDTO character in characterDTOs)
            {
                Character newCharacter = new Character(character);
                characters.Add(newCharacter);
            }
            return characters;
        }

        public bool SaveCharacter(Character character)
        {
            CharacterDTO dto = character.ToDTO();
            return IcharacterContainer.SaveCharacter(dto);
        }
        
        public bool DeleteCharacter(int characterID)
        {
            return IcharacterContainer.DeleteCharacter(characterID);
        }

        public bool UpdateCharacter(Character character,int characterID)
        {
            CharacterDTO dto = character.ToDTO();
            return IcharacterContainer.UpdateCharacter(dto, characterID);
        }
    }
}
