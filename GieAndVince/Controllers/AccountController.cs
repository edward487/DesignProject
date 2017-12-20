using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models.Db;
using GieAndVince.Models.ViewModel;

namespace GieAndVince.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountViewModel userModel)
        {
            //If the input is all correct it will validate and will enter the db
            if (ModelState.IsValid)
            {
                using (GVDBEntities db = new GVDBEntities())
                {
                    try
                    {
                        Account user = new Account();
                        user.Username = userModel.Username;
                        user.Password = userModel.Password;
                        user.Fullname = userModel.FullName;
                        user.IsAdmin = userModel.IsAdmin;
                        //Add to Database Users then save
                        db.Accounts.Add(user);
                        db.SaveChanges();
                        ModelState.Clear();
                        ViewBag.SuccessMessage = "Registration Successful";
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            return View(userModel);
        }
        //Get Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountViewModel login)
        {
            using (GVDBEntities db = new GVDBEntities())
            {
                //Get the username and password to the database
                var userDetails = db.Accounts.Where(x => x.Username == login.Username && x.Password == login.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    ViewBag.FailedMessage = "Wrong Username or Password";
                    return View("Login", login);
                }
                else
                {
                    Session["UserID"] = userDetails.UserID;
                    Session["UserName"] = userDetails.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult Logout()
        {
            int userId = (int)Session["UserID"];
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}