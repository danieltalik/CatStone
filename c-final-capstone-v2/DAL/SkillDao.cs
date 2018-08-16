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
        private const string SQL_AssignCatSkills = "INSERT INTO cat_skill (cat_id, skill_id) VALUES (@catId, @skillId)";
        private const string SQL_GetSkillId = "SELECT s.id FROM skills s WHERE s.skill = @skillName";//UNDONE
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

        public void AddCatSkillsToTable(int catId, List<string> skillName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AssignCatSkills);
                    cmd.Connection = conn;

                    foreach (string skill in skillName)
                    {
                        cmd.Parameters.AddWithValue("@catId", catId);
                        cmd.Parameters.AddWithValue("@skillId", ConvertToSkillId(skill));
                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
        }

        public int ConvertToSkillId(string skillName)
        {
            int skillId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQL_GetSkillId);
                    command.Connection = conn;

                    command.Parameters.AddWithValue("@skillName", skillName);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        skillId = Convert.ToInt32(reader["id"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            
            return skillId;
        }
    }
}