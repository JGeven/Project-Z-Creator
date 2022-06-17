using Project_Z_Interface.DTO;

namespace Project_Z_Interface
{
    public interface ICharacterContainer
    {
        public bool SaveCharacter(CharacterDto dto);
        public bool DeleteCharacter(int dto);
        public List<CharacterDto> GetCharacters();
        public CharacterDto GetCharacterbyID(int characterID);
        public List<CharacterDto> GetCharacterbyUserID(int userID);
        public bool UpdateCharacter(CharacterDto dto);
    }
}
