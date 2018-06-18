using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GieAndVince.Models.Db;

namespace GieAndVince.Models.ViewModel
{
    public class CartViewModel
    {
        [Key]
        public int RecordID { get; set; }
        public string CartID { get; set; }
        public int MIRID { get; set; }
        public Nullable<int> Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string MIRName { get; set; }
        public decimal MIRPrice { get; set; }

        public virtual MenuRecipe MenuRecipe { get; set; }
    }
}