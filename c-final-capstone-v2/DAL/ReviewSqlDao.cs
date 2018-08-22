using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using c_final_capstone_v2.DAL;
using c_final_capstone_v2.Models;
using System.Data.SqlClient;
using c_final_capstone_v2.DAL;

namespace c_final_capstone_v2.DAL
{
    public class ReviewSqlDao : IReviewSqlDao
    {
        private const string SQL_GetCatReviews = "SELECT * FROM Reviews WHERE cat_id = @catId";
        private const string SQL_InsertCatReview = "INSERT INTO [dbo].[Reviews] ([user_id], [cat_id], [date], [rating], [title], [sucess_story]) VALUES (@userId, @catId, @date, @rating, @title, @successStory)";
        private const string SQL_ReviewToEdit = "SELECT * FROM reviews WHERE id = @reviewID";
        private const string SQL_EditReview = "UPDATE reviews SET rating = @rating, title = @title, success_story = @successStory, review = @review, is_approved = @isApproved @WHERE id = @reviewID";
        private const string SQL_DeleteReview = "DELETE * FROM reviews WHERE id = @reviewID";

        private string connectionString;

        public ReviewSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Review> GetCatReviews(int catID)
        {
            List<Review> resultList = new List<Review>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetCatReviews);
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@CatId", catID);
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

        public bool AddCatReview(Review newReview)
        {
            bool result = false;
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

                    int count = cmd.ExecuteNonQuery();

                    if (count >0)
                    {
                        result = true;
                    }
                    cmd.Parameters.Clear();
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
            return result;
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

        public Review ReviewToEdit(int reviewID) //TODO
        {
            Review review = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(SQL_ReviewToEdit);
                    command.Parameters.AddWithValue("@reviewID", reviewID);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        review = new Review
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            UserID = Convert.ToInt32(reader["user_id"]),
                            CatID = Convert.ToInt32(reader["cat_id"]),
                            Rating = Convert.ToInt32(reader["rating"]),
                            ReviewComment = Convert.ToString(reader["review"]),
                            SuccessStory = Convert.ToString(reader["success_story"]),
                            Title = Convert.ToString(reader["title"])
                        };
                    }
                }

            }
            catch (SqlException ex)
            {
                throw;
            }

            return review;
        }

        public bool EditReview(Review review)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(SQL_EditReview);
                    command.Parameters.AddWithValue("rating", review.Rating);
                    command.Parameters.AddWithValue("title", review.Title);
                    command.Parameters.AddWithValue("successStory", review.SuccessStory);
                    command.Parameters.AddWithValue("review", review.ReviewComment);
                    command.Parameters.AddWithValue("isApproved", review.IsApproved);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw;
            }

        }

        public bool DeleteReview(int reviewID)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(SQL_DeleteReview);
                    command.Parameters.AddWithValue("@reviewID", reviewID);

                     int trasaction = command.ExecuteNonQuery();
                    if (trasaction>0)
                    {
                        result = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return result;
        }
    }
}