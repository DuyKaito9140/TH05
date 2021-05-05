using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH05.Models
{
    public class CategoryModel
    {
        DBSportStoresEntities db = new DBSportStoresEntities();
        public IEnumerable<Category> Listcategory()
        {
            return db.Categories.ToList();
        }

        public Category layOnecategory(int id)
        {
            return db.Categories.First(m => m.IDCate == id);
        }

        public void them_category(Category ct)
        {
            db.Categories.Add(ct);
            db.SaveChanges();
        }

        public void sua_category(Category ct)
        {
            Category x = layOnecategory(ct.IDCate);
            x.IDCate = ct.IDCate;
            x.NameCate = ct.NameCate;
            db.SaveChanges();
        }

        public void xoa_category(int id) 
        {
            Category x = layOnecategory(id);
            db.Categories.Remove(x);
            db.SaveChanges();
        }
    }
}