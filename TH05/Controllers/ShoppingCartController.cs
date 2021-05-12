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
        public ActionResult Checkout(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                OrderPro order = new OrderPro();
                order.DateOrder = DateTime.Now;
                order.AddressDeliverry = form["AddressDelivery"];
                order.IDCus = int.Parse(form["CodeCustomer"]);
                db.OrderProes.Add(order);
                foreach(var item in cart.Items)
                {
                    OrderDetail orderdetail = new OrderDetail();
                    orderdetail.IDOrder = order.ID;
                    orderdetail.IDProduct = item.getproduct.ProductID;
                    orderdetail.UnitPrice = (double)item.getproduct.Price;
                    orderdetail.Quantity = item.getquatity;
                    db.OrderDetails.Add(orderdetail);
                }
                db.SaveChanges();
                cart.clearcart();
                return RedirectToAction("Checkout_sucess");
            }
            catch
            {
                return Content("Error Checkout, Please check information...");
            }
        }
        public ActionResult Checkout_sucess()
        {
            return View();
        }
    }
}