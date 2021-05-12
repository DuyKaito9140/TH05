using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH05.Models;

namespace TH05.Controllers
{
    public class ProductController : Controller
    {
        DBSportStoresEntities db = new DBSportStoresEntities();
        ProductItem pro = new ProductItem();
        public ActionResult Index() 
        {
            return View(pro.laydsproduct());
        }

        public ActionResult Search(double min = double.MinValue, double max = double.MaxValue)
        {
            var list = db.Products.Where(m => (double)m.Price >= min && (double)m.Price <= max).ToList();
            return View(list); 
        }
    }
}