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
        private const string SQL_AssignCatSkills = "INSERT INTO cat_skills (cat_id, skill_id) VALUES (@catId, @skillId) ";
        private const string SQL_AddSkill = "";
        private const string SQL_GetSkills = "SELECT s.skill FROM skills s JOIN cat_skill cs ON s.id = cs.skill_id JOIN Cats c ON cs.cat_id = c.Id WHERE c.Id = @Id";

        private string connectionString;

        public SkillDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<string> GetCatSkills(int id)
        {
            List<string> catSkills = new List<string>();

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
                        catSkills.Add(Convert.ToString(reader["skill"]));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return catSkills;
        }

        public void AddCatSkillsToTable(int catId, List<int> skillId)
        
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AssignCatSkills);
                    cmd.Connection = conn;

                    foreach (int id in skillId)
                    {

                        cmd.Parameters.AddWithValue("@catId", catId);
                        cmd.Parameters.AddWithValue("@skillId", id);

                    }
                }
            }
            catch (SqlException e)
            {

                throw;
            }
        }
    }
}