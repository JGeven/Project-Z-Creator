using System.Data.SqlClient;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Database
{
    public class TraitsSql : SqlConnect, ITraitsContainer
    {

        public TraitsSql()
        {
            Initialize();
        }

        public List<TraitDto> GetTraits()
        {
            try
            {
                OpenConnect();
                Cmd.CommandText = "Select * From Traits";

                using SqlDataReader rdr = Cmd.ExecuteReader();

                List<TraitDto> list = new List<TraitDto>();

                while (rdr.Read())
                {
                    TraitDto traits = new TraitDto
                    {
                        TraitID = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Cost = rdr.GetInt32(2),
                        PosNeg = rdr.GetBoolean(3),
                    };
                    list.Add(traits);
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

        public List<TraitDto> GetTraitbyID(int characterID)
        {
            try
            {
                OpenConnect();
                Cmd.CommandText = "Select LinkCharTrait.CharacterID, LinkCharTrait.TraitID, Traits.TraitsID, Traits.Name, Traits.Cost, Traits.PosNeg FROM LinkCharTrait INNER JOIN Traits ON LinkCharTrait.TraitID=Traits.TraitsID WHERE LinkCharTrait.CharacterID=@CharacterID";
                Cmd.Parameters.AddWithValue("@CharacterID", characterID);

                using SqlDataReader rdr = Cmd.ExecuteReader();
                List<TraitDto> list = new List<TraitDto>();

                while (rdr.Read())
                {
                    TraitDto traits = new TraitDto
                    {
                        TraitID = rdr.GetInt32(2),
                        Name = rdr.GetString(3),
                        Cost = rdr.GetInt32(4),
                        PosNeg = rdr.GetBoolean(5),
                    };
                    list.Add(traits);
                }
                Cmd.Parameters.Clear();
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
        
        public bool SaveTrait(int traitID, int characterID)
        {
            try
            {
                OpenConnect();
                Cmd.CommandText = "INSERT INTO LinkCharTrait (CharacterID, TraitID) VALUES(@CharacterID, @TraitID)";
                Cmd.Parameters.AddWithValue("@CharacterID", characterID);
                Cmd.Parameters.AddWithValue("@TraitID", traitID);

                Cmd.ExecuteNonQuery();
                Cmd.Parameters.Clear();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                CloseConnect();
            }

        }

        public bool DeleteTrait(int characterID)
        {
            try
            {
                OpenConnect();
                Cmd.CommandText = "DELETE FROM LinkCharTrait WHERE CharacterID = @CharacterID";
                Cmd.Parameters.AddWithValue("@CharacterID", characterID);

                Cmd.ExecuteNonQuery();
                Cmd.Parameters.Clear();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                CloseConnect(); 
            }
        }

        public bool UpdateTrait(int traitID, int characterID)
        {
            try
            {
                OpenConnect();
                Cmd.CommandText = "INSERT INTO LinkCharTrait (CharacterID, TraitID) VALUES(@CharacterID, @TraitID)";
                Cmd.Parameters.AddWithValue("@CharacterID", characterID);
                Cmd.Parameters.AddWithValue("@TraitID", traitID);

                Cmd.ExecuteNonQuery();
                Cmd.Parameters.Clear();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                CloseConnect();
            }
        }
    }
}
