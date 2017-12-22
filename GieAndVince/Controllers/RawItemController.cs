using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Context;
using GieAndVince.Models.Db;
using GieAndVince.Models.ViewModel;

namespace GieAndVince.Controllers
{
    public class RawItemController : Controller
    {
        GVDBEntities db = new GVDBEntities();
        //Get Raw Item
        public ActionResult Index()
        {
                try
                {
                    var result = db.RawItems.ToList();
                    return View(result);
                }
                catch (Exception e)
                {
                    throw e;
                }
        }
        //Get Raw Item Details
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            RawItemViewModel rItem = db.RawItems.Find(id);
            if (rItem == null)
                return HttpNotFound();
            return View(rItem);
        }
        //Create
        public ActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RawItemViewModel rawItems)
        {
            if (ModelState.IsValid)
            {
                using (GVDBEntities db = new GVDBEntities())
                {
                    try
                    {
                        RawItem nRItem = new RawItem();
                        nRItem.RIName = rawItems.RIName;
                        nRItem.RIDescription = rawItems.RIDescription;
                        nRItem.RIPrice = rawItems.RIPrice;
                        nRItem.RIQuantity = rawItems.RIQuantity;

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
            return View(rawItems);
        }
        //Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            RawItemViewModel rItemEdit = new RawItemViewModel();
            if (rItemEdit == null)
                return HttpNotFound();
            return View(rItemEdit);
        }
        //Post
        [HttpPost]
        public ActionResult Edit(RawItemViewModel rItemEdit)
        {
            if (ModelState.IsValid)
            {
                using (GVDBEntities db = new GVDBEntities())
                {
                    try
                    {
                        RawItem nRItem = new RawItem();
                        nRItem.RIName = rItemEdit.RIName;
                        nRItem.RIDescription = rItemEdit.RIDescription;
                        nRItem.RIPrice = rItemEdit.RIPrice;
                        nRItem.RIQuantity = rItemEdit.RIQuantity;

                        db.Entry(rItemEdit).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            return View(rItemEdit);
        }
        //Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            RawItemViewModel rItemDelete = new RawItemViewModel();
            if (rItemDelete == null)
                return HttpNotFound();
            return View(rItemDelete);
        }
        //Post Delete
        public ActionResult Delete(int? id, RawItemViewModel rItemD)
        {
            RawItemViewModel rItemDelete = new RawItemViewModel();
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    rItemDelete = db.RawItems.Find(id);
                    if (rItemDelete == null)
                        return HttpNotFound();
                    db.RawItems.Remove(rItemDelete);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                return View(rItemDelete);
            }
            catch
            {
                return View();
            }
        }
    }
}