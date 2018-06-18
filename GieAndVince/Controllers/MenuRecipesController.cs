using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models.Db;
using GieAndVince.Models.ViewModel;

namespace GieAndVince.Controllers
{
    public class MenuRecipesController : Controller
    {
        private GVDBEntities db = new GVDBEntities();
        //View for CreateList with Raw item and Menu Recipe Model
        public ActionResult CreateList(CombinedModels rm)
        {
            ViewBag.Successmessage = TempData["SuccessMessage"];
            return View(new CombinedModels
            {
                RawItemModel = db.RawItems.ToList(),
                MenuRecipeModel = new MenuRecipe()
            });
        }
        // POST: MenuRecipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CombinedModels m)
        {
            if (ModelState.IsValid)
            {
                db.MenuRecipes.Add(m.MenuRecipeModel);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Item has been successfuly added";
                return RedirectToAction("CreateList");
            }

            return View("CreateList",m);
        }

        // GET: MenuRecipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuRecipe menuRecipe = db.MenuRecipes.Find(id);
            if (menuRecipe == null)
            {
                return HttpNotFound();
            }
            return PartialView(menuRecipe);
        }

        // POST: MenuRecipes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuRecipe menuRecipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuRecipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(menuRecipe);
        }

        // GET: MenuRecipes
        public ActionResult Index()
        {
            //Generate two models in a single view
            var cviewModel = new CombinedModels();
            cviewModel.MenuRecipeList = db.MenuRecipes.ToList();
            return View(cviewModel);
        }

        // GET: MenuRecipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuRecipe menuRecipe = db.MenuRecipes.Find(id);
            if (menuRecipe == null)
            {
                return HttpNotFound();
            }
            return PartialView(menuRecipe);
        }


        // GET: MenuRecipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuRecipe menuRecipe = db.MenuRecipes.Find(id);
            if (menuRecipe == null)
            {
                return HttpNotFound();
            }
            return PartialView(menuRecipe);
        }

        // POST: MenuRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuRecipe menuRecipe = db.MenuRecipes.Find(id);
            db.MenuRecipes.Remove(menuRecipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
