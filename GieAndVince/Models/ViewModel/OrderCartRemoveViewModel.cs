using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GieAndVince.Models.Db;

namespace GieAndVince.Models.ViewModel
{
    public class OrderCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal OrderTotal { get; set; }
        public int OrderCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}