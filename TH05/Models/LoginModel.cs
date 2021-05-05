using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TH05.Models;

namespace TH05.Models
{
    public class LoginModel
    {
        DBSportStoresEntities db = new DBSportStoresEntities();
        public bool checkuser(string NameUser, string PasswordUser)
        {
            List<AdminUser> listuser = db.AdminUsers.ToList();
            foreach (var item in listuser)
            {
                if (item.NameUser == NameUser && item.PasswordUser.Trim() == PasswordUser)
                {
                    return true;
                }
            }
            return false;
        }
        public AdminUser GETuser(string NameUser, string PasswordUser)
        {
            if (NameUser == "" || PasswordUser.Trim() == "")
            {
                return null;
            }
            AdminUser user = db.AdminUsers.First(a => a.NameUser == NameUser && a.PasswordUser.Trim() == PasswordUser);
            Content.Roleaccount = user.RoleUser;
            Content.useraccount = user.NameUser;
            return user;
        }
    }
}