using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using c_final_capstone_v2.Models;

namespace c_final_capstone_v2.DAL
{
    public class SkillDao : ISkillDao
    {
        private const string SQL_GetSkills = "SELECT s.skill FROM skills s JOIN cat_skill cs ON s.id = cs.skill_id JOIN Cats c ON cs.cat_id = c.Id WHERE c.Id = @Id";

        private string connectionString;

        public SkillDao(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Skills> GetCatSkills(int id)
        {
            List<Skills> catSkills = new List<Skills>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_GetSkills);
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        catSkills.Add(MapRowToSkills(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return catSkills;
        }
        
        private Skills MapRowToSkills(SqlDataReader sdr)//TODO: convert to a string instead of an object so that Cat skills property is a list of string and not a list of objects
        {
            return new Skills
            {
                CatID = Convert.ToInt32(sdr["id"]),
                Skill = Convert.ToString(sdr["skill"])
            };
        }
    }
}