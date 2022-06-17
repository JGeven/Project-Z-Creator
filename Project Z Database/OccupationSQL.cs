using System.Data.SqlClient;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Database
{
    public class OccupationSql : SqlConnect, IOccupationContainer
    {

        public OccupationSql()
        {
            Initialize();
        }

        public List<OccupationDto> GetOccupations()
        {
            try
            {
                OpenConnect();
                Cmd.CommandText = "Select * From Occupations";

                using SqlDataReader rdr = Cmd.ExecuteReader();

                List<OccupationDto> list = new List<OccupationDto>();

                while (rdr.Read())
                {
                    OccupationDto occupations = new OccupationDto
                    {
                        OccupationID = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Cost = rdr.GetInt32(2),
                    };
                    list.Add(occupations);
                }
                return list;
            }
            catch (SqlException)
            {
                throw new Exception("No data could be found");
            }
            finally
            {
                CloseConnect();
            }

        }

    }
}
