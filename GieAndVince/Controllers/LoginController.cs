using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models;

namespace GieAndVince.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Index(User usermodel)
        {
            using (GVDBEntities loginCredentials = new GVDBEntities())
            {
                //Get the username and password to the database
                var userDetails = loginCredentials.Users.Where(x => x.UserName == usermodel.UserName && x.Password == usermodel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    usermodel.LoginErrorMessage = "Wrong Username or Password";
                    return View("Index", usermodel);
                }
                else
                {
                    Session["UserID"] = userDetails.UserID;
                    Session["UserName"] = userDetails.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult Logout()
        {
            int userId = (int)Session["UserID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}