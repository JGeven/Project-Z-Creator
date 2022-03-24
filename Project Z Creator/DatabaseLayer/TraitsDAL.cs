using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z_Creator.DatabaseLayer
{
    public class TraitsDAL : SQLConnect
    {

        public TraitsDAL()
        {
            Initialize();
        }

        public List<PosTraitsDTO> GetPosTraits()
        {
            OpenConnect();
            cmd.CommandText = "Select * From Traits WHERE PosNeg=1";

            using SqlDataReader rdr = cmd.ExecuteReader();

            
            List<PosTraitsDTO> list = new List<PosTraitsDTO>();

            while (rdr.Read())
            {
                PosTraitsDTO postrait = new PosTraitsDTO
                {
                    Name = rdr.GetString(0),
                    Cost = rdr.GetInt32(1),
                };
                list.Add(postrait);
            }
            CloseConnect();
            return list;
        }

        public List<NegTraitsDTO> GetNegTraits()
        {
            OpenConnect();
            cmd.CommandText = "Select * From Traits WHERE PosNeg=0";

            using SqlDataReader rdr = cmd.ExecuteReader();

            List<NegTraitsDTO> list = new List<NegTraitsDTO>();

            while (rdr.Read())
            {
                NegTraitsDTO negtrait = new NegTraitsDTO
                {
                    Name = rdr.GetString(0),
                    Cost = rdr.GetInt32(1),
                };
                list.Add(negtrait);
            }
            CloseConnect();
            return list;
        }

    }
}
