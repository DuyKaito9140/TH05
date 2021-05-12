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
        
        LoginModel lg = new LoginModel();
        RegisterModel rm = new RegisterModel();
        public ActionResult Index()
        {
            return View();
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