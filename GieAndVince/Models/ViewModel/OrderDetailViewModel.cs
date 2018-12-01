using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GieAndVince.Models.Db;

namespace GieAndVince.Models.ViewModel
{
    public class OrderDetailViewModel
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int MIRID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        

        public virtual MenuRecipe MenuRecipe { get; set; }
        public virtual Order Order { get; set; }
    }
}