using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers.Admin
{
    public class AboutController : Controller
    {
        // GET: About
        DiyetisyenContext ctx = new DiyetisyenContext();
        public ActionResult Index()
        {
            var myAbout = ctx.tbAbout.ToList();
            return View(myAbout);
        }

        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About myAbout, HttpPostedFileBase imagePath)
        {
            string filePath = "";
            string guid = "pp" + "_" + Path.GetExtension(imagePath.FileName);
            filePath = Path.Combine(Server.MapPath("~/wwwroot/images/staticImages/bigImg/"), guid);
            imagePath.SaveAs(filePath);

            myAbout.imagePath = "/wwwroot/images/staticImages/bigImg/" + guid;
            myAbout.createdAt = DateTime.Now;
            ctx.tbAbout.Add(myAbout);
            ctx.SaveChanges();
            return RedirectToAction("Index", "About");
        }

        [HttpGet]
        public ActionResult DeleteAbout(int? aboutId)
        {
            var myAbout = ctx.tbAbout.Where(x => x.Id == aboutId).FirstOrDefault();
            ctx.tbAbout.Remove(myAbout);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAbout(int? id)
        {
            var myAbout = ctx.tbAbout.Where(x => x.Id == id).FirstOrDefault();
            return View(myAbout);
        }

        [HttpPost]
        public ActionResult EditAbout(int? id, About about, HttpPostedFileBase imagePath)
        {
            var myAbout = ctx.tbAbout.Where(x => x.Id == id).FirstOrDefault();
            myAbout.birthOfDate = about.birthOfDate;
            myAbout.cityName = about.cityName;
            myAbout.description = about.description;
            myAbout.favorites = about.favorites;
            myAbout.header = about.header;
            myAbout.workExperiences = about.workExperiences;
            if (imagePath != null)
            {
                string filePath = "";
                string guid = "pp" + "_" + Path.GetExtension(imagePath.FileName);
                filePath = Path.Combine(Server.MapPath("~/wwwroot/images/staticImages/bigImg/"), guid);
                imagePath.SaveAs(filePath);

                myAbout.imagePath = "/wwwroot/images/staticImages/bigImg/" + guid;
            }

            ctx.SaveChanges();
            return RedirectToAction("Index", "About");
        }






    }
}