using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class About
    {
        public int Id { get; set; }
        public string header { get; set; }
        public string description { get; set; }
        public string birthOfDate { get; set; }
        public string cityName { get; set; }
        public string favorites { get; set; }
        public string workExperiences { get; set; }
        public int userId { get; set; }
        public string imagePath { get; set; }
        public DateTime createdAt { get; set; }

    }
}