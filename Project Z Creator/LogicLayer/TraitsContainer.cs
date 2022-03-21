using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Creator.DatabaseLayer;
using Project_Z_Creator.LogicLayer;

namespace Project_Z_Creator.LogicLayer
{
    internal class TraitsContainer
    {
        public List<Traits> PosTraits = new List<Traits>();
        public List<Traits> NegTraits = new List<Traits>();

        public List<Traits> GetAllPosTraits()
        {
            TraitsDAL dal = new TraitsDAL();
            List<PosTraitsDTO> list = dal.GetPosTraits();
            foreach (PosTraitsDTO posTrait in list)
            {
                Traits newtrait = new Traits(posTrait);
                PosTraits.Add(newtrait);
            }
            return PosTraits;
        }

        public List<Traits> GetAllNegTraits()
        {
            TraitsDAL dal = new TraitsDAL();
            List <NegTraitsDTO> list = dal.GetNegTraits();
            foreach (NegTraitsDTO negTrait in list)
            {
                Traits newtrait = new Traits(negTrait);
                NegTraits.Add(newtrait);
            }
            return NegTraits;
        }
    }
}
