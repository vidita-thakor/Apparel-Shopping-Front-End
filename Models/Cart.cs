using System;
using System.Collections.Generic;

namespace Shopping.Models
{
    public partial class Cart
    {
        public long CartSerialId { get; set; }
        public string Cart_id { get; set; }
        public int InventoryId { get; set; }
        public int Count { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
