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
        public ActionResult Register(int? id)
        {
            if (id == null)
                return View();

            AccountViewModel userModel = new AccountViewModel();

            using (GVDBEntities db = new GVDBEntities())
            {
                Account acc = db.Accounts.FirstOrDefault(o => o.UserID == id.Value);

                if (acc == null)
                    return View();

                userModel.FullName = acc.Fullname;
                userModel.IsAdmin = acc.IsAdmin;
                userModel.UserID = acc.UserID;
                userModel.Username = acc.Username;
            }
            return View(userModel);
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
                        if (userModel.UserID == 0)
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
                        else
                        {
                            Account user = db.Accounts.FirstOrDefault(o => o.UserID == userModel.UserID);
                            user.Username = userModel.Username;
                            user.Fullname = userModel.FullName;
                            user.IsAdmin = userModel.IsAdmin;
                            if (userModel.CurrentPassword != string.Empty && userModel.CurrentPassword == user.Password)
                            {
                                user.Password = userModel.NewPassword;
                            }
                            else
                            {
                                ModelState.AddModelError("CurrentPassword", "Wrong Password");
                                return View(userModel);
                            }
                            db.SaveChanges();
                            ModelState.Clear();
                            ViewBag.SuccessMessage = "Update Successful";
                        }
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
        
        [HttpGet]
        public ActionResult List()
        {
            using (GVDBEntities db = new GVDBEntities())
            {
                var accountsVm = new AccountViewModel();
                accountsVm.Accounts = db.Accounts.ToList();
                return View(accountsVm);
            }

        }
    }
}