using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH05.Models
{
    public class OrderDetailModel
    {
        DBSportStoresEntities db = new DBSportStoresEntities();
        public IEnumerable<OrderDetail> laydsproduct()
        {
            return db.OrderDetails.ToList();
        }
    }
}