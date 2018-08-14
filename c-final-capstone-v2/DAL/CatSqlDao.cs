using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using c_final_capstone_v2.Models;
using System.Configuration;

namespace c_final_capstone_v2.DAL
{
    public class CatSqlDao : ICatSqlDao
    {
        private const string SQL_All_Cats = "SELECT * FROM Cats";
        private const string SQL_AddCats = "INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, description ) VALUES (@name, @color, @hair_length, @age, @prior_exp, @photo, @description )";
        private const string SQL_ViewCat = "SELECT * FROM cats WHERE Id = @ID";
        private const string SQL_RemoveCat = "";//UNDONE

        private ISkillDao dao;
        private string connectionString;

        public CatSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
            dao = new SkillDao(connectionString);

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

        public Cat ViewCat(int id)
        {
            Cat cat = new Cat();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_ViewCat);
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                         cat = (MapRowToCats(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return cat;
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
                    cmd.Parameters.AddWithValue("@name", cat.Name);
                    cmd.Parameters.AddWithValue("@color", cat.Colors);
                    cmd.Parameters.AddWithValue("@hair_length", cat.HairLength);
                    cmd.Parameters.AddWithValue("@age", cat.Age);
                    cmd.Parameters.AddWithValue("@prior_exp", cat.PriorExperience);
                    cmd.Parameters.AddWithValue("@photo", cat.PictureId);
                    cmd.Parameters.AddWithValue("@is_featured", cat.Featured);
                    cmd.Parameters.AddWithValue("@description", cat.Description);

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
            try
            {
                cat.ID = Convert.ToInt32(sdr["Id"]);
                cat.Age = Convert.ToInt32(sdr["age"]);
                cat.Name = Convert.ToString(sdr["name"]);
                cat.Colors = Convert.ToString(sdr["color"]);
                cat.Featured = Convert.ToBoolean(sdr["is_featured"]);
                cat.HairLength = Convert.ToString(sdr["hair_length"]);
                cat.PictureId = Convert.ToString(sdr["photo"]);
                cat.PriorExperience = Convert.ToString(sdr["prior_exp"]);
                cat.Description = Convert.ToString(sdr["description"]);

                cat.Skills = dao.GetCatSkills(cat.ID);

            }
            catch (Exception)
            {


                throw;
            }
            return cat;
        }

        private void RemoveCat()//UNDONE
        {

        }
    }
}


