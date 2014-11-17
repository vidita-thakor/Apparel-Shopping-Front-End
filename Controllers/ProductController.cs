using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using Shopping.ViewModels;

namespace Shopping.Controllers
{
    public class ProductController : Controller
    {
        private ApparelShoppingContext db = new ApparelShoppingContext();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult ViewProduct()
        {
           // var productImg = db.ProductImages.Where(s => s.ImageIsMain.Equals(1));
         // var products1 = db.Products.Include(a => a.ProductImages);
           // var products1=db.Products.Include(a=>a.ProductImages.Select(Where(ProductImage=>ProductImage.ImageIsMain.Equals(true)));
            // prlist = prlist.Where(s => s.ProductImages.ImageIsMain.Contains(1));
            var products1 = from b in db.Products
                            join productimg in db.ProductImages
                            on new { b.ProductId, Letter = true }
                            equals new { productimg.ProductId, Letter = productimg.ImageIsMain }
                           select new  ProductListModel { ProductName = b.ProductName,
                               ProductId=b.ProductId,ProductPrice=b.ProductPrice ,ImageName = productimg.ImageName};

            return View(products1.ToList());
        }
        //
      
        public ActionResult ViewProductDetail(int id = 0)
        {
            Product product = db.Products.Find(id);
            ProductDetailViewModel test = new ProductDetailViewModel();
            test.productId = product.ProductId;
            test.productName = product.ProductName;
            test.productprice = product.ProductPrice;
            test.productDesc = product.ProductLongDescription;
            test.productDelivery = product.ProductDeliveryTxt;
            test.productcareinfo = product.ProductInfoCareTxt;
            test.productReturn = product.ProductReturnsTxt;
            
            ViewBag.colorvalues = new SelectList(db.Inventories.Include(i => i.ParamValue).Where(a => a.ProductId.Equals(id)).Select(b => new { paramvalueid = b.ParamValue.ParamValueId, paravalue = b.ParamValue.ParamValue1 }).Distinct(), "paramvalueid", "paravalue");
            
            ViewBag.sizevalues = new SelectList(db.Inventories.Include(i => i.ParamValue1).Where(a => a.ProductId.Equals(id)), "ParamValue1.ParamValueId", "ParamValue1.ParamValue1");
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }
        public ActionResult Sizevalues(int id,int productid)
        {
            var models = from m in db.Inventories
                         join pv in db.ParamValues
                          on m.ParamSizeValueId
                            equals pv.ParamValueId
                         where m.ParamColorValueId == id && m.ProductId==productid
                         select new ParamSelectList { paramid = m.ParamSizeValueId,paramvalue=pv.ParamValue1,quantity=m.Quantity,inventoryid=m.InventoryId };
            return Json(models.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Colorvalues(int sizeid,int colorid,int productid)
        {
            var models = from m in db.Inventories

                         where m.ParamSizeValueId == sizeid && m.ParamColorValueId == colorid && m.ProductId == productid
                         select new { m.Quantity, m.InventoryId };
            return Json(models.ToList(), JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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