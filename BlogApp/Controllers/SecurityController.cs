using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models.Entity;
using System.Web.Security;

namespace BlogApp.Controllers
{
    public class SecurityController : Controller
    {
        BlogDBEntities db = new BlogDBEntities();
        public ActionResult Login()
        {
            return View();
        }

        //Login
        [HttpPost]
        public ActionResult Login(Tbl_User user)
        {
            var userInDb = db.Tbl_User.FirstOrDefault(x => x.UserName == user.UserName && x.UserPassword == user.UserPassword);

            if (userInDb != null)
            {
                FormsAuthentication.SetAuthCookie(userInDb.UserName, false);
                return RedirectToAction("Index", "Blog");
            }

            else
            {
                ViewBag.Message = "Invalid Username or Password";
                return View();
            }
        }

        //Log Out
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}