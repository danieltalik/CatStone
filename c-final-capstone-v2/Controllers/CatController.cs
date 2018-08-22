using c_final_capstone_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using c_final_capstone_v2.DAL;
using System.Configuration;
namespace c_final_capstone_v2.Controllers
{
    public class CatController : Controller
    {
        //Set two session variables to hold one for username and another for admin status
        //Establish connections and DAOs in one area 
        //Implements Login and Logout methods
        // "Login" button changes to "Logout"
        // GET: Cat
        private const string userNameKey = "Name";
        private const string isAdminKey = "isAdmin";
        private string connectionString = ConfigurationManager.ConnectionStrings["CatStoneConnection"].ConnectionString;
        protected IUserDao userDao;
        protected ICatSqlDao catDao;
        protected ISkillDao skillDao;

        public CatController()
        {
            userDao = new UserDao(connectionString);
            catDao = new CatSqlDao(connectionString);
            skillDao = new SkillDao(connectionString);
        }

        public string CurrentUser
        {
            get
            {
                string username = string.Empty;

                if (Session[userNameKey] == null)
                {
                    return username;
                }
                else
                {
                    username = (string)Session[userNameKey];
                }
                return username;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return Session[userNameKey] != null;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return Session[isAdminKey] != null;
            }
        }
        public void LogUserIn(string username, bool isAdmin)
        {

            Session[userNameKey] = username;

            Session[userNameKey] = username;
            Session[isAdminKey] = isAdmin;
            
        }
        public void LogUserOut()
        {
            Session.Abandon();
            //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }

        [ChildActionOnly]
        public ActionResult GetAuthenticatedUser()
        {
            Staff model = null;

            if (IsAuthenticated)
            {
                //model = IUserDao.GetUser(CurrentUser);
                model = userDao.GetUser(CurrentUser);
            }

            return View("_Layout", model);
        }

        //method from here to call determine if someone is logged in
    }
}