using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Migrations;
using WebUI.Models;

namespace WebUI.Controllers.Home
{
    public class HomeController : Controller
    {
        DiyetisyenContext ctx = new DiyetisyenContext();
        // GET: Default
        public ActionResult Home()
        {
            var myArticles = ctx.tbArticle.ToList();
            return View(myArticles);
        }

        public ActionResult About()


        {
            var myAbout = ctx.tbAbout.FirstOrDefault();
            return View(myAbout);
        }

        public ActionResult Proposal()
        {
            ProposalHeader myProposalHeader = ctx.tbProposalHeader.FirstOrDefault();
            List<ProposalContext> myProposalContext = ctx.tbProposalContext.ToList();

            return View(Tuple.Create(myProposalHeader, myProposalContext));
        }

        public ActionResult Recipes()
        {
            var myRecipes = ctx.tbRecipes.ToList();
            return View(myRecipes);
        }

        public ActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Contact(Contact myContact)
        {

            ctx.tbContact.Add(myContact);
            ctx.SaveChanges();
            return RedirectToAction("Home", "Home");
        }
    }
}