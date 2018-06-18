using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models.Db;

namespace GieAndVince.Models
{
    public partial class Transaction
    {
        private GVDBEntities db = new GVDBEntities();

        string TransactionID { get; set; }

        public const string TransactionSessionKey = "CartID";

        public static Transaction GetCart(HttpContextBase context)
        {
            var cart = new Transaction();
            cart.TransactionID = cart.GetCartId(context);
            return cart;
        }

        //Helper method to simplify shopping cart calls
        public static Transaction GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        //Were using HttpContextbase to allow access to cookies
        public string GetCartId(HttpContextBase context)
        {
            if(context.Session[TransactionSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[TransactionSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    //Generate a new GUID using System.guid class
                    Guid tempCartId = new Guid();

                    //Send TempcartId back to client as cookie
                    context.Session[TransactionSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[TransactionSessionKey].ToString();
        }

        public void AddToTransaction(MenuRecipe menuRecipe)
        {
            //Get the matching cart and menurecipe instances
            var orderItem = db.Carts.SingleOrDefault(c => c.CartID == TransactionID && c.MIRID == menuRecipe.MIRID);

            if (orderItem == null)
            {
                //Create a new order item if no order item exists
                orderItem = new Cart
                {
                    MIRID = menuRecipe.MIRID,
                    MIRName = menuRecipe.MIRName,
                    MIRPrice = (decimal)menuRecipe.MIRPrice,
                    CartID = TransactionID,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                db.Carts.Add(orderItem);
            }
            else
            {
                //If the item does exist in the order, then add one to the quantityty
                orderItem.Count++;
            }
            db.SaveChanges();
        }

        public int RemoveFromOrder(int id)
        {
            var orderItem = db.Carts.FirstOrDefault(cart => cart.CartID == TransactionID && cart.RecordID == id);

            int itemCount = 0;

            if (orderItem != null)
            {
                if (orderItem.Count > 1)
                {
                    orderItem.Count--;
                    itemCount = (int)orderItem.Count;
                }
                else
                {
                    db.Carts.Remove(orderItem);
                }

                //Save Changes
                db.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var orderItems = db.Carts.Where(cart => cart.CartID == TransactionID);

            foreach (var orderItem in orderItems)
            {
                db.Carts.Remove(orderItem);
            }

            //Save changes
            db.SaveChanges();
        }

        public List<Cart> GetOrderitems()
        {
            return db.Carts.Where(cart => cart.CartID == TransactionID).ToList();
        }

        public int GetCount()
        {
            //Get the count of each item in the order and sum them up
            int? count = (from orderItems in db.Carts where orderItems.CartID == TransactionID select orderItems.Count).Sum();

            //return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            //Multiply menurecipe price by count of that menurecipe to get the current price for each of those menu recipe in the order summ all menurecipe price to get the ordertotal

            decimal? total = (from orderItems in db.Carts.ToList() where orderItems.CartID == TransactionID select (orderItems.Count * orderItems.MIRPrice)).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var orderItems = GetOrderitems();

            //Iterate over the items in the order, adding the order details for each
            foreach (var item in orderItems)
            {
                var orderDetail = new OrderDetail
                {
                    MIRID = item.MIRID,
                    OrderID = order.OrderID,
                    UnitPrice = item.MIRPrice,
                    Quantity = (int)item.Count
                };

                //Set the order total of the orders
                orderTotal += ((int)item.Count * item.MIRPrice);

                db.OrderDetails.Add(orderDetail);
            }

            //Set the order's total to the orderTotal count
            order.OrderTotal = (int)orderTotal;

            //save the order
            db.SaveChanges();

            //Empty the orders
            EmptyCart();

            //Return the OrderId as the confirmation number
            return order.OrderID;
        }
       
    }
}