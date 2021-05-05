using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TH05.Models;

namespace TH05.Models
{
    public class CartItems
    {        
        public Product getproduct { get; set; }
        public int getquatity { get; set; }
    }
    public class Cart
    {
        [Key]
        public int IDCart { get; set; }
        List<CartItems> items = new List<CartItems>(); 

        public IEnumerable<CartItems> Items
        {
            get { return items; }
        }

        public void Add_Product_cart(Product pro, int qua = 1)
        {
            var item = Items.FirstOrDefault(s => s.getproduct.ProductID == pro.ProductID);
            if (item == null)
                items.Add(new CartItems
                {
                    getproduct = pro,
                    getquatity = qua
                });
            else
            {
                item.getquatity += qua;
            }
        }

        public int sum_quatity()
        {
            return items.Sum(s => s.getquatity);
        }

        public decimal sum_money()
        {
            var sum = items.Sum(s => s.getquatity * s.getproduct.Price);
            return (decimal)sum;
        }
        public void update_quatity(int id, int new_quatity)
        {
            var item = items.Find(s => s.getproduct.ProductID == id);
            if(item != null)
                item.getquatity = new_quatity;
        }
        public void remove_cart(int id)
        {
            items.RemoveAll(s => s.getproduct.ProductID == id);
        }

        public void clearcart()
        {
            items.Clear();
        }
    }
    
}