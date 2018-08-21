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
        //Test git push
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
            Staff staff = userDao.Login(login.Username, login.Password);
            CatController catController = new CatController();
            string username = staff.Username;
            bool isAdmin = staff.IsAdmin;

            catController.LogUserIn(username, isAdmin);
            try
            {
                if (!(bool)Session["isAdmin"])
                {
                    return View("StaffView");
                }
                else if ((bool)Session["isAdmin"])
                {
                    return View("AdminView");
                }

            }
            catch (Exception ex)
            {
                return View("Login");
            }
            return View("Login");

        }
        public ActionResult NewStaffView()
        {
            if ((bool)Session["isAdmin"])
            {
                return View();
            }
            else if (Session["User"] == null)
            {
                return RedirectToAction("Login");
            }
            else return RedirectToAction("StaffView");
        }

        [HttpPost]
        public ActionResult SubmitStaff(Staff newStaff)//TODO tmove to admin controller
        {

            if ((bool)Session["isAdmin"])
            {
                userDao.AddStaff(newStaff);
                //Fix Issue where refresh adds new staff entry over and over
                //Needs to redirect to action instead
                return RedirectToAction("UserHome", new { login = Session["User"] });
            }
            //Fix RedirectToAction
            else return RedirectToAction("UserHome", new {login = Session["User"] });
        }

        public ActionResult Search()
        {
            return View("Search");
        }
    }
}