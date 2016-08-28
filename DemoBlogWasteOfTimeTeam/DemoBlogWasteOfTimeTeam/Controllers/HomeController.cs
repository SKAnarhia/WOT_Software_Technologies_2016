using DemoBlogWasteOfTimeTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace DemoBlogWasteOfTimeTeam.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var latestPosts = db.Posts.OrderByDescending(p => p.Date).Take(3);
            return View(latestPosts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
         public ActionResult MySongs()
        {
            var userId = this.User.Identity.GetUserId();
            var allCurrentUserSongs = this.db.Posts.Where(p => p.Author.Id == userId).OrderByDescending(p => p.Date).ToList();

            return View(allCurrentUserSongs);
        }

        
    }
}