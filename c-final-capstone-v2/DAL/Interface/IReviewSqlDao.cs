﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_final_capstone_v2.Models;

namespace c_final_capstone_v2.DAL
{
    public interface IReviewSqlDao
    {
        List<Review> GetCatReviews(int id);
        void AddCatReview(Review newReview);
    }
}