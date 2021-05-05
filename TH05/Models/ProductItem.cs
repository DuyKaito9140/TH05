using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH05.Models
{
    public class ProductItem
    {
        DBSportStoresEntities db = new DBSportStoresEntities();
        public IEnumerable<Product> laydsproduct()
        {
            return db.Products.ToList();
        }
    }
}