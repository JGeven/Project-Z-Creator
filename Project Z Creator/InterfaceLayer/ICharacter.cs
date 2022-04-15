using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z_Creator.InterfaceLayer
{
    public interface ICharacter
    {
        public bool SaveCharacter(CharacterDTO DTO);
        public bool DeleteCharacter(CharacterDTO DTO);
    }
}
