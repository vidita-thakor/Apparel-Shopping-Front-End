using System;
using System.Collections.Generic;

namespace Shopping.Models
{
    public partial class Order
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public double OrderSubtotal { get; set; }
        public Nullable<double> OrderShippingCharges { get; set; }
        public Nullable<double> OrderTaxes { get; set; }
        public double OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public string OrderTransactionId { get; set; }
        public string OrderPaymentStatus { get; set; }
        public Nullable<System.DateTime> OrderShippedDate { get; set; }
        public System.DateTime OrderCreated { get; set; }
        public byte[] OrderUpdated { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
