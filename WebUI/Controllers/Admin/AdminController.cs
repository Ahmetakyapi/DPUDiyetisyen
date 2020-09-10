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
    public class AdminController : Controller
    {
        // GET: Admin
        DiyetisyenContext ctx = new DiyetisyenContext();
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Article()
        {
            var myArticles = ctx.tbArticle.ToList();
            return View(myArticles);
        }


        public ActionResult Contact()
        {
            var myContact = ctx.tbContact.ToList();
            return View(myContact);
        }

        [HttpGet]
        public ActionResult AddArticle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddArticle(Article article, HttpPostedFileBase imagePath)
        {

            string filePath = "";
            string guid = Guid.NewGuid().ToString() + "_" + Path.GetExtension(imagePath.FileName);
            filePath = Path.Combine(Server.MapPath("~/wwwroot/images/staticImages/bigImg/"), guid);
            imagePath.SaveAs(filePath);

            article.imagePath = "/wwwroot/images/staticImages/bigImg/" + guid;
            ctx.tbArticle.Add(article);
            ctx.SaveChanges();
            return RedirectToAction("Article", "Admin");
        }

        [HttpGet]
        public ActionResult DeleteArticle(int? articleId)
        {
            var myArticle = ctx.tbArticle.Where(x => x.Id == articleId).FirstOrDefault();
            ctx.tbArticle.Remove(myArticle);
            ctx.SaveChanges();
            return RedirectToAction("Article");
        }



        public ActionResult Login()
        {
            return View();
        }


        //    [HttpPost]
        //    public ActionResult Login(/*Login model*/)
        //    {

        //        //DiyetisyenContext ctx = new DiyetisyenContext();
        //        //if (ModelState.IsValid)
        //        //{
        //        //    var loginedUser = ctx.tbLogin.Where(a => a.username == model.username && a.password == model.password).FirstOrDefault();
        //        //    if (loginedUser != null)
        //        //    {                          
        //        //        return RedirectToAction("Dashboard", "Admin");
        //        //    }
        //        //}
        //        return View(model);
        //    }
        //}
    }
}