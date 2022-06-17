using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Logic
{
    public class TraitsContainer
    {
        ITraitsContainer _itraitsContainer;

        public TraitsContainer(ITraitsContainer dal)
        {
            _itraitsContainer = dal;
        }
        public List<Trait> GetTraits()
        {
            List<Trait> traits = new List<Trait>();
            List<TraitDto> list = _itraitsContainer.GetTraits();
            foreach (TraitDto traitsDto in list)
            {
                Trait newtrait = new Trait(traitsDto);
                traits.Add(newtrait);
            }
            return traits;
        }
    }
}
