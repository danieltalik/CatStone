using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using c_final_capstone_v2.Models;
using c_final_capstone_v2.DAL;
using System.Configuration;

namespace c_final_capstone_v2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private string connectionString = ConfigurationManager.ConnectionStrings["CatStoneConnection"].ConnectionString;
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserHome(LoginModel login)
        {
            
            //Will be centered around IUserDao and is a hard coded workaround
            Staff staff = new Staff();
            staff.Username = login.Username;
            staff.Password = login.Password;
            staff.IsAdmin = true;

            if (!staff.IsAdmin)
            {
                return View("StaffView");
            }
            else
            {
                return View("AdminView");
            }
        }
    }
}