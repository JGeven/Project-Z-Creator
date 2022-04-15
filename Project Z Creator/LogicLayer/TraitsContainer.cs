using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Creator.InterfaceLayer;

namespace Project_Z_Creator.LogicLayer
{
    internal class TraitsContainer
    {
        ITraitsContainer itraitsContainer;

        public TraitsContainer(ITraitsContainer dal)
        {
            itraitsContainer = dal;
        }
        public List<Trait> GetTraits()
        {
            List<Trait> Traits = new List<Trait>();
            List<TraitDTO> list = itraitsContainer.GetTraits();
            foreach (TraitDTO traits in list)
            {
                Trait newtrait = new Trait(traits);
                Traits.Add(newtrait);
            }
            return Traits;
        }
    }
}
