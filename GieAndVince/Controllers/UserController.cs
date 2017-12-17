using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models;

namespace GieAndVince.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User userModel)
        {
            if (ModelState.IsValid)
            {
                using (GVDBEntities regDb = new GVDBEntities())
                {
                    regDb.Users.Add(userModel);
                    regDb.SaveChanges();
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Registration Successful";
                }
            }
            return View(userModel);
        }
    }
}