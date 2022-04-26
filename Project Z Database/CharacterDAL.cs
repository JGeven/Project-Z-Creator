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
    public class CharacterDAL : SQLConnect, ICharacterContainer, ICharacter
    {
        public CharacterDAL()
        {
            Initialize();
        }

        public bool SaveCharacter(CharacterDTO dto)
        {
            if (OpenConnect())
            {

                cmd.CommandText = "INSERT INTO Characters (name, cost, occupationid) output INSERTED.CharacterID VALUES(@Name, @Cost, @Occupation)";
                cmd.Parameters.AddWithValue("@Name", dto.Name);
                cmd.Parameters.AddWithValue("@Cost", dto.Cost);
                cmd.Parameters.AddWithValue("@Occupation", dto.Occupations);
                int CharacterID = (int) cmd.ExecuteScalar();

                foreach (TraitDTO trait in dto.Traits)
                {
                    cmd = new SqlCommand("INSERT INTO LinkCharTrait (CharacterID, TraitID) VALUES(@CharacterID, @TraitID)", conn);
                    cmd.Parameters.AddWithValue("@CharacterID", CharacterID);
                    cmd.Parameters.AddWithValue("@TraitID", trait.TraitID);
                    cmd.ExecuteNonQuery();
                }
                CloseConnect();
                return true;
            }
            else
                return false;
        }

        public bool DeleteCharacter(CharacterDTO dto)
        {
            if (OpenConnect())
            {
                cmd.CommandText = "DELETE FROM LinkCharTrait WHERE LinkCharTrait.CharacterID = @CharacterID DELETE FROM Characters Where Characters.CharacterID = @CharacterID";
                cmd.Parameters.AddWithValue("@CharacterID", dto.CharacterID);
                cmd.ExecuteNonQuery();

                CloseConnect();
                return true;
            }
            else
                return false;
 
        }
        
        public List<CharacterDTO> GetCharacters()
        {
            OpenConnect();
            cmd.CommandText = 
                "SELECT Characters.CharacterID, Characters.Name, Characters.Cost, Occupations.Name FROM Characters INNER JOIN Occupations ON Characters.OccupationID=Occupations.OccupationID";
            int CharacterID = (int)cmd.ExecuteScalar();
            using SqlDataReader rdr = cmd.ExecuteReader();

            List<CharacterDTO> list = new List<CharacterDTO>();

            while (rdr.Read())
            {
                CharacterDTO characters = new CharacterDTO
                {
                    CharacterID = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Cost = rdr.GetInt32(2),
                };
                
                OccupationDTO occupation = new OccupationDTO
                {
                    Name = rdr.GetString(3),
                };
                characters.Occupations = occupation;
                list.Add(characters);
            }
            CloseConnect();
/*            OpenConnect();
            cmd = new SqlCommand("Select LinkCharTrait.CharacterID, LinkCharTrait.TraitID, Traits.Name FROM LinkCharTrait INNER JOIN Traits ON LinkCharTrait.TraitID=Traits.TraitsID WHERE LinkCharTrait.CharacterID=@CharacterID", conn);
            cmd.Parameters.AddWithValue("@CharacterID", CharacterID);

            using SqlDataReader rdr2 = cmd.ExecuteReader();

            while (rdr2.Read())
            {
                CharacterDTO character = new CharacterDTO
                {
                     Trait = rdr2.GetString(2)
                };
                list.Add(character);
            }

            CloseConnect();*/
            return list;
        }
    }
}
