using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using WebMatrix.WebData;
using System.Web.Security;
using Shopping.Filters;

namespace Shopping.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private ApparelShoppingContext db = new ApparelShoppingContext();

        //
        // GET: /Checkout/

        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.UserProfile);
            return View(customers.ToList());
        }

       
        //
        // GET: /Checkout/Create
        [InitializeSimpleMembership]
        public ActionResult Create()
        {
            ViewBag.UserId = WebSecurity.CurrentUserId;
            ViewBag.CustomerCreated = System.DateTime.Now;
            //ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Checkout/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", customer.UserId);
            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}