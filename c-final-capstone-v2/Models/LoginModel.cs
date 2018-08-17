using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace c_final_capstone_v2.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "this field is required")]
        [Display(Name = "Username: ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "this field is required")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password, ErrorMessage = "Bad Password")]
        public string Password { get; set; }
    }
}