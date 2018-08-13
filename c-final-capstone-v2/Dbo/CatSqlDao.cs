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
        private const string SQL_GetCatSkills = "";
        private const string SQL_ViewCat = "";
        private ISkillDao dao;

        private string connectionString;

        public CatSqlDao(string connectionString, ISkillDao dao)
        {
            this.connectionString = connectionString;
            this.dao = dao;
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
                    cmd.Parameters.AddWithValue("", cat.Colors);
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
            Cat cat = new Cat();

            cat.ID = Convert.ToInt32(sdr[""]);
            cat.Age = Convert.ToInt32(sdr[""]);
            cat.Name = Convert.ToString(sdr[""]);
            cat.Colors = Convert.ToString(sdr[""]);
            cat.Featured = Convert.ToBoolean(sdr[""]);
            cat.HairLenth = Convert.ToString(sdr[""]);
            cat.PictureId = Convert.ToString(sdr[""]);
            cat.PriorExperience = Convert.ToString(sdr[""]);

            cat.Skills = dao.GetCatSkills(cat.ID);

            return cat;
        }
    }
}


