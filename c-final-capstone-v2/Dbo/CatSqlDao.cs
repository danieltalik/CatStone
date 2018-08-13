using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using c_final_capstone_v2.Models;

namespace c_final_capstone_v2.Dbo
{
    public class CatSqlDao
    {
        private const string SQL_All_Cats = "";
        private const string SQL_AddCats = "";
        private const string SQL_ViewCat = "";

        private string connectionString;

        public CatSqlDao(string conectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cat> GetAllCats()
        {
            List<Cat> cats = new List<Cat>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_All_Cats);
                    command.Connection = conn;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cats.Add(MapRowToCats(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return cats;
        }
        public bool AddCat(Cat cat)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddCats);
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("", cat.Age);
                    cmd.Parameters.AddWithValue("", cat.Color);
                    cmd.Parameters.AddWithValue("", cat.Featured);
                    cmd.Parameters.AddWithValue("", cat.HairLenth);
                    cmd.Parameters.AddWithValue("", cat.Name);
                    cmd.Parameters.AddWithValue("", cat.PictureId);
                    cmd.Parameters.AddWithValue("", cat.PriorExperience);
                    cmd.Parameters.AddWithValue("", cat.Skills);

                    int num = cmd.ExecuteNonQuery();

                    return (num > 0);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        private Cat MapRowToCats(SqlDataReader sdr)
        {
            ////Creates a list of skills from the reader
            //List<string> skills = new List<string>();
            //skills.Add(Convert.ToString(sdr[""]));

            return new Cat
            {
                ID = Convert.ToInt32(sdr[""]),
                Age = Convert.ToInt32(sdr[""]),
                Name = Convert.ToString(sdr[""]),
                Colors = Convert.ToString(sdr[""]),
                //Sets the cat skills property to the created skills list
                //Skills = skills,
                Featured = Convert.ToBoolean(sdr[""]),
                HairLenth = Convert.ToString(sdr[""]),
                PictureId = Convert.ToString(sdr[""]),
                PriorExperience = Convert.ToString(sdr[""])
            };
        }
    }
}


