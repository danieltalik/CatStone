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
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Colors { get; set; }
        public string HairLength { get; set; }
        public string PriorExperience { get; set; }
        public string PictureId { get; set; }
        public bool Featured { get; set; }
        public List<string> Skills { get; set; }
        public string Description { get; set; }
    }
}