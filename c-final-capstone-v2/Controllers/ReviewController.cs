using System;
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

        public ReviewController() {
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

        public ActionResult CatReviews(int id)
        {
            Cat theCat = catSqlDao.ViewCat(id);

            ViewBag.Cat = theCat;
            Review myReview = new Review();
            myReview.CatID = theCat.ID;
            myReview.Date = DateTime.Now;

            // TODO uncomment when session is created myReview.UserID = (int)Session["Id"];
            myReview.UserID = 1;
            return View(myReview);
        }

        public ActionResult ReviewCat(int id)
        {
            Cat theCat = catSqlDao.ViewCat(id);

            ViewBag.Cat = theCat;
            Review myReview = new Review();
            myReview.CatID = theCat.ID;
            myReview.Date = DateTime.Now;

            // TODO uncomment when session is created myReview.UserID = (int)Session["Id"];
            
            return View(myReview);
        }

        [HttpPost]
        public ActionResult SubmitReview(Review review)
        {
            review.UserID = 1;
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
                return View("CatReviews", "Review");
            }
        }


        [HttpPost]
        public ActionResult EditReview(Review review)
        {
            bool reviewEdited = false;
            if ((bool)Session["isAdmin"])
            {
                reviewEdited = reviewSqlDao.EditReview(review);
            }
            if (reviewEdited)
            {
                return RedirectToAction("", "");
            }
            else
            {
                return RedirectToAction("", "");
            }
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
            return View("SuccessStories");
        }
    }
}