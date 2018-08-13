using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace c_final_capstone_v2.Models
{
    public class Cat
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public List<string> Color { get; set; }
        public string HairLenth { get; set; }
        public string PriorExperience { get; set; }
        public string PictureId { get; set; }
        public List<string> Skills { get; set; }
    }
}