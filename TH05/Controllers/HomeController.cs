using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH05.Models;

namespace TH05.Controllers
{
    public class HomeController : Controller
    {
        CategoryModel ctm = new CategoryModel();
        LoginModel lg = new LoginModel();
        RegisterModel rm = new RegisterModel();
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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminUser ac) 
        {
            if (lg.checkuser(ac.NameUser, ac.PasswordUser))
            {
                lg.GETuser(ac.NameUser, ac.PasswordUser);
                TH05.Models.Content.Roleaccount = ac.RoleUser;
                TH05.Models.Content.useraccount = ac.NameUser;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AdminUser au)
        {
            if (au.RoleUser == au.PasswordUser)
            {
                rm.them_adminuser(au);
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Register");
            }
            
        }
        public ActionResult Logout() 
        {
            TH05.Models.Content.Roleaccount = "";
            return RedirectToAction("Index");
        }
        
    }
}