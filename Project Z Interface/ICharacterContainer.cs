using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Interface.DTO;

namespace Project_Z_Interface
{
    public interface ICharacterContainer
    {
        public bool SaveCharacter(CharacterDTO DTO);
        public bool DeleteCharacter(int DTO);
        public List<CharacterDTO> GetCharacters();
        public CharacterDTO GetCharacterbyID(int characterID);
        public List<CharacterDTO> GetCharacterbyUserID(int userID);
        public bool UpdateCharacter(CharacterDTO dto, int characterID);
    }
}
