using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ProposalContext
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; }

    }
}