using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH05.Models;

namespace TH05.Controllers
{   
    public class Ordertop5Controller : Controller
    {
        // GET: Ordertop5
        DBSportStoresEntities db = new DBSportStoresEntities();
        ProductItem pr = new ProductItem();
        OrderDetailModel or = new OrderDetailModel();
        public ActionResult Top5()
        {
            var listpro = pr.laydsproduct().ToList();
            var listdetail = or.laydsproduct().ToList();

            var query = from od in listdetail
                        join p in listpro on od.IDProduct equals p.ProductID into tbl
                        group od by new
                        {
                            idpro = od.IDProduct,
                            namepro = od.Product.NamePro,
                            imagepro = od.Product.ImagePro,
                            pricepro = od.Product.Price
                        } into gr
                        orderby gr.Sum(s => s.Quantity) descending
                        select new ViewM {
                            IDPro = gr.Key.idpro,
                            NamePro = gr.Key.namepro,
                            ImgPro = gr.Key.imagepro,
                            PricePro = (decimal)gr.Key.pricepro,
                            Sum_Quantity = gr.Sum(s => s.Quantity)
                        };

            return View(query.Take(5).ToList());
        }
    }
}