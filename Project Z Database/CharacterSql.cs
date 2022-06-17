using System.Data.SqlClient;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Database
{
    public class CharacterSql : SqlConnect, ICharacterContainer
    {
        private TraitsSql _traitsSql = new TraitsSql();
        
        public CharacterSql()
        {
            Initialize();
        }

        public bool SaveCharacter(CharacterDto dto)
        {
            try
            {
                OpenConnect();
                {

                    Cmd.CommandText = "INSERT INTO Characters (name, cost, occupationid, userid) output INSERTED.CharacterID VALUES(@Name, @Cost, @Occupation, @User)";
                    Cmd.Parameters.AddWithValue("@Name", dto.Name);
                    Cmd.Parameters.AddWithValue("@Cost", dto.Cost);
                    Cmd.Parameters.AddWithValue("@Occupation", dto.Occupations.OccupationID);
                    Cmd.Parameters.AddWithValue("@User", dto.User.UserID);
                    int characterID = (int)Cmd.ExecuteScalar();

                    foreach (int trait in dto.Arraytraits)
                    {
                        _traitsSql.SaveTrait(trait, characterID);
                    }
                    return true;
                }
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

        public bool DeleteCharacter(int characterID)
        {
            try
            {
                OpenConnect();
                Cmd.CommandText = "DELETE FROM Characters Where CharacterID = @CharacterID";
                Cmd.Parameters.AddWithValue("@CharacterID", characterID);

                _traitsSql.DeleteTrait(characterID);

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

        public bool UpdateCharacter(CharacterDto dto)
        {
            try
            {
                OpenConnect();
                
                Cmd.CommandText = "UPDATE Characters SET Name = @Name, Cost = @Cost, OccupationID = @Occupation WHERE CharacterID = @CharacterID";

                Cmd.Parameters.AddWithValue("@Name", dto.Name); 
                Cmd.Parameters.AddWithValue("@Cost", dto.Cost);
                Cmd.Parameters.AddWithValue("@Occupation", dto.Occupations.OccupationID);
                Cmd.Parameters.AddWithValue("@CharacterID", dto.CharacterID);

                _traitsSql.DeleteTrait(dto.CharacterID);
                foreach (int trait in dto.Arraytraits)
                {
                    _traitsSql.UpdateTrait(trait, dto.CharacterID);
                }

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
        
        public List<CharacterDto> GetCharacters()
        {
            try
            {
                OpenConnect();
                Cmd.CommandText =
                    "SELECT Characters.CharacterID, Characters.Name, Characters.Cost, Occupations.Name FROM Characters INNER JOIN Occupations ON Characters.OccupationID=Occupations.OccupationID";
                using SqlDataReader rdr = Cmd.ExecuteReader();

                List<CharacterDto> list = new List<CharacterDto>();
                CharacterDto characters = new CharacterDto();

                while (rdr.Read())
                {
                    characters = new CharacterDto
                    {
                        CharacterID = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Cost = rdr.GetInt32(2),
                        Traits = _traitsSql.GetTraitbyID(characters.CharacterID),
                    };

                    OccupationDto? occupation = new OccupationDto
                    {
                        Name = rdr.GetString(3),
                    };

                    List<TraitDto>? traits = _traitsSql.GetTraitbyID(characters.CharacterID);
                    characters.Traits = traits;
                    characters.Occupations = occupation;
                    list.Add(characters);
                }
                return list;
            }
            catch (NullReferenceException)
            {
                throw new Exception("No data could be found");
            }
            finally
            {
                CloseConnect();
            }
        }

        public CharacterDto GetCharacterbyID(int characterID)
        {
            try
            {
                CharacterDto character = new CharacterDto();
                OpenConnect();
                Cmd.CommandText =
                    "SELECT Characters.CharacterID, Characters.Name, Characters.Cost, Characters.UserID, Occupations.Name FROM Characters INNER JOIN Occupations ON Characters.OccupationID=Occupations.OccupationID WHERE Characters.CharacterID = @CharacterID";
                Cmd.Parameters.AddWithValue("@CharacterID", characterID);

                using (SqlDataReader rdr = Cmd.ExecuteReader())
                {
                    rdr.Read();
                    character = new CharacterDto
                    {
                        CharacterID = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Cost = rdr.GetInt32(2),
                    };
                    
                    UserDto user = new UserDto()
                    {
                        UserID = rdr.GetInt32(3),
                    };

                    OccupationDto? occupation = new OccupationDto
                    {
                        Name = rdr.GetString(4),
                    };

                    List<TraitDto>? traits = _traitsSql.GetTraitbyID(characterID);
                    character.Traits = traits;
                    character.Occupations = occupation;
                    character.User = user;
                }
                return character;
            }
            catch (NullReferenceException)
            {
                throw new Exception("No data could be found");
            }
            finally
            {
                CloseConnect();
            }

        }

        public List<CharacterDto> GetCharacterbyUserID(int userID)
        {
            try
            {
                OpenConnect();
                Cmd.CommandText =
                    "SELECT Characters.CharacterID, Characters.Name, Characters.Cost, Occupations.Name FROM Characters INNER JOIN Occupations ON Characters.OccupationID=Occupations.OccupationID WHERE Characters.UserID = @User";
                Cmd.Parameters.AddWithValue("@User", userID);
                using SqlDataReader rdr = Cmd.ExecuteReader();

                List<CharacterDto> list = new List<CharacterDto>();
                CharacterDto characters = new CharacterDto();

                while (rdr.Read())
                {
                    characters = new CharacterDto
                    {
                        CharacterID = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Cost = rdr.GetInt32(2),
                        Traits = _traitsSql.GetTraitbyID(characters.CharacterID),
                    };

                    OccupationDto? occupation = new OccupationDto
                    {
                        Name = rdr.GetString(3),
                    };

                    List<TraitDto>? traits = _traitsSql.GetTraitbyID(characters.CharacterID);
                    characters.Traits = traits;
                    characters.Occupations = occupation;
                    list.Add(characters);
                }
                return list;
            }
            catch (NullReferenceException)
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
