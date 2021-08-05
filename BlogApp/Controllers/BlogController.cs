using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models.Entity;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        BlogDBEntities db = new BlogDBEntities();
        public ActionResult Index()
        {
            return View(db.Tbl_Post.ToList());
        }

        public ActionResult ReadMore(int id)
        {
            var getContent = db.Tbl_Post.Find(id);
            return View("ReadMore", getContent);
        }
    }
}