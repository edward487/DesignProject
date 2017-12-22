using GieAndVince.Models.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GieAndVince.Models.ViewModel;

namespace GieAndVince.Context
{
    public class GVDBContext:DbContext
    {
        public DbSet<RawItemViewModel> RawItems { get; set; }
    }
}