using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GieAndVince.Models.Db;
using System.Globalization;
using GieAndVince.Models.ViewModel;
using System.Web.Services;

namespace GieAndVince.Controllers
{

    public class SalesManagementController : Controller
    {
        // GET: SalesManagement
        public ActionResult Index(string f = "d", string d = "")
        {
            SalesViewModel salesVm = new SalesViewModel();
            using (GVDBEntities db = new GVDBEntities())
            {
                var sales = db.SalesManagements.ToList();

                var date = DateTime.Now;
                if (d != string.Empty)
                {
                    date = DateTime.Parse(d);
                }
                salesVm.date = date;
                salesVm.filter = f;

                if (f == "d")
                {
                    sales = sales.Where(o => o.Date.Date == date.Date).ToList();
                }
                else if (f == "w")
                {
                    sales = sales.Where(o => getWeekOfYear(o.Date) == getWeekOfYear(date.Date)).ToList();

                    int week = getWeekOfYear(date.Date);
                    double total = 0;
                    salesVm.week = week;

                    foreach (var item in sales)
                    {
                        total += item.TotalSales;
                    }
                    sales = new List<SalesManagement>();
                    sales.Add(new SalesManagement
                    {
                        Cashier = "",
                        Date = date,
                        TotalSales = total
                    });
                }
                else if (f == "m")
                {
                    sales = sales.Where(o => o.Date.Month == DateTime.Now.Month).ToList();

                    double total = 0;
                    foreach (var item in sales)
                    {
                        total += item.TotalSales;
                    }
                    sales = new List<SalesManagement>();
                    sales.Add(new SalesManagement
                    {
                        Cashier = "",
                        Date = date,
                        TotalSales = total
                    });
                }
                else if (f == "y")
                {
                    sales = sales.Where(o => o.Date.Year == DateTime.Now.Year).ToList();
                    double total = 0;
                    foreach (var item in sales)
                    {
                        total += item.TotalSales;
                    }
                    sales = new List<SalesManagement>();
                    sales.Add(new SalesManagement
                    {
                        Cashier = "",
                        Date = date,
                        TotalSales = total
                    });
                }
                salesVm.sales = sales;
                return View(salesVm);
            }
        }

        private int getWeekOfYear(DateTime date)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            return ci.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        [WebMethod]
        public string GetDetails(int Id)
        {
            using (GVDBEntities db = new GVDBEntities())
            {
                var sales = db.TransactionItems.Any(o => o.SalesId == Id) ? db.TransactionItems.Where(o => o.SalesId == Id) : null;
                var salesDetails = db.SalesManagements.FirstOrDefault(o => o.SalesManagementId == Id);

                if (sales == null || salesDetails == null)
                {
                    return "0";
                }

                string salesJson = "[";
                int index = 0;
                foreach (var item in sales)
                {
                    salesJson += string.Format("{{\"name\":\"{1}\", \"price\":\"{2}\", \"quantity\":\"{3}\" }},", index, item.MenuName, item.MenuPrice, item.Quantity);
                    index++;
                }

                salesJson += string.Format("{{\"cashier\":\"{0}\", \"total\":\"{1}\", \"time\":\"{2}\"}}", salesDetails.Cashier, salesDetails.TotalSales, salesDetails.Date.ToShortTimeString());
                //salesJson = salesJson.Substring(0, salesJson.Length - 1);
                salesJson += "]";
                return salesJson;
            }
        }
    }
}