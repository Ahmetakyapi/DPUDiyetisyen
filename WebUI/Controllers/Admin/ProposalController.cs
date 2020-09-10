using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers.Admin
{
    public class ProposalController : Controller
    {
        DiyetisyenContext ctx = new DiyetisyenContext();
        public ActionResult Home()
        {
            ProposalHeader myProposalHeader = ctx.tbProposalHeader.FirstOrDefault();
            List<ProposalContext> myProposalContext = ctx.tbProposalContext.ToList();

            return View(Tuple.Create(myProposalHeader, myProposalContext));

            //return View(new ProposalView() { header = myProposalHeader, context = myProposalContext});
        }

        [HttpGet]
        public ActionResult AddProposalHeader()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProposalHeader(ProposalHeader header)
        {

            ctx.tbProposalHeader.Add(header);
            ctx.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet]
        public ActionResult DeleteProposalHeader(int? headerId)
        {
            var myProposal = ctx.tbProposalHeader.Where(x => x.Id == headerId).FirstOrDefault();
            ctx.tbProposalHeader.Remove(myProposal);
            ctx.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet]
        public ActionResult EditProposalHeader(int? id)
        {
            var myProposal = ctx.tbProposalHeader.Where(x => x.Id == id).FirstOrDefault();
            return View(myProposal);
        }

        [HttpPost]
        public ActionResult EditProposalHeader(int? id, ProposalHeader header, HttpPostedFileBase imagePath)
        {
            var myHeader = ctx.tbProposalHeader.Where(x => x.Id == id).FirstOrDefault();
            myHeader.description = header.description;
            myHeader.name = header.name;
            //if (imagePath != null)
            //{
            //    string filePath = "";
            //    string guid = Guid.NewGuid().ToString() + "_" + Path.GetExtension(imagePath.FileName);
            //    filePath = Path.Combine(Server.MapPath("~/wwwroot/images/staticImages/bigImg/"), guid);
            //    imagePath.SaveAs(filePath);

            //    myArticle.imagePath = "/wwwroot/images/staticImages/bigImg/" + guid;
            //}

            ctx.SaveChanges();
            return RedirectToAction("Home", "Proposal");
        }

        [HttpGet]
        public ActionResult AddProposalContext()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProposalContext(ProposalContext context, HttpPostedFileBase imagePath)
        {

            string filePath = "";
            string guid = Guid.NewGuid().ToString() + "_" + Path.GetExtension(imagePath.FileName);
            filePath = Path.Combine(Server.MapPath("~/wwwroot/images/staticImages/bigImg/"), guid);
            imagePath.SaveAs(filePath);

            context.imagePath = "/wwwroot/images/staticImages/bigImg/" + guid;
            ctx.tbProposalContext.Add(context);
            ctx.SaveChanges();
            return RedirectToAction("Home", "Proposal");
        }

        public ActionResult EditProposalContext(int? id)
        {
            var myProposalContext = ctx.tbProposalContext.Where(x => x.Id == id).FirstOrDefault();
            return View(myProposalContext);
        }

        [HttpPost]
        public ActionResult EditProposalContext(int? id, ProposalContext context, HttpPostedFileBase imagePath)
        {

            var myProposalContext = ctx.tbProposalContext.Where(x => x.Id == id).FirstOrDefault();
            myProposalContext.name = context.name;
            myProposalContext.description = context.description;

            if (imagePath != null)
            {
                string filePath = "";
                string guid = Guid.NewGuid().ToString() + "_" + Path.GetExtension(imagePath.FileName);
                filePath = Path.Combine(Server.MapPath("~/wwwroot/images/staticImages/bigImg/"), guid);
                imagePath.SaveAs(filePath);

                context.imagePath = "/wwwroot/images/staticImages/bigImg/" + guid;
            }
            ctx.SaveChanges();
            return RedirectToAction("Home", "Proposal");
        }

        [HttpGet]
        public ActionResult DeleteProposalContext(int? contextId)
        {
            var myProposalContext = ctx.tbProposalContext.Where(x => x.Id == contextId).FirstOrDefault();
            ctx.tbProposalContext.Remove(myProposalContext);
            ctx.SaveChanges();
            return RedirectToAction("Home");
        }
    }
}