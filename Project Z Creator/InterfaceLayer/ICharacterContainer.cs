using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z_Creator.InterfaceLayer
{
    public interface ICharacterContainer
    {
        public List<CharacterDTO> GetCharacters();
    }
}
