using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GieAndVince.Models.Db;

namespace GieAndVince.Models.ViewModel
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public decimal OrderTotal { get; set; }
        public System.DateTime OrderDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}