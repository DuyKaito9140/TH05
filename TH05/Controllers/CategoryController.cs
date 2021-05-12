using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH05.Models;

namespace TH05.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryModel ctm = new CategoryModel();
        public ActionResult Index()
        {
            return View(ctm.Listcategory());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category ct)
        {
            ctm.them_category(ct);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(ctm.layOnecategory(id));
        }
        [HttpPost]
        public ActionResult Edit(Category ct)
        {
            ctm.sua_category(ct);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ctm.xoa_category(id);
            return RedirectToAction("Index");
        }
    }
}