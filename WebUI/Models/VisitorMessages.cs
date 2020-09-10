using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class VisitorMessages
    {
        public int Id {get;set;}
        public string name { get; set; }
        public string mail { get; set; }
        public string message { get; set; }
        public DateTime createdAt  { get; set; }

    }
}