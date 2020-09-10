using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Migrations;
using WebUI.Models;

namespace WebUI.Controllers.Admin
{
    public class RecipesController : Controller
    {

        DiyetisyenContext ctx = new DiyetisyenContext();
        // GET: Recipes
        public ActionResult Home()
        {
            var myRecipes = ctx.tbRecipes.ToList();
            return View(myRecipes);
        }

        [HttpGet]
        public ActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRecipe(Recipes myRecipe, HttpPostedFileBase imagePath)
        {
            string filePath = "";
            string guid = Guid.NewGuid().ToString() + "_" + Path.GetExtension(imagePath.FileName);
            filePath = Path.Combine(Server.MapPath("~/wwwroot/images/staticImages/bigImg/"), guid);
            imagePath.SaveAs(filePath);

            myRecipe.imagePath = "/wwwroot/images/staticImages/bigImg/" + guid;
            ctx.tbRecipes.Add(myRecipe);
            ctx.SaveChanges();
            return RedirectToAction("Home");

        }

        [HttpGet]
        public ActionResult DeleteRecipe(int? recipeId)
        {
            var myRecipe = ctx.tbRecipes.Where(x => x.Id == recipeId).FirstOrDefault();
            ctx.tbRecipes.Remove(myRecipe);
            ctx.SaveChanges();
            return View("Home");
        }


        public ActionResult EditRecipe(int? id)
        {
            var myRecipe = ctx.tbRecipes.Where(x => x.Id == id).FirstOrDefault();
            return View(myRecipe);
        }

        [HttpPost]
        public ActionResult EditRecipe(int? id, Recipes recipe, HttpPostedFileBase imagePath)
        {
            var myRecipes = ctx.tbRecipes.Where(x => x.Id == id).FirstOrDefault();
            myRecipes.name = recipe.name;
            myRecipes.description = recipe.description;
            myRecipes.content = recipe.content;
            myRecipes.forWhoPerson = recipe.forWhoPerson;
            myRecipes.foodTime = recipe.foodTime;
            if (imagePath != null)
            {
                string filePath = "";
                string guid = Guid.NewGuid().ToString() + "_" + Path.GetExtension(imagePath.FileName);
                filePath = Path.Combine(Server.MapPath("~/wwwroot/images/staticImages/bigImg/"), guid);
                imagePath.SaveAs(filePath);

                myRecipes.imagePath = "/wwwroot/images/staticImages/bigImg/" + guid;
            }

            ctx.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet]
        public ActionResult RecipeDetail(int? id)
        {
            var myRecipe = ctx.tbRecipes.Where(x => x.Id == id).FirstOrDefault();
            return View(myRecipe);
        }
    }
}