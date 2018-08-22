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
    public class ReviewController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CatStoneConnection"].ConnectionString;
        private IReviewSqlDao reviewSqlDao;
        private ICatSqlDao catSqlDao;

        public ReviewController() {
            catSqlDao = new CatSqlDao(connectionString);
        }

        // GET: Review
        [HttpGet]
        public ActionResult CatReviews(int catID)
        {
            reviewSqlDao = new ReviewSqlDao(connectionString);
            
            List<Review> reviewList = reviewSqlDao.GetCatReviews(catID);

            return View("CatReviews", reviewList);
        }

        public ActionResult ReviewCat(int id)
        {
            Cat theCat = catSqlDao.ViewCat(id);

            ViewBag.Cat = theCat;
            Review myReview = new Review();
            myReview.CatID = theCat.ID;
            myReview.Date = DateTime.Now;

            myReview.UserID = (int)Session["Id"];

            return View(myReview);
        }

        [HttpPost]
        public ActionResult SubmitReview(Review review)
        {
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
                return RedirectToAction("ReviewCat", "Review");
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
    }
}