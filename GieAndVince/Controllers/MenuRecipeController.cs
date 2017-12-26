using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models.Db;
using GieAndVince.Models.ViewModel;

namespace GieAndVince.Controllers
{
    public class MenuRecipeController : Controller
    {
        private GVDBEntities db = new GVDBEntities();
        public ActionResult Index()
        {
            //Generate two models in a single view
            RawItemMenuRecipeViewModel cviewModel = new RawItemMenuRecipeViewModel();
            cviewModel.RawItemModel = db.RawItems.ToList();
            cviewModel.MenuRecipeModel = db.MenuRecipes.ToList();
            return View(cviewModel);
        }
    }
}