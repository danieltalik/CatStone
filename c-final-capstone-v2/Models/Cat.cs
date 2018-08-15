using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace c_final_capstone_v2.Models
{
    public class Cat
    {

        public int ID { get; set; }

        [MaxLength(50, ErrorMessage = "Your Cat's Name is too long! Meanie..")]
        public string Name { get; set; }

        public int? Age { get; set; }

        [MaxLength(50, ErrorMessage ="Even Nyan Cat doesn't have that many colors...")]
        public string Colors { get; set; }

        public string HairLength { get; set; }

        [MaxLength(250, ErrorMessage ="Might want to shorten the kitty's resume a bit")]
        public string PriorExperience { get; set; }

        [MaxLength(50, ErrorMessage = "Cat Pictures are fun, long file names aren't. Please Shorten the file name")]
        public string PictureId { get; set; }

        public bool Featured { get; set; }
        public List<string> Skills { get; set; }
        public string Description { get; set; }

        public string CatNoise()
        {
            string meow = "Meow";
            if (Age <= 2) { meow = "mew"; return meow; }
            else if (Age >= 9) { meow = "Merr!"; return meow; }
            else return meow;

        }
    }
}