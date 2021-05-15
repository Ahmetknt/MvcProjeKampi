using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var query = context.Categories.Count().ToString();
            ViewBag.q1 = query;

            var query2 = context.Headings.Count(h => h.CategoryID == 12).ToString();
            ViewBag.q2 = query2;

            var query3 = context.Writers.Count(w => w.WriterName.Contains("a") || w.WriterName.Contains("A"));
            ViewBag.q3 = query3;

            var query4 = context.Categories.Where(u => u.CategoryID == context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.q4 = query4;

            var query5 = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(y => y.CategoryStatus == false);
            ViewBag.q5 = query5; 


            return View();
        }
    }
}