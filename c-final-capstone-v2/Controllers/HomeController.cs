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
    public class HomeController : Controller
    {
        ICatSqlDao catDao;
        ISkillDao skillDao;
        string connectionString = ConfigurationManager.ConnectionStrings["CatStoneConnection"].ConnectionString;

        public HomeController()
        {
            this.catDao = new CatSqlDao(connectionString);
            this.skillDao = new SkillDao(connectionString);
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult ViewCat(int id)
        {
            Cat theCat = catDao.ViewCat(id);

            return View("ViewCat", theCat);
        }

        public ActionResult AddCat()
        {
            return View();
        }

        public ActionResult SubmitCat(Cat newCat)
        {
            catDao.AddCat(newCat);

            return RedirectToAction("TempImage");//don't want to redirect. on tempimage fo now
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CatDetails()//FIX what is different about this versus Action Result ViewCat(int id) Above?
        {
            return View("ViewCat");//not created view yet. for sepceific cat. is viewcat now
        }

        public ActionResult CareTips()
        {
            return View("CareTips");
        }

        public ActionResult CatList()
        {
            List<Cat> cats = catDao.GetAllCats();
            return View(cats);
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult Us()// cause we're adorable
        {
            return View("Us");
        }

        public ActionResult TempImage()//delete when complete
        {
            return View("TempImage");
        }

        //public ActionResult SubmitCat(Cat newCat) OG method
        //{
        //    catDao.AddCat(newCat);

        //    return RedirectToAction("TempImage");//don't want to redirect. on tempimage fo now
        //}
    }
}