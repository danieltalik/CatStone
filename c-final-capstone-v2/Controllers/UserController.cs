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
    public class UserController : CatController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CatStoneConnection"].ConnectionString;
        IUserDao userDao;
        public UserController()
        {
            this.userDao = new UserDao(connectionString);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserHome(LoginModel login)
        {
            //We need to have parameters where session is NOT NULL and checks and redirects to the right view

            //Needs to check if null and build a staff member if session is null and they logged in
            Staff staff = userDao.Login(login.Username, login.Password);

            Session["User"] = staff.IsAdmin;
            //If session is null and user login is valid and not an admin
            if (!(bool)Session["User"])
            {
                return View("StaffView");
            }
            //Returns admin view if session is null and builds it
            else
            {
                return View("AdminView");
            }
            //We also need to check if Model state is vaild and if it is not then redirect to login with error message
        }
        public ActionResult NewStaffView()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login");

            }
            else if ((bool)Session["User"])
            {
                return View();
            }
            else return RedirectToAction("StaffView");
        }

        [HttpPost]
        public ActionResult SubmitStaff(Staff newStaff)//TODO tmove to admin controller
        {
            
            if ((bool)Session["User"])
            {
                userDao.AddStaff(newStaff);
                //Fix Issue where refresh adds new staff entry over and over
                //Needs to redirect to action instead
                return View("AdminView");
            }
            //Fix RedirectToAction
            else return RedirectToAction("UserHome");
        }

        public ActionResult Search()
        {
            return View("Search");
        }
    }
}