using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project_Z_Creator.DatabaseLayer
{
    public class OccupationDAL : SQLConnect
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
                    Name = rdr.GetString(0),
                    Cost = rdr.GetInt32(1),
                };
                list.Add(occupations);
            }
            CloseConnect();
            return list;
        }

    }
}
