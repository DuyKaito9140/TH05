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
        ProductItem pro = new ProductItem();
        public ActionResult Index() 
        {
            return View(pro.laydsproduct());
        }
    }
}