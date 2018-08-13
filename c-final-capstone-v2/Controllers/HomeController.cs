using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace c_final_capstone_v2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult AddCat()
        {
            return View();
        }

        public ActionResult About()//about our establishment. photo description
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()//Grumpy Cat Photo on Djs computer
        {
            ViewBag.Message = "Your contact page.";

            return View();//returns view w/ only on epic
        }

        public ActionResult CatDetails()
        {
            return View("CatDetails");//not creaed view yet. for sepceific cat
        }

        public ActionResult CareTips()//Dinah can work on this wednesday
        {
            return View("CareTips");
        }

        public ActionResult CatList()
        {
            return View();
        }
    }
}