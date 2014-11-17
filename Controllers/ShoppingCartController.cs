using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using Shopping.ViewModels;


namespace Shopping.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApparelShoppingContext db = new ApparelShoppingContext();
        //
        // GET: /Cart/

        public ActionResult ViewCart()
        {
            return View();
        }

        public ActionResult Address()
        {
            return View();
        }

        public ActionResult Index()
        {
            var cart = Shopping.Models.ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new Shopping.ViewModels.ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            // Return the view
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5

        public ActionResult AddToCart(int id)
        {

            // Retrieve the product  from the database
            var addedAlbum = db.Inventories.Single(inventory => inventory.InventoryId == id);

            // Add it to the shopping cart
            var cart = Shopping.Models.ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedAlbum);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = Shopping.Models.ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string albumName = db.Carts
                .FirstOrDefault(item => item.InventoryId == id).Inventory.Product.ProductName;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new Shopping.ViewModels.ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }
        [HttpPost]
        public ActionResult EditQuantityinCart(int id,int quantity)
        {
            // Remove the item from the cart
            var cart = Shopping.Models.ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string albumName = db.Carts
                .FirstOrDefault(item => item.InventoryId == id).Inventory.Product.ProductName;

            // Remove from cart
            int itemCount = cart.EditQuantityCart(id,quantity);

            // Display the confirmation message
            var results = new Shopping.ViewModels.ShoppingCartRemoveViewModel
            {
                Message = 
                    " Quantity of "+Server.HtmlEncode(albumName) +" has been changed in your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = Shopping.Models.ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }
        public ActionResult Prodimg(int prod_id)
        {
            var pimg = db.ProductImages.SingleOrDefault(a => a.ProductId.Equals(prod_id) && a.ImageIsMain.Equals(true));
            string imagename = pimg.ImageName;
            string imageurl = (string)System.Configuration.ConfigurationManager.AppSettings[3];
            var path = String.Concat(imageurl, imagename);

            return base.File(path, "image/jpeg");
        }
    }
}
