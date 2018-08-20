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
        private const string SQL_SortByName = "SELECT * FROM Cats ORDER BY name";//could desc
        private const string SQL_SortByNameDesc = "SELECT * FROM Cats ORDER BY name desc";
        private const string SQL_SortByColor = "SELECT * FROM Cats ORDER BY color";
        private const string SQL_SortByAge = "SELECT * FROM Cats ORDER BY age";
        private const string SQL_SortByAgeDesc = "SELECT * FROM Cats ORDER BY age desc";
        private const string SQL_AddCats = "INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, description ) VALUES (@name, @color, @hair_length, @age, @prior_exp, @photo, @description )";
        private const string SQL_ViewCat = "SELECT * FROM cats WHERE Id = @ID";//TODO replace good?
        private const string SQL_RemoveCat = "";//UNDONE
        private const string SQL_AlterCat = "";//UNDONE
        private const string SQL_GetFeaturedCat = "SELECT * FROM Cats WHERE is_featured = 1";
        private const string SQL_EmployCat = "";//UNDONE
        private const string SQL_GetCatId = "SELECT id FROM Cats WHERE photo = @photo";
        private const string SQL_GetColors = "SELECT DISTINCT color FROM cats";

        private ISkillDao dao;
        private string connectionString;

        public CatSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
            dao = new SkillDao(connectionString);
        }
        
        public List<Cat> GetAllCats(string sortOrder = "NameAZ")
        {
            List<Cat> cats = new List<Cat>();
       
            if(sortOrder =="NameZA")
            {
                return SortByNameDesc();
            }
            if(sortOrder == "AgeYoungOld")
            {
                return SortByAge();
            }
            if(sortOrder== "AgeOldYoung")
            {
                return SortByAgeDesc();
            }
            if(sortOrder== "Color")
            {
                return SortByColor();
            }
            return SortByName();
                

            

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
            int resultNum;
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
                    //TODO shit is broken
                    Random rand = new Random();
                    cat.PictureId = cat.Name + rand.Next(4200000) +".jpg";
                    cmd.Parameters.AddWithValue("@photo", cat.PictureId);//eventho we are not actually submitting a photo the cats name(+.jpeg) is added int the DB to make it happy
                    cmd.Parameters.AddWithValue("@is_featured", cat.Featured);
                    cmd.Parameters.AddWithValue("@description", cat.Description);

                    

                    resultNum = cmd.ExecuteNonQuery();//FIX - not a fix, does this variable do anything?

                    
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            dao.AddCatSkillsToTable(GetCatId(cat.PictureId), cat.Skills);//TODO This is janky af, fix later 
            return (resultNum > 0);
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

        public int GetCatId(string picId)
        {
            int catId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_GetCatId);
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@photo", picId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        catId = Convert.ToInt32(reader["Id"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            
            return catId;
        }

        public Cat GetFeaturedCat()
        {
            Cat cat = new Cat();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_GetFeaturedCat);
                    command.Connection = conn;
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

        public void RemoveCat()//UNDONE
        {

        }

        public void AlterCat(int id)//UNDONE
        {

        }

        public bool IsFeaturedCat()//UNDONE admin privilege - per Johns Trello Comment, is this going to be most reviewed cat, highest ranked cat or set by admin
        {
            bool result = false;

            return result;
        }

        public bool isEmployed()//UNDONE admin privilege 
        {
            bool result = false;

            return result;
        }

        public List<string> GetColors()
        {
            List<string> catColors = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_GetColors);
                    command.Connection = conn;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        catColors.Add(reader["color"] as string);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return catColors;
        }

        public List<Cat> SortByName()
        {
            List<Cat> cats = new List<Cat>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_SortByName);
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

        public List<Cat> SortByNameDesc()
        {
            List<Cat> cats = new List<Cat>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_SortByNameDesc);
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

        public List<Cat> SortByColor()
        {
            List<Cat> cats = new List<Cat>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_SortByColor);
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

        public List<Cat> SortByAge()
        {
            List<Cat> cats = new List<Cat>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_SortByAge);
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

        public List<Cat> SortByAgeDesc()
        {
            List<Cat> cats = new List<Cat>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_SortByAgeDesc);
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
    }
}