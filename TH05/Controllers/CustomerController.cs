using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH05.Models;

namespace TH05.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomerModel md = new CustomerModel();
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer ct)
        {
            md.them_customer(ct);
            return RedirectToAction("ShowCart","ShoppingCart");
        }
    }
};