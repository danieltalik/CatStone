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
        private string connectionString = ConfigurationManager.ConnectionStrings["CatStoneConnection"].ConnectionString;
        IUserDao userDao;

        public UserController()
        {
            this.userDao = new StaffDao(connectionString);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserHome(LoginModel login)
        {

            //Will be centered around IUserDao and is a hard coded workaround
            Staff staff = userDao.Login(login.Username, login.Password);

            Session["User"] = staff.IsAdmin;

            if (!(bool)Session["User"])
            {
                return View("StaffView");
            }
            else
            {
                return View("AdminView");
            }
        }
        public ActionResult NewStaffView()
        {
            if ((bool)Session["User"])
            {
                return View();
            }
            else return RedirectToAction("StaffView");
        }

        [HttpPost]
        public ActionResult SubmitStaff(Staff newStaff)//TODO tmove to admin controller
        {
            AdminDao admin = new AdminDao(connectionString);
            admin.AddStaff(newStaff);
            return View("AdminView");
        }
    }
}