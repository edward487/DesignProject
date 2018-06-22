using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models.Db;

namespace GieAndVince.Controllers
{

    public class SalesManagementController : Controller
    {
        private GVDBEntities db = new GVDBEntities();
        // GET: SalesManagement
        public ActionResult Index()
        {
            return View(db.SalesManagements.ToList());
        }
    }
}