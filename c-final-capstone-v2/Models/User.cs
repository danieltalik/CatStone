using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace c_final_capstone_v2.Models
{
    public class User
    {
        [Required]
        [MinLength(8, ErrorMessage = "Passwords must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}