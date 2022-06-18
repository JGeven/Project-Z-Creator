using System.Data;
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

                Cmd.CommandText = "SELECT LinkCharUserRate.ReviewID, [User].Name, [User].UserID, Rating.Comment, Rating.Rating FROM LinkCharUserRate INNER JOIN [User] ON LinkCharUserRate.UserID=[User].UserID INNER JOIN Rating ON LinkCharUserRate.ReviewID=Rating.ReviewID WHERE LinkCharUserRate.CharacterID=@CharacterID";
                Cmd.Parameters.AddWithValue("@CharacterID", characterID);
                
                SqlDataReader rdr = Cmd.ExecuteReader();
                List<ReviewDTO> list = new List<ReviewDTO>();

                while (rdr.Read())
                {
                    ReviewDTO review = new ReviewDTO()
                    {
                        ReviewID = rdr.GetInt32(0),
                        UserName = rdr.GetString(1),
                        UserID = rdr.GetInt32(2),
                        Comment = rdr.GetString(3),
                        Rating = rdr.GetInt32(4),
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

        public bool DeleteReview(int reviewID)
        {
            try
            {
                OpenConnect();

                Cmd.CommandText = "DELETE FROM Rating WHERE ReviewID = @ReviewID";
                Cmd.Parameters.AddWithValue("@ReviewID", reviewID);

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

        public bool UpdateReview(ReviewDTO dto)
        {
            try
            {
                OpenConnect();

                Cmd.CommandText = "UPDATE Rating SET Rating = @Rating, Comment = @Comment WHERE ReviewID = @ReviewID";
                Cmd.Parameters.AddWithValue("@Rating", dto.Rating);
                Cmd.Parameters.AddWithValue("@Comment", dto.Comment);
                Cmd.Parameters.AddWithValue("@ReviewID", dto.ReviewID);

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

        public ReviewDTO GetReviewbyID(int reviewID)
        {
            try
            {
                OpenConnect();

                Cmd.CommandText = "SELECT * FROM Rating WHERE ReviewID = @ReviewID";
                Cmd.Parameters.AddWithValue("@ReviewID", reviewID);

                SqlDataReader rdr = Cmd.ExecuteReader();
                ReviewDTO review = new ReviewDTO();

                while (rdr.Read())
                {
                    review = new ReviewDTO()
                    {
                        ReviewID = rdr.GetInt32(0),
                        Rating = rdr.GetInt32(1),
                        Comment = rdr.GetString(2),
                    };
                }
                return review;
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
