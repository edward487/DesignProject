using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models.Db;
using GieAndVince.Models.ViewModel;

namespace GieAndVince.Controllers
{
    public class RawItemController : Controller
    {
        // GET: RawItem
        public ActionResult RawItem()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RawItem(RawItemViewModel rItem)
        {
            if (ModelState.IsValid)
            {
                using (GVDBEntities db = new GVDBEntities())
                {
                    try
                    {
                        RawItem nRItem = new RawItem();
                        nRItem.RIName = rItem.RIName;
                        nRItem.RIDescription = rItem.RIDescription;
                        nRItem.RIPrice = rItem.RIPrice;
                        nRItem.RIQuantity = rItem.RIQuantity;

                        db.RawItems.Add(nRItem);
                        db.SaveChanges();
                        ModelState.Clear();
                        ViewBag.SuccessMessage = "Raw Item Successfully Added.";
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
                return View(rItem);
        }
    }
}