﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models.Entity;

namespace BlogApp.Controllers
{
    //only role 'A' access
    [Authorize(Roles = "A")]
    public class AccountController : Controller
    {
        BlogDBEntities db = new BlogDBEntities();
        public ActionResult Index()
        {
            return View(db.Tbl_User.ToList());
        }

        //-------- add new user --------
        [HttpGet]
        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(Tbl_User user)
        {
            db.Tbl_User.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------- getting user information for edit user --------
        public ActionResult GetUser(int id)
        {
            var getUser = db.Tbl_User.Find(id);
            return View("GetUser", getUser);
        }

        //-------- edit user--------
        public ActionResult EditUser(Tbl_User user)
        {
            var findUser = db.Tbl_User.Find(user.UserId);

            findUser.UserName = user.UserName;
            findUser.UserPassword = user.UserPassword;
            findUser.UserRole = user.UserRole;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------- delete user --------
        public ActionResult DeleteUser(int id)
        {
            var findUser = db.Tbl_User.Find(id);
            db.Tbl_User.Remove(findUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}