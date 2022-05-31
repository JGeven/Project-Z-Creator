using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Database
{
    public class TraitsSQL : SQLConnect, ITraitsContainer
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

        public List<TraitDTO> GetTraitbyID(int characterID)
        {
            OpenConnect();
            cmd.CommandText = "Select LinkCharTrait.CharacterID, LinkCharTrait.TraitID, Traits.TraitsID, Traits.Name, Traits.Cost, Traits.PosNeg FROM LinkCharTrait INNER JOIN Traits ON LinkCharTrait.TraitID=Traits.TraitsID WHERE LinkCharTrait.CharacterID=@CharacterID";
            cmd.Parameters.AddWithValue("@CharacterID", characterID);

            using SqlDataReader rdr = cmd.ExecuteReader();
            List<TraitDTO> list = new List<TraitDTO>();
            
            while (rdr.Read())
            {
                TraitDTO traits = new TraitDTO
                {
                    TraitID = rdr.GetInt32(2),
                    Name = rdr.GetString(3),
                    Cost = rdr.GetInt32(4),
                    PosNeg = rdr.GetBoolean(5),
                };
                list.Add(traits);
            }
            cmd.Parameters.Clear();
            CloseConnect();
            return list;
        }
        
        public bool SaveTrait(int traitID, int characterID)
        {
            OpenConnect();
            cmd.CommandText = "INSERT INTO LinkCharTrait (CharacterID, TraitID) VALUES(@CharacterID, @TraitID)";
            cmd.Parameters.AddWithValue("@CharacterID", characterID);
            cmd.Parameters.AddWithValue("@TraitID", traitID);
            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            CloseConnect();
            return true;
        }

        public bool DeleteTrait(int characterID)
        {
            OpenConnect();
            cmd.CommandText = "DELETE FROM LinkCharTrait WHERE CharacterID = @CharacterID";
            cmd.Parameters.AddWithValue("@CharacterID", characterID);
            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            CloseConnect();
            return true;

        }

        public bool UpdateTrait(int traitID, int characterID)
        {
            OpenConnect();
            cmd.CommandText = "INSERT INTO LinkCharTrait (CharacterID, TraitID) VALUES(@CharacterID, @TraitID)";
            cmd.Parameters.AddWithValue("@CharacterID", characterID);
            cmd.Parameters.AddWithValue("@TraitID", traitID);
            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            CloseConnect();
            return true;
        }

    }
}
