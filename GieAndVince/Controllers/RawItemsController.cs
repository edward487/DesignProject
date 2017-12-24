using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models.Db;


namespace GieAndVince.Controllers
{
    public class RawItemsController : Controller
    {
        private GVDBEntities db = new GVDBEntities();

        // GET: RawItems
        public ActionResult Index()
        {
            //Display the total Expense 
            var result = db.RawItems.Sum(s => s.RIPrice);
            if (result.Equals(null))
            {
                ViewBag.result = 0;
            }
            else
            {   
                ViewBag.result = result;
            }
            return View(db.RawItems.ToList());
        }

        // GET: RawItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RawItem rawItem = db.RawItems.Find(id);
            if (rawItem == null)
            {
                return HttpNotFound();
            }
            return PartialView(rawItem);
        }

        // GET: RawItems/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: RawItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Create([Bind(Include = "RawID,RIName,RIDescription,RIPrice,RIQuantity")] RawItem rawItem)
        {
            if (ModelState.IsValid)
            {
                db.RawItems.Add(rawItem);
                db.SaveChanges();
                return Redirect("Index");
            }

            return Redirect("Index");
        }

        // GET: RawItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RawItem rawItem = db.RawItems.Find(id);
            if (rawItem == null)
            {
                return HttpNotFound();
            }
            return PartialView(rawItem);
        }

        // POST: RawItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RawID,RIName,RIDescription,RIPrice,RIQuantity")] RawItem rawItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rawItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(rawItem);
        }

        // GET: RawItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RawItem rawItem = db.RawItems.Find(id);
            if (rawItem == null)
            {
                return HttpNotFound();
            }
            return PartialView(rawItem);
        }

        // POST: RawItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RawItem rawItem = db.RawItems.Find(id);
            db.RawItems.Remove(rawItem);
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
