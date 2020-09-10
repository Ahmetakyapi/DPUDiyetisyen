using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace WebUI.Models
{
    public class Contact
    {
        public int Id {get;set;}

        public string name { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string message { get; set; }

    }
}