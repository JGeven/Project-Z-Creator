using System;
using System.Collections.Generic;
using System.Data;
using Project_Z_Interface.DTO;
using Project_Z_Interface;  

namespace TestProject.Fakes
{
    public class CharacterDALStub : ICharacterContainer
    {

        public List<CharacterDTO> GetCharacters()
        {
            List<CharacterDTO> list = new List<CharacterDTO>();
            CharacterDTO dto = new CharacterDTO();
            dto.CharacterID = 420;
            dto.Name = "test";
            dto.Cost = 69;

            list.Add(dto);
            return list;
        }

        public bool SaveCharacter(CharacterDTO dto)
        {
            List<CharacterDTO> list = new List<CharacterDTO>();
            
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

        public bool DeleteCharacter(int characterID)
        {
            List<int> traits = new List<int>();
            int lucky = 1;
            int smoker = 6;
            traits.Add(lucky);
            traits.Add(smoker);
            int[] arraytraits;
            arraytraits = traits.ToArray();

            OccupationDTO occupation = new OccupationDTO();
            occupation.ID = 1;
            occupation.Name = "Chef";
            
            CharacterDTO dto = new CharacterDTO();
            dto.CharacterID = 31;
            dto.Name = "Jesse Leppens";
            dto.Cost = 5;
            dto.Occupations = occupation;
            dto.arraytraits = arraytraits;
            
            List<CharacterDTO> list = new List<CharacterDTO>();
            list.Add(dto);
            
            if (dto.CharacterID == characterID)
            {
                list.RemoveAll(dto => dto.CharacterID != characterID);
                Console.WriteLine("Deleted");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCharacter(CharacterDTO DTO, int characterID)
        {
            OccupationDTO occupation = new OccupationDTO();
            occupation.ID = 2;
            occupation.Name = "Chef";
            
            List<int> traits = new List<int>();
            int chef = 1;
            int smoker = 6;
        
            traits.Add(chef);
            traits.Add(smoker);

            int[] arraytraits;
            arraytraits = traits.ToArray();
            
            CharacterDTO dto = new CharacterDTO();
            dto.CharacterID = 31;
            dto.Name = "Jesse Leppens";
            dto.Cost = 5;
            dto.Occupations = occupation;
            dto.arraytraits = arraytraits;
                
            if (dto.CharacterID == characterID)
            {
                dto.Name = DTO.Name;
                dto.Cost = DTO.Cost;
                dto.Occupations = DTO.Occupations;
                dto.arraytraits = DTO.arraytraits;
                Console.WriteLine(dto.Name);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public CharacterDTO GetCharacterbyID(int characterID)
        {
            UserDTO user = new UserDTO();
            user.UserID = 4;
            
            OccupationDTO occupation = new OccupationDTO();
            occupation.ID = 2;
            occupation.Name = "Chef";
            
            List<int> traits = new List<int>();
            int chef = 1;
            int smoker = 6;
        
            traits.Add(chef);
            traits.Add(smoker);

            int[] arraytraits;
            arraytraits = traits.ToArray();
            
            CharacterDTO dto = new CharacterDTO();
            dto.CharacterID = 31;
            dto.Name = "Jesse Leppens";
            dto.Cost = 5;
            dto.User = user;
            dto.Occupations = occupation;
            dto.arraytraits = arraytraits;

            if (dto.CharacterID == characterID)
            {
                Console.WriteLine("Got Character");
                return dto;
            }
            else
            {
                return null;
            }
        }

        public List<CharacterDTO> GetCharacterbyUserID(int userID)
        {
            List<CharacterDTO> characters = new List<CharacterDTO>();
            Random random = new Random();
            
            for (int i = 0; i < 30; i++)
            {
                UserDTO dto = new UserDTO();
                dto.UserID = random.Next(1,10);
                CharacterDTO character = new CharacterDTO();
                character.User = dto;
                characters.Add(character);
            }

            characters.RemoveAll(x => x.User.UserID != userID);

            return characters;

        }



    }
}
