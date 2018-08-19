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
        private const string userNameKey = "UserName";
        private const string isAdminKey = "isAdmin";
        private string connectionString = ConfigurationManager.ConnectionStrings["CatStoneConnection"].ConnectionString;
        protected IUserDao userDao;
        protected ICatSqlDao catDao;
        protected ISkillDao skillDao;

        public CatController(IUserDao userDao)
        {
             userDao = new StaffDao(connectionString);
             catDao = new CatSqlDao(connectionString);
             skillDao = new SkillDao(connectionString);
        }

        public ActionResult Index()
        {
            return View();
        }

        public string CurrentUser
        {
            get
            {
                string username = string.Empty;

                if (Request.Cookies["ASP.NET_SessionId"] == null) { return username; }
                HttpCookie cookie = Request.Cookies["ASP.NET_SessionId"];
                string cookieValue = cookie.Value;

                if (Session[userNameKey] != null)
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
            if (isAdmin)
            {
                Session[isAdminKey] = isAdmin;
            }

            HttpCookie newCookie = new HttpCookie("ASP.NET_SessionId", username);
            newCookie.Expires = DateTime.Now.AddHours(1.0);
            Response.Cookies.Add(newCookie);
        }
        public void LogUserOut()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }

        [ChildActionOnly]
        public ActionResult GetAuthenticatedUsser()
        {
            Staff model = null;

            if (IsAuthenticated)
            {
                model = IUserDao.GetUser(CurrentUser);
            }

            return View("_Layout", model);
        }
    }
}