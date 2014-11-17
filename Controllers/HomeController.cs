using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using System.Data.Entity.Infrastructure;


namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        private ApparelShoppingContext db = new ApparelShoppingContext();

        
        public ActionResult Index()
        {
            Page page = db.Pages.Find(1);
            return View(page);
        }

        public ActionResult About()
        {
            Page page = db.Pages.Find(2);
            return View(page);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Authenticate()
        {
            ViewBag.Message = "";
            return View();
        }


        public ActionResult Sitemap()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult TermsAndCondition()
        {
            Page page = db.Pages.Find(3);
            return View(page);
        }

        public ActionResult ShippingAndReturn()
        {
            Page page = db.Pages.Find(4);
            return View(page);
        }

        public ActionResult Sizeguide()
        {
            Page page = db.Pages.Find(5);
            return View(page);
        }

        public ActionResult Help()
        {
            Page page = db.Pages.Find(6);
            return View(page);
        }
    }
}
