using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace c_final_capstone_v2.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult CatReviews()
        {
            return View();
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