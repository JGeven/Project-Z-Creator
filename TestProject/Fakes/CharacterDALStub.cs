using System.Collections.Generic;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace TestProject.Fakes
{
    public class CharacterDalStub : ICharacterContainer
    {
        public List<CharacterDto> StubDtOs = new List<CharacterDto>();
        public CharacterDto StubDto = new CharacterDto();

        public List<CharacterDto> GetCharacters()
        {
            StubDto.CharacterID = 420;
            StubDto.Name = "test";
            StubDto.Cost = 69;

            StubDtOs.Add(StubDto);
            return StubDtOs;
        }

        public bool SaveCharacter(CharacterDto dto)
        {
            StubDto = dto;
            return true;
        }

        public bool DeleteCharacter(int characterID)
        {
            StubDto.CharacterID = characterID;
            return true;
        }

        public bool UpdateCharacter(CharacterDto dto)
        {
            StubDto = dto;
            return true;
        }

        public CharacterDto GetCharacterbyID(int characterID)
        {
            CharacterDto dto1 = new CharacterDto
            {
                CharacterID = 1,
                Name = "test123",
                Cost = 5,
            };
            
            CharacterDto dto2 = new CharacterDto
            {
                CharacterID = 2,
                Name = "Joshua",
                Cost = 6,
            };
            
            CharacterDto dto3 = new CharacterDto
            {
                CharacterID = 3,
                Name = "Will",
                Cost = 7,
            };
            
            StubDtOs.Add(dto1);
            StubDtOs.Add(dto2);
            StubDtOs.Add(dto3);

            StubDto = StubDtOs.Find(character => character.CharacterID == characterID);
            return StubDto;
        }

        public List<CharacterDto> GetCharacterbyUserID(int userID)
        {
            UserDto user1 = new UserDto
            {
                UserID = 1,
            };
            UserDto user2 = new UserDto
            {
                UserID = 2,
            };
            UserDto user3 = new UserDto
            {
                UserID = 3,
            };

            CharacterDto dto1 = new CharacterDto
            {
                User = user1,
                CharacterID = 1,
                Name = "test123",
                Cost = 5,
            };
            
            
            CharacterDto dto2 = new CharacterDto
            {
                User = user2,
                CharacterID = 2,
                Name = "Joshua",
                Cost = 6,
            };
            
            CharacterDto dto3 = new CharacterDto
            {
                User = user3,
                CharacterID = 3,
                Name = "Will",
                Cost = 7,
            };
            
            StubDtOs.Add(dto1);
            StubDtOs.Add(dto2);
            StubDtOs.Add(dto3);

            StubDtOs.RemoveAll(character => character.User.UserID != userID);
            return StubDtOs;

        }



    }
}
