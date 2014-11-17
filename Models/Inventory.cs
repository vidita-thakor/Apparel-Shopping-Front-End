using System;
using System.Collections.Generic;

namespace Shopping.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            this.Carts = new List<Cart>();
        }

        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int ParamSizeValueId { get; set; }
        public int ParamColorValueId { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ParamValue ParamValue { get; set; }
        public virtual ParamValue ParamValue1 { get; set; }
        public virtual Product Product { get; set; }
    }
}
