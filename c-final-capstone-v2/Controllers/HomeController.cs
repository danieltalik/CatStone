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
        IReviewSqlDao reviewDao;

        string connectionString = ConfigurationManager.ConnectionStrings["CatStoneConnection"].ConnectionString;

        public HomeController()
        {
            this.catDao = new CatSqlDao(connectionString);
            this.skillDao = new SkillDao(connectionString);
            this.userDao = new UserDao(connectionString);
            this.reviewDao = new ReviewSqlDao(connectionString);
        }

        public ActionResult Index()
        {
            Cat featuredCat = catDao.GetFeaturedCat();
            //ViewBag.FeaturedCat = featuredCat;

            return View("Index", featuredCat);
        }

        public ActionResult ViewCat(int id)
        {
            List<Review> reviewList = reviewDao.GetCatReviews(id);

            ViewBag.ReviewList = reviewList;

            Cat theCat = catDao.ViewCat(id);

            return View("ViewCat", theCat);
        }

        public ActionResult AddCat()//TODO does this do anthing?
        {
            if (Session["Name"] != null)
            {
                return View();
            }
            else return View("Index");
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


        public ActionResult Us()// cause we're adorable
        {
            return View("Us");
        }

        //TODO change skill 'Comendeering' to 'Commandeering'


        public ActionResult TempImage()//TODO destroy tempImage. most likely won't need
        {
            return View("TempImage");
        }

        public ActionResult Search(string option, string search)//TODO only takes in casesensitive data. must fix
        {
            List<Cat> cats = catDao.GetAllCats();

            if (option == "Name")
            {
                return View(catDao.GetAllCats().Where(x => x.Name.ToUpper().StartsWith(search.ToUpper()) || search.ToUpper() == null).ToList());
            }
            if (option == "Color")
            {

                return View(catDao.GetAllCats().Where(x => x.Colors.ToUpper().StartsWith(search.ToUpper()) || search.ToUpper() == null).ToList());
            }
            if (option == "Age")
            {

                return View(catDao.GetAllCats().Where(x => x.Age.ToString() == search || search == null).ToList());
            }
            return View("Search", cats);
        }


    }
}
