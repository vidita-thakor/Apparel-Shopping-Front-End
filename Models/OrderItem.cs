using System;
using System.Collections.Generic;

namespace Shopping.Models
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int InventoryId { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemUnitPrice { get; set; }
        public decimal ItemSubtotal { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Order Order { get; set; }
    }
}
