using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models;
using GieAndVince.Models.Db;
using GieAndVince.Models.ViewModel;
using System.Web.Services;

namespace GieAndVince.Controllers
{
    public class OrderCartController : Controller
    {
        private GVDBEntities db = new GVDBEntities();

        // GET: OrderCart
        public ActionResult Index()
        {
            var order = Transaction.GetCart(this.HttpContext);

            //Set up our Viewmodel
            var viewModel = new OrderCartViewModel
            {
                OrderItems = order.GetOrderitems(),
                OrderTotal = (int)order.GetTotal(),
                OrderCount = order.GetCount(),
                MenuRecipeList = db.MenuRecipes.ToList()
            };
            return View(viewModel);
        }
        public ActionResult Orders()
        {
            return View(db.MenuRecipes.ToList());
        }

        //Get ORders/5
        public string AddToTransaction(int id)
        {

            //Retrieve the menurecipe from the database
            var addedMenuRecipe = db.MenuRecipes.FirstOrDefault(menurecipe => menurecipe.MIRID == id);

            //add it to orders
            var order = Transaction.GetCart(this.HttpContext);

            order.AddToTransaction(addedMenuRecipe);


            int orderId = 0;

            if (db.Carts.Any())
            {
                orderId = db.Carts.OrderByDescending(o => o.RecordID).First().RecordID;
            }

            //return RedirectToAction("Index");
            string price = Math.Round((double)addedMenuRecipe.MIRPrice, 2).ToString("F");
            string menuInfo = string.Format("{{ \"Id\":\"{0}\",\"OrderId\":{1},\"Name\":\"{2}\",\"Price\":\"{3}\" }}", addedMenuRecipe.MIRID, orderId, addedMenuRecipe.MIRName, price);

            return menuInfo;
        }

        [HttpPost]
        public ActionResult RemoveFromTransaction(int id)
        {
            //Remove the item from the orders
            var order = Transaction.GetCart(this.HttpContext);

            //GEt the name of the menu recipe to display confirmation
            string menuName = db.Carts.Single(item => item.RecordID == id).MIRName;

            //Remove from orders
            int itemCount = order.RemoveFromOrder(id);

            //Display the confirmation message
            var results = new OrderCartRemoveViewModel
            {
                Message = Server.HtmlEncode(menuName) + "has been removed",
                OrderTotal = order.GetTotal(),
                OrderCount = order.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        //Get Summary
        [ChildActionOnly]
        public ActionResult OrderSummary()
        {
            var order = Transaction.GetCart(this.HttpContext);
            ViewData["OrderCount"] = order.GetCount();
            return PartialView("OrderSummary");
        }


        public ActionResult Payment()
        {

            var orders = db.Carts.ToList();

            double totalPrice = 0;

            foreach (var order in orders)
            {
                int quantity = order.Count == null ? 1 : order.Count.Value;
                totalPrice += (double)(order.MIRPrice * quantity);
            }

            using (GVDBEntities db = new GVDBEntities())
            {
                SalesManagement spd = new SalesManagement
                {
                    Date = DateTime.Now,
                    TotalSales = totalPrice,
                    Cashier = Session["UserName"] != null ? Session["UserName"].ToString() : ""
                };
                db.SalesManagements.Add(spd);
                db.SaveChanges();

                int salesId = db.SalesManagements.OrderByDescending(o => o.SalesManagementId).FirstOrDefault().SalesManagementId;

                foreach (var order in orders)
                {
                    int quantity = order.Count == null || order.Count.Value == 0 ? 1 : order.Count.Value;

                    TransactionItem item = new TransactionItem
                    {
                        MenuId = order.MIRID,
                        MenuName = order.MIRName,
                        MenuPrice = order.MIRPrice,
                        Quantity = quantity,
                        SalesId = salesId
                    };

                    db.TransactionItems.Add(item);
                    db.Carts.Remove(db.Carts.FirstOrDefault(o => o.RecordID == order.RecordID));
                }

                db.SaveChanges();
            }

            return View(orders);
        }
    }
}