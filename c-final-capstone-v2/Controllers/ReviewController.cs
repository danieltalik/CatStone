﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using c_final_capstone_v2.DAL;
using c_final_capstone_v2.Models;

namespace c_final_capstone_v2.Controllers
{
    public class ReviewController : CatController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CatStoneConnection"].ConnectionString;
        private IReviewSqlDao reviewSqlDao;
        private ICatSqlDao catSqlDao;

        public ReviewController()
        {
            catSqlDao = new CatSqlDao(connectionString);
            reviewSqlDao = new ReviewSqlDao(connectionString);
        }

        // GET: Review
        [HttpGet]
        public ActionResult AllReviews(int id)
        {
            reviewSqlDao = new ReviewSqlDao(connectionString);
            List<Review> reviewList = reviewSqlDao.GetCatReviews(id);

            return View("AllReviews", reviewList);
        }

        public ActionResult HereYeBeginTheReviewProcess(int id)
        {
            Cat theCat = catSqlDao.ViewCat(id);

            ViewBag.Cat = theCat;
            Review myReview = new Review();
            myReview.CatID = theCat.ID;
            myReview.Date = DateTime.Now;

            return View("HereYeBeginTheReviewProcess", myReview);
        }

        [HttpPost]
        public ActionResult SubmitReview(Review review)
        {
            review.UserID = (int)Session["userID"];

            bool reviewAdded = false;

            if (Session["Name"] != null)
            {
                reviewAdded = reviewSqlDao.AddCatReview(review);
            }
            if (reviewAdded)
            {
                return RedirectToAction("CatList", "Home"); //return to 
            }
            else
            {
                return View("HereYeBeginTheReviewProcess", "Review");
            }
        }


        [HttpGet]
        public ActionResult EditReview(int id)
        {
                bool reviewEdited = false;
            Review myReview = reviewSqlDao.ReviewToEdit(id); 

            if (Session["isAdmin"] != null)
            {

                if ((bool)Session["isAdmin"])
                {
                    reviewEdited = reviewSqlDao.EditReview(myReview);
                }
            }
            return View(myReview);

        }

        [HttpPost]
        public ActionResult SubmitEditedReview(Review review)
        {
            reviewSqlDao.EditReview(review);

            return RedirectToAction("CatList", "Home");
        }


        [HttpPost]
        public ActionResult DeleteReview(int reviewID)
        {
            bool reviewDeleted = false;
            if ((bool)Session["isAdmin"])
            {
                reviewDeleted = reviewSqlDao.DeleteReview(reviewID);
            }
            if (reviewDeleted)
            {
                return RedirectToAction("", "");
            }
            else
            {
                return RedirectToAction("", "");

            }
        }
        public ActionResult SuccessStories()
        {
            reviewSqlDao = new ReviewSqlDao(connectionString);
            List<Review> successStories = reviewSqlDao.GetSuccessStories();
            return View(successStories);
        }
        public ActionResult CreateSuccess()
        {

            List<Cat> catList = catSqlDao.GetAllCats();
            ViewBag.catList = catList;
            if (Session["Name"] != null)
            {
                return View("CreateSuccess");
            }
            else return RedirectToAction("UserHome", new { login = Session["Name"] });
        }
        [HttpPost]
        public ActionResult SubmitSucess(Review sucessStory)
        {
            sucessStory.UserID = (int)Session["userID"];
            reviewSqlDao.AddSuccessStory(sucessStory);
            return RedirectToAction("SuccessStories");
        }
    }
}