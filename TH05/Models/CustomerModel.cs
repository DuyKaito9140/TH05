using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH05.Models
{
    public class CustomerModel
    {
        DBSportStoresEntities db = new DBSportStoresEntities();
        public IEnumerable<Customer> laydsproduct()
        {
            return db.Customers.ToList();
        }
        public void them_customer(Customer ct)
        {
            db.Customers.Add(ct);
            db.SaveChanges();
        }
    }
}