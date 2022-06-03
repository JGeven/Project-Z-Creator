using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Interface;
using Project_Z_Interface.DTO;
using Project_Z_Logic;

namespace Project_Z_Database
{
    public class CharacterSql : SQLConnect, ICharacterContainer
    {
        private TraitsSQL _traitsSQL = new TraitsSQL();
        
        public CharacterSql()
        {
            Initialize();
        }

        public bool SaveCharacter(CharacterDTO dto)
        {
            if (OpenConnect())
            {

                cmd.CommandText = "INSERT INTO Characters (name, cost, occupationid, userid) output INSERTED.CharacterID VALUES(@Name, @Cost, @Occupation, @User)";
                cmd.Parameters.AddWithValue("@Name", dto.Name);
                cmd.Parameters.AddWithValue("@Cost", dto.Cost);
                cmd.Parameters.AddWithValue("@Occupation", dto.Occupations.OccupationID);
                cmd.Parameters.AddWithValue("@User", dto.User.UserID);
                int CharacterID = (int) cmd.ExecuteScalar();

                foreach (int trait in dto.arraytraits)
                {
                    _traitsSQL.SaveTrait(trait, CharacterID);
                }

                CloseConnect();
                return true;
            }
            else
                return false;
        }

        public bool DeleteCharacter(int characterID)
        {
            if (OpenConnect())
            {
                cmd.CommandText = "DELETE FROM Characters Where CharacterID = @CharacterID";
                cmd.Parameters.AddWithValue("@CharacterID", characterID);

                _traitsSQL.DeleteTrait(characterID);
                
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                CloseConnect();
                return true;
            }
            return false;
 
        }

        public bool UpdateCharacter(CharacterDTO dto, int characterID)
        {
            if (OpenConnect())
            {
                cmd.CommandText = "UPDATE Characters SET Name = @Name, Cost = @Cost, OccupationID = @Occupation WHERE CharacterID = @CharacterID";

                cmd.Parameters.AddWithValue("@Name", dto.Name);
                cmd.Parameters.AddWithValue("@Cost", dto.Cost);
                cmd.Parameters.AddWithValue("@Occupation", dto.Occupations.OccupationID);
                cmd.Parameters.AddWithValue("@CharacterID", characterID);

                _traitsSQL.DeleteTrait(characterID);
                foreach (int trait in dto.arraytraits)
                {
                    _traitsSQL.UpdateTrait(trait, characterID);
                }

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                CloseConnect();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public List<CharacterDTO> GetCharacters()
        {
            OpenConnect();
            cmd.CommandText = 
                "SELECT Characters.CharacterID, Characters.Name, Characters.Cost, Occupations.Name FROM Characters INNER JOIN Occupations ON Characters.OccupationID=Occupations.OccupationID";
            using SqlDataReader rdr = cmd.ExecuteReader();

            List<CharacterDTO> list = new List<CharacterDTO>();
            CharacterDTO characters = new CharacterDTO();

            while (rdr.Read())
            {
                characters = new CharacterDTO
                {
                    CharacterID = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Cost = rdr.GetInt32(2),
                    Traits = _traitsSQL.GetTraitbyID(characters.CharacterID),
                };
                
                OccupationDTO occupation = new OccupationDTO
                {
                    Name = rdr.GetString(3),
                };

                List<TraitDTO> traits = _traitsSQL.GetTraitbyID(characters.CharacterID);
                characters.Traits = traits;
                characters.Occupations = occupation;
                list.Add(characters);
            }
            CloseConnect();
            return list;
        }

        public CharacterDTO GetCharacterbyID(int characterID)
        {
            CharacterDTO character = new CharacterDTO();
            OpenConnect();
            cmd.CommandText =
                "SELECT Characters.CharacterID, Characters.Name, Characters.Cost, Occupations.Name FROM Characters INNER JOIN Occupations ON Characters.OccupationID=Occupations.OccupationID WHERE Characters.CharacterID = @CharacterID";
            cmd.Parameters.AddWithValue("@CharacterID", characterID);
            
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                rdr.Read();
                character = new CharacterDTO()
                {
                    CharacterID = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Cost = rdr.GetInt32(2),
                };
                
                OccupationDTO occupation = new OccupationDTO
                {
                    Name = rdr.GetString(3),
                };
                
                List<TraitDTO> traits = _traitsSQL.GetTraitbyID(characterID);
                character.Traits = traits;
                character.Occupations = occupation;
            }
            CloseConnect();
            return character;
        }

        public List<CharacterDTO> GetCharacterbyUserID(int userID)
        {
            OpenConnect();
            cmd.CommandText = 
                "SELECT Characters.CharacterID, Characters.Name, Characters.Cost, Occupations.Name FROM Characters INNER JOIN Occupations ON Characters.OccupationID=Occupations.OccupationID WHERE Characters.UserID = @User";
            cmd.Parameters.AddWithValue("@User", userID);
            using SqlDataReader rdr = cmd.ExecuteReader();

            List<CharacterDTO> list = new List<CharacterDTO>();
            CharacterDTO characters = new CharacterDTO();

            while (rdr.Read())
            {
                characters = new CharacterDTO
                {
                    CharacterID = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Cost = rdr.GetInt32(2),
                    Traits = _traitsSQL.GetTraitbyID(characters.CharacterID),
                };
                
                OccupationDTO occupation = new OccupationDTO
                {
                    Name = rdr.GetString(3),
                };

                List<TraitDTO> traits = _traitsSQL.GetTraitbyID(characters.CharacterID);
                characters.Traits = traits;
                characters.Occupations = occupation;
                list.Add(characters);
            }
            CloseConnect();
            return list;
        }
    }
}
