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
        // GET: Review
        public ActionResult CatReviews(int catID)
        {
            reviewSqlDao = new ReviewSqlDao(connectionString);
            List<Review> reviewList = reviewSqlDao.GetCatReviews(catID);

            return View("CatReviews", reviewList);
        }

        public ActionResult AddReview()
        {
            return View();
        }

        public ActionResult ApproveReview()
        {
            if ((bool)Session["isAdmin"])
            {
                return RedirectToAction("", "");
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditReview()
        {
            if ((bool)Session["isAdmin"])
            {
                return RedirectToAction("", "");
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteReview()
        {
            if ( (bool)Session["isAdmin"] )
            {
                return RedirectToAction("", "");
            }
            return RedirectToAction("", "");
        }

    }
}