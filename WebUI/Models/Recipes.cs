using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class Recipes
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string imagePath { get; set; }
        public string content { get; set; }
        public string description { get; set; }
        public string foodTime { get; set; }
        public int forWhoPerson { get; set; }
    }
}