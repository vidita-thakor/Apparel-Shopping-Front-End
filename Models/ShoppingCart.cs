using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;

namespace Shopping.Models
{
    public partial class ShoppingCart
    {

        Shopping.Models.ApparelShoppingContext storeDB = new Shopping.Models.ApparelShoppingContext();

        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Shopping.Models.Inventory Product)
        {

            // Get the matching cart and album instances
            var cartItem = storeDB.Carts.SingleOrDefault(c => c.Cart_id == ShoppingCartId
&& c.InventoryId == Product.InventoryId);


            if (cartItem == null)
            {

                // Create a new cart item if no cart item exists
                cartItem = new Shopping.Models.Cart
                {
                    InventoryId = Product.InventoryId,
                    Cart_id = ShoppingCartId,
                    Count = 1,
                   // DateCreated = DateTime.Now
                };
                storeDB.Carts.Add(cartItem);

            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }
        
            // Save changes
           storeDB.SaveChanges();
        }
        public int EditQuantityCart(int id, int quantity)
        {
            // Get the cart
            var cartItem = storeDB.Carts.SingleOrDefault(
cart => cart.Cart_id == ShoppingCartId
&& cart.InventoryId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (quantity > 0)
                {
                    cartItem.Count = quantity;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.Carts.Remove(cartItem);
                }

                // Save changes
                storeDB.SaveChanges();
            }

            return itemCount;

        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = storeDB.Carts.SingleOrDefault(
cart => cart.Cart_id == ShoppingCartId
&& cart.InventoryId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.Carts.Remove(cartItem);
                }

                // Save changes
                storeDB.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(cart => cart.Cart_id == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }

            // Save changes
            storeDB.SaveChanges();
        }

        public List<Shopping.Models.Cart> GetCartItems()
        {
            return storeDB.Carts.Where(cart => cart.Cart_id == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.Cart_id == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            // Return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in storeDB.Carts
                              where cartItems.Cart_id == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.Inventory.Product.ProductPrice).Sum();
            return total ?? decimal.Zero;
        }

        public int CreateOrder(Shopping.Models.Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new Shopping.Models.OrderItem
                {
                    InventoryId = item.InventoryId,
                    OrderId = order.OrderId,
                    ItemUnitPrice = item.Inventory.Product.ProductPrice,
                    ItemQuantity = item.Count
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Inventory.Product.ProductPrice);
                storeDB.OrderItems.Add(orderDetail);
                //storeDB.OrderItem.Add(orderDetail);

            }

            // Set the order's total to the orderTotal count
            order.OrderTotal = (double)orderTotal;

            // Save the order
            storeDB.SaveChanges();

            // Empty the shopping cart
            EmptyCart();

            // Return the OrderId as the confirmation number
            return order.OrderId;
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Carts.Where(c => c.Cart_id == ShoppingCartId);

            foreach (Shopping.Models.Cart item in shoppingCart)
            {
                item.Cart_id = userName;
            }
            storeDB.SaveChanges();
        }

        internal int EditQuantity(int id)
        {
            throw new NotImplementedException();
        }
    }
}