﻿using System;
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

        public CharacterContainer()
        {
        }

        public CharacterContainer(ICharacterContainer dal)
        {
            IcharacterContainer = dal;
        }

        public List<Character> GetCharacters()
        {
            CharacterContainer characterContainer = new CharacterContainer(IcharacterContainer);
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

        public bool SaveCharacter(Character character)
        {
            CharacterDTO dto = character.ToDTO();
            return IcharacterContainer.SaveCharacter(dto);
        }
        
        public bool DeleteCharacter(int characterID)
        {
            return IcharacterContainer.DeleteCharacter(characterID);
        }
    }
}
