using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Project_Z_Creator.InterfaceLayer;

namespace Project_Z_Creator.DatabaseLayer
{
    public class OccupationDAL : SQLConnect, IOccupationContainer, IOccupation
    {

        public OccupationDAL()
        {
            Initialize();
        }

        public List<OccupationDTO> GetOccupations()
        {
            OpenConnect();
            cmd.CommandText = "Select * From Occupations";

            using SqlDataReader rdr = cmd.ExecuteReader();

            List<OccupationDTO> list = new List<OccupationDTO>();

            while (rdr.Read())
            {
                OccupationDTO occupations = new OccupationDTO()
                {
                    ID = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Cost = rdr.GetInt32(2),
                };
                list.Add(occupations);
            }
            CloseConnect();
            return list;
        }

    }
}
