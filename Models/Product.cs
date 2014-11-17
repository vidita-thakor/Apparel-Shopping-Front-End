using System;
using System.Collections.Generic;

namespace Shopping.Models
{
    public partial class Product
    {
        public Product()
        {
            this.Inventories = new List<Inventory>();
            this.ProductImages = new List<ProductImage>();
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductLongDescription { get; set; }
        public string ProductUrl { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDeliveryTxt { get; set; }
        public string ProductReturnsTxt { get; set; }
        public string ProductInfoCareTxt { get; set; }
        public System.DateTime ProductCreated { get; set; }
        public byte[] ProductUpdated { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
       // public virtual ProductImage DefaultImage { get { return ProductImage } }
    }
}
