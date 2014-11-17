using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;

namespace Shopping.Controllers
{
    [Authorize]
    public class OrderItemController : Controller
    {
        private ApparelShoppingContext db = new ApparelShoppingContext();

        //
        // GET: /OrderItem/

        public ActionResult Index(int id)
        {
            var orderitems = db.OrderItems.Include(o => o.Inventory).Include(o => o.Order).Where(b => b.OrderId.Equals(id));
            return View(orderitems.ToList());
        }

        //
        // GET: /OrderItem/Details/5

        public ActionResult Details(int id = 0)
        {
            OrderItem orderitem = db.OrderItems.Find(id);
            if (orderitem == null)
            {
                return HttpNotFound();
            }
            return View(orderitem);
        }

        //
        // GET: /OrderItem/Create

        public ActionResult Create()
        {
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderStatus");
            return View();
        }

        //
        // POST: /OrderItem/Create

        [HttpPost]
        public ActionResult Create(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                db.OrderItems.Add(orderitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId", orderitem.InventoryId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderStatus", orderitem.OrderId);
            return View(orderitem);
        }

        //
        // GET: /OrderItem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OrderItem orderitem = db.OrderItems.Find(id);
            if (orderitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId", orderitem.InventoryId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderStatus", orderitem.OrderId);
            return View(orderitem);
        }

        //
        // POST: /OrderItem/Edit/5

        [HttpPost]
        public ActionResult Edit(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId", orderitem.InventoryId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderStatus", orderitem.OrderId);
            return View(orderitem);
        }

        //
        // GET: /OrderItem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OrderItem orderitem = db.OrderItems.Find(id);
            if (orderitem == null)
            {
                return HttpNotFound();
            }
            return View(orderitem);
        }

        //
        // POST: /OrderItem/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderItem orderitem = db.OrderItems.Find(id);
            db.OrderItems.Remove(orderitem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}