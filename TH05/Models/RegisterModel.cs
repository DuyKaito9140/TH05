using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH05.Models
{
    public class RegisterModel
    {
        DBSportStoresEntities db = new DBSportStoresEntities();
        Random r = new Random();
        public Category layOnecategory(int id)
        {
            return db.Categories.First(m => m.IDCate == id);
        }

        public void them_adminuser(AdminUser au)
        {            
            au.RoleUser = "Admin";
            au.ID = r.Next(1, 99999);
            db.AdminUsers.Add(au);
            db.SaveChanges();
        }
    }
}