using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models.Entity;

namespace BlogApp.Controllers
{
    //only role admin and editor access
    [Authorize(Roles = classes.CustomRoles.Admin_Editor)]
    public class AdminController : Controller
    {
        BlogDBEntities db = new BlogDBEntities();
        public ActionResult Index()
        {
            return View(db.Tbl_Post.ToList());
        }

        //-------- add new blog --------
        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBlog(Tbl_Post post)
        {
            db.Tbl_Post.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------- getting post information for edit post --------
        public ActionResult GetPost(int id)
        {
            var getPost = db.Tbl_Post.Find(id);
            return View("GetPost", getPost);
        }

        //-------- edit post --------
        public ActionResult EditPost(Tbl_Post post)
        {
            var findPost = db.Tbl_Post.Find(post.PostId);

            findPost.PostTitle = post.PostTitle;
            findPost.PostContent = post.PostContent;
            findPost.PostImage = post.PostImage;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------- delete post --------
        public ActionResult DeletePost(int id)
        {
            var getPost = db.Tbl_Post.Find(id);
            db.Tbl_Post.Remove(getPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}