//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GieAndVince.Models.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransactionItem
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public double MenuPrice { get; set; }
        public string MenuName { get; set; }
        public int Quantity { get; set; }
        public int SalesId { get; set; }
    }
}
