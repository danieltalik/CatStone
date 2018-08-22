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

        // GET: Review
        [HttpGet]
        public ActionResult AllReviews(int id)
        {
            reviewSqlDao = new ReviewSqlDao(connectionString);
            List<Review> reviewList = reviewSqlDao.GetCatReviews(id);

            return View("AllReviews", reviewList);
        }

        [HttpPost]
        public ActionResult AddReview(Review review)
        {
            bool reviewAdded = false;
            if (Session["Name"] != null)
            {
                reviewAdded = reviewSqlDao.AddCatReview(review);
            }
            if (reviewAdded)
            {
                return RedirectToAction("", ""); //return to 
            }
            else
            {
                return RedirectToAction("", "");
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