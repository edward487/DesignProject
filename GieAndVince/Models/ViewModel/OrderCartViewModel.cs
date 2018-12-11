using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GieAndVince.Models.Db;

namespace GieAndVince.Models.ViewModel
{
    public class OrderCartViewModel
    {
        public List<MenuRecipe> MenuRecipeList { get; set; }
        public List<Cart> OrderItems { get; set; }
        public int OrderTotal { get; set; }
        public int OrderCount { get; set; }
        public int OrderAmount { get; set; }
        public bool isOrderTakeOut { get; set; }
    }
}