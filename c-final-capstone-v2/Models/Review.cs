using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace c_final_capstone_v2.Models
{
    public class Review
    {

        public int? ID { get; set; }

        public int CatID { get; set; }

        public int? UserID { get; set; }

        public DateTime Date { get; set; }

        public int Rating { get; set; }

        [MaxLength(150, ErrorMessage = "Title is too long. Consider moving some of this to the actual review...")]
        public string Title { get; set; }

        [MaxLength(300, ErrorMessage = "We had to put a limit at some point, and you found it. Make it shorter please.")]
        public string SuccessStory { get; set; }
            
        [MaxLength(300, ErrorMessage = "We had to put a limit at some point, and you found it. Make it shorter please.")]
        public string ReviewComment { get; set; }

        public bool IsApproved { get; set; }
    }
}