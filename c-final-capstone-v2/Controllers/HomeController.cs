﻿using c_final_capstone_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using c_final_capstone_v2.DAL;
using System.Configuration;

namespace c_final_capstone_v2.Controllers
{
    public class HomeController : CatController
    {
        ICatSqlDao catDao;
        ISkillDao skillDao;
        IUserDao userDao;
        string connectionString = ConfigurationManager.ConnectionStrings["CatStoneConnection"].ConnectionString;

        public HomeController()
        {
            this.catDao = new CatSqlDao(connectionString);
            this.skillDao = new SkillDao(connectionString);
            this.userDao = new UserDao(connectionString);
        }

        public ActionResult Index()
        {
            Cat featuredCat = catDao.GetFeaturedCat();
            ViewBag.FeaturedCat = featuredCat;

            return View("Index");
        }

        public ActionResult ViewCat(int id)
        {
            Cat theCat = catDao.ViewCat(id);

            return View("ViewCat", theCat);
        }

        public ActionResult AddCat()//TODO does this do anthing?
        {
            return View();
        }

        public ActionResult SubmitCat(Cat newCat)//TODO tmove to admin controller
        {
            catDao.AddCat(newCat);

            return RedirectToAction("CatList");
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

        public ActionResult CatDetails()
        {
            return View("ViewCat");
        }

        public ActionResult CareTips()
        {
            return View("CareTips");
        }

        public ActionResult CatList(string sort = "NameAZ")
        {
            List<Cat> cats = catDao.GetAllCats(sort);
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

        //TODO change skill 'Comendeering' to 'Commandeering'


        public ActionResult TempImage()//TODO destroy tempImage. most likely won't need
        {
            return View("TempImage");
        }

        public ActionResult Search(string option, string search)
        {
            if(option=="Name")
            {
                return View();
            }
            if(option=="Color")
            {
                return View();
            }
            if(option=="Age")
            {
                return View();
            }
            return View("Search");
        }

      
    }
}
