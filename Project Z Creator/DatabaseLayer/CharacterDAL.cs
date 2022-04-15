using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Creator.InterfaceLayer;

namespace Project_Z_Creator.DatabaseLayer
{
    public class CharacterDAL : SQLConnect, ICharacterContainer, ICharacter
    {   

        public CharacterDAL()
        {
            Initialize();
        }

        public bool SaveCharacter(CharacterDTO DTO)
        {
            if (OpenConnect())
            {

                cmd.CommandText = "INSERT INTO Characters (name, cost, occupationid) output INSERTED.CharacterID VALUES(@Name, @Cost, @Occupation)";
                cmd.Parameters.AddWithValue("@Name", DTO.Name);
                cmd.Parameters.AddWithValue("@Cost", DTO.Cost);
                cmd.Parameters.AddWithValue("@Occupation", DTO.Occupation);
                int CharacterID = (int) cmd.ExecuteScalar();

                foreach (Trait trait in DTO.Traits)
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

        public bool DeleteCharacter(CharacterDTO DTO)
        {
            if (OpenConnect())
            {
                cmd.CommandText = "DELETE FROM LinkCharTrait WHERE LinkCharTrait.CharacterID = @CharacterID DELETE FROM Characters Where Characters.CharacterID = @CharacterID";
                cmd.Parameters.AddWithValue("@CharacterID", DTO.CharacterID);
                cmd.ExecuteNonQuery();

                CloseConnect();
                return true;
            }
            else
                return false;
 
        }



        //Maak een join clause anders werkt niet. Join occcupation ID en de naam.
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
                    OccupationName = rdr.GetString(3)
                };



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
