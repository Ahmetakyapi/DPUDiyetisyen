using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ArticleController : Controller
    {
        DiyetisyenContext ctx = new DiyetisyenContext();
        [HttpGet]

        public ActionResult ArticleDetail(int? id)
        {
            var myArticle = ctx.tbArticle.Where(x => x.Id == id).FirstOrDefault();
            return View(myArticle);
        }

        [HttpGet]
        public ActionResult EditArticle(int? id)
        {
            var myArticle = ctx.tbArticle.Where(x => x.Id == id).FirstOrDefault();
            return View(myArticle);
        }

        [HttpPost]
        public ActionResult EditArticle(int? id, Article article, HttpPostedFileBase imagePath)
        {
            var myArticle = ctx.tbArticle.Where(x => x.Id == id).FirstOrDefault();
            myArticle.name = article.name;
            myArticle.description = article.description;
            myArticle.content = article.content;
            if(imagePath != null)
            {
                string filePath = "";
                string guid = Guid.NewGuid().ToString() + "_" + Path.GetExtension(imagePath.FileName);
                filePath = Path.Combine(Server.MapPath("~/wwwroot/images/staticImages/bigImg/"), guid);
                imagePath.SaveAs(filePath);

                myArticle.imagePath = "/wwwroot/images/staticImages/bigImg/" + guid;
            }

            ctx.SaveChanges();
            return RedirectToAction("Article", "Admin");
        }
    }



}