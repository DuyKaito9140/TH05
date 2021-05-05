using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH05.Models;

namespace TH05.Controllers
{
    public class ShoppingCartController : Controller
    {
        DBSportStoresEntities db = new DBSportStoresEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowCart() 
        {

            if (Session["Cart"] == null && TH05.Models.Content.Stepderestion == 0)
            {
                TH05.Models.Content.Stepderestion++;
                return RedirectToAction("ShowCart");
            }                
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }


        public ActionResult AddtoCart(int id)
        {
            var _pro = db.Products.SingleOrDefault(s => s.ProductID == id);
            if(_pro != null)
            {
                GetCart().Add_Product_cart(_pro);
            }
            return RedirectToAction("ShowCart");
        }

        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["idpro"]);
            int _quatity = int.Parse(form["cartQuantity"]);
            cart.update_quatity(id_pro, _quatity);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult Removecart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.remove_cart(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public PartialViewResult BagCarts() 
        {
            int total_qua_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_qua_item = cart.sum_quatity();
            ViewBag.QuatityCart = total_qua_item;
            return PartialView("BagCarts");
        }
    }
}