using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class RecipesContents
    {
        public int Id {get;set;}
        public int recipesId {get;set;}
        public string scale {get;set;}
        public string name { get; set; }

    }
}