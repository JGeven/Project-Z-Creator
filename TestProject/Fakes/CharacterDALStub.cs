using System;
using System.Collections.Generic;
using System.Data;
using Project_Z_Interface.DTO;
using Project_Z_Interface;  

namespace TestProject.Fakes
{
    public class CharacterDALStub : ICharacter, ICharacterContainer
    {
        List<CharacterDTO> list = new List<CharacterDTO>();
        
        public List<CharacterDTO> GetCharacters()
        {
            CharacterDTO dto = new CharacterDTO();
            dto.CharacterID = 420;
            dto.Name = "test";
            dto.Cost = 69;

            list.Add(dto);
            return list;
        }

        public bool SaveCharacter(CharacterDTO dto)
        {
            try
            {   
                Console.WriteLine("Saved");
                list.Add(dto);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool DeleteCharacter(CharacterDTO dto)
        {
            list.Add(dto);

            try
            {
                Console.WriteLine("Saved");
                list.Remove(dto);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
