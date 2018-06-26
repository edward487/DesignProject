using GieAndVince.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GieAndVince.Models.ViewModel
{
    public class SalesViewModel
    {
        public IEnumerable<SalesManagement> sales { get; set; }
        public string filter { get; set; }
        public DateTime date { get; set; }
        public int week { get; set; }
    }
}