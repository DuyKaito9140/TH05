using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH05.Models;
using PagedList;

namespace TH05.Controllers
{
    public class ProductController : Controller
    {
        DBSportStoresEntities db = new DBSportStoresEntities();
        ProductItem pro = new ProductItem();

        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var  links = (from l in db.Products
                         select l).OrderBy(x => x.ProductID).ToList();
            int pageSize = 4;

            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Search(double min = double.MinValue, double max = double.MaxValue)
        {
            var list = db.Products.Where(m => (double)m.Price >= min && (double)m.Price <= max).ToList();
            return View(list); 
        }
    }
}