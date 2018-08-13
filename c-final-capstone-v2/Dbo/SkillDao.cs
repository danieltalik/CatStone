using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using c_final_capstone_v2.Models;

namespace c_final_capstone_v2.Dbo
{
    public class SkillDao : ISkillDao
    {
        private const string SQL_GetSkills = "";

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

        private Skills MapRowToSkills(SqlDataReader sdr)
        {
            return new Skills
            {
                CatID = Convert.ToInt32(sdr[""]),
                Skill = Convert.ToString(sdr[""])
            };
        }
    }
}