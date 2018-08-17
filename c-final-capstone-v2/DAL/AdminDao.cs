using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using c_final_capstone_v2.Models;
using System.Data.SqlClient;

namespace c_final_capstone_v2.DAL
{
    public class AdminDao : IUserDao
    {
        //build
        private string connectionString;
        private const string sql_AddStaff = "Insert Into Users(name, email, password, is_admin) VALUES(@name, @email, @password, @is_admin)";

        public AdminDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AddStaff(Staff staff)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_AddStaff);
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@name", staff.Username);
                    cmd.Parameters.AddWithValue("@email", staff.Email);
                    cmd.Parameters.AddWithValue("@password", staff.Password);
                    cmd.Parameters.AddWithValue("@is_admin", staff.IsAdmin);

                    int num = cmd.ExecuteNonQuery();//FIX - not a fix, does this variable do anything?

                    return (num > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}