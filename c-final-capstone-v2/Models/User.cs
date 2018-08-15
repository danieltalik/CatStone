using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace c_final_capstone_v2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdministartor { get; set; }
    }
}