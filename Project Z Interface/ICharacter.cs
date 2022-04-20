using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Interface.DTO;

namespace Project_Z_Interface
{
    public interface ICharacter
    {
        public bool SaveCharacter(CharacterDTO DTO);
        public bool DeleteCharacter(CharacterDTO DTO);
    }
}
