using System.Data.SqlClient;
using Project_Z_Interface;
using Project_Z_Interface.DTO;

namespace Project_Z_Database
{
    public class ReviewSql : SqlConnect, IReviewContainer
    {
        public ReviewSql()
        {
            Initialize();
        }

        public bool CreateReview(ReviewDTO dto, int characterID, int userID)
        {
            try
            {
                OpenConnect();

                Cmd.CommandText = "INSERT INTO Rating (rating, comment) output INSERTED.ReviewID VALUES (@Rating, @Comment)";
                Cmd.Parameters.AddWithValue("@Rating", dto.Rating);
                Cmd.Parameters.AddWithValue("@Comment", dto.Comment);
                int reviewID = (int)Cmd.ExecuteScalar();

                string sql = "INSERT INTO LinkCharUserRate (reviewid, userid, characterid) VALUES (@ReviewID, @UserID, @CharacterID)";
                Cmd = new SqlCommand(sql, Conn);
                Cmd.Parameters.AddWithValue("@ReviewID", reviewID);
                Cmd.Parameters.AddWithValue("@UserID", userID);
                Cmd.Parameters.AddWithValue("@CharacterID", characterID);

                Cmd.ExecuteNonQuery();
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

        public List<ReviewDTO> GetRating(int characterID)
        {
            try
            {
                OpenConnect();

                Cmd.CommandText = "SELECT [User].Name, Rating.Comment FROM LinkCharUserRate INNER JOIN [User] ON LinkCharUserRate.UserID=[User].UserID INNER JOIN Rating ON LinkCharUserRate.ReviewID=Rating.ReviewID WHERE LinkCharUserRate.CharacterID=@CharacterID";
                Cmd.Parameters.AddWithValue("@CharacterID", characterID);
                
                SqlDataReader rdr = Cmd.ExecuteReader();
                List<ReviewDTO> list = new List<ReviewDTO>();

                while (rdr.Read())
                {
                    ReviewDTO review = new ReviewDTO()
                    {
                        UserName = rdr.GetString(0),
                        Comment = rdr.GetString(1),
                    };
                    list.Add(review);
                }
                Cmd.Parameters.Clear();
                return list;

            }
            catch (SqlException)
            {
                throw new Exception("No data was found");
            }
            finally
            {
                CloseConnect();
            }
        }
    }
}
