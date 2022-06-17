using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class CharacterContainer
    {
        ICharacterContainer _icharacterContainer;

        public CharacterContainer(ICharacterContainer dal)
        {
            _icharacterContainer = dal;
        }

        public List<Character> GetCharacters()
        {
            List<Character> characters = new List<Character>();
            List<CharacterDto> list = _icharacterContainer.GetCharacters();
            foreach (CharacterDto character in list)
            {
                Character newCharacter = new Character(character);
                characters.Add(newCharacter);
            }
            return characters;
        }
        
        public Character GetCharacterbyID(int characterID)
        {
            CharacterDto characterDto = _icharacterContainer.GetCharacterbyID(characterID);
            Character character = new Character(characterDto);
            return character;
        }

        public List<Character> GetCharacterbyUserID(int userID)
        {
            List<CharacterDto> characterDtOs = _icharacterContainer.GetCharacterbyUserID(userID);
            List<Character> characters = new List<Character>();
            foreach (CharacterDto character in characterDtOs)
            {
                Character newCharacter = new Character(character);
                characters.Add(newCharacter);
            }
            return characters;
        }

        public bool SaveCharacter(Character character)
        {
            CharacterDto dto = character.ToDto();
            return _icharacterContainer.SaveCharacter(dto);
        }
        
        public bool DeleteCharacter(int characterID)
        {
            return _icharacterContainer.DeleteCharacter(characterID);
        }

        public bool UpdateCharacter(Character character)
        {
            CharacterDto dto = character.ToDto();
            return _icharacterContainer.UpdateCharacter(dto);
        }
    }
}
