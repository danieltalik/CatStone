using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using c_final_capstone_v2.Models;
using System.Configuration;


namespace c_final_capstone_v2.DAL
{
    public class StaffDao : IUserDao
    {
        private string connectionString;
        private const string sql_ReturnStaffInfo = "SELECT * FROM Users WHERE @name = name AND @password = password";

        public StaffDao(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Staff Login(string username, string password)
        {
            Staff staff = new Staff();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql_ReturnStaffInfo);
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@name", username);
                    command.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        staff.IsAdmin = Convert.ToBoolean(reader["is_admin"]);
                        staff.Email = Convert.ToString(reader["email"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return staff;
        }

    }
}