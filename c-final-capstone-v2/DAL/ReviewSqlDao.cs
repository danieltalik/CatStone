using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using c_final_capstone_v2.DAL;
using c_final_capstone_v2.Models;
using System.Data.SqlClient;

namespace c_final_capstone_v2.DAL
{
    public class ReviewSqlDao : IReviewSqlDao
    {
        private const string SQL_GetCatReviews = "SELECT * FROM Reviews WHERE cat_id = @catId";
        private const string SQL_InsertCatReview = "INSERT INTO [dbo].[Reviews] ([user_id], [cat_id], [date], [rating], [title], [sucess_story]) VALUES (@userId, @catId, @date, @rating, @title, @successStory)";

        private string connectionString;

        public ReviewSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Review> GetCatReviews(int id)
        {
            List<Review> resultList = new List<Review>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetCatReviews);
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@CatId", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        resultList.Add(MapRowToReviews(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return resultList;
        }

        public void AddCatReview(Review newReview)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_InsertCatReview);
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@catId", newReview.CatID);
                    cmd.Parameters.AddWithValue("@userId", newReview.UserID);
                    cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@rating", newReview.Rating);
                    cmd.Parameters.AddWithValue("@title", newReview.Title);
                    cmd.Parameters.AddWithValue("@successStory", newReview.SuccessStory);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
        }

private Review MapRowToReviews(SqlDataReader sdr)
{
    Review review = new Review();
    try
    {
        review.ID = Convert.ToInt32(sdr["id"]);
        review.CatID = Convert.ToInt32(sdr["cat_id"]);
        review.UserID = Convert.ToInt32(sdr["user_id"]);
        review.Date = Convert.ToDateTime(sdr["date"]);
        review.Rating = Convert.ToInt32(sdr["rating"]);
        review.Title = Convert.ToString(sdr["title"]);
        review.SuccessStory = Convert.ToString(sdr["sucess_story"]);
    }
    catch (Exception)
    {
        throw;
    }
    return review;
}
    }
}