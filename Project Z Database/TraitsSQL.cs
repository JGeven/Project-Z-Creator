using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Interface;

namespace Project_Z_Database
{
    public class TraitsSQL : SQLConnect, ITraitsContainer, ITraits
    {

        public TraitsSQL()
        {
            Initialize();
        }

        public List<TraitDTO> GetTraits()
        {
            OpenConnect();
            cmd.CommandText = "Select * From Traits";

            using SqlDataReader rdr = cmd.ExecuteReader();

            
            List<TraitDTO> list = new List<TraitDTO>();

            while (rdr.Read())
            {
                TraitDTO traits = new TraitDTO
                {
                    TraitID = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Cost = rdr.GetInt32(2),
                    PosNeg = rdr.GetBoolean(3),
                };
                list.Add(traits);
            }
            CloseConnect();
            return list;
        }

    }
}
