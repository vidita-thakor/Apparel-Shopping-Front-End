using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>();
        }
        
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string CustomerFirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string CustomerLastName { get; set; }
        [Required(ErrorMessage = "An Email is required")]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Phone/Cell is required")]
        public string CustomerPhone { get; set; }
        public string CustomerHomePhone { get; set; }
        [Required(ErrorMessage = "An Address is required")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string CustomerCity { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string CustomerState { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        public string CustomerZip { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string CustomerCountry { get; set; }
        [Required(ErrorMessage = "An Address is required")]
        public string ShippingAddress { get; set; }
        [Required(ErrorMessage = "Shipping City is required")]
        public string ShippingCity { get; set; }
        [Required(ErrorMessage = "Shipping State is required")]
        public string ShippingState { get; set; }
        [Required(ErrorMessage = "Shipping Postal Code is required")]
        public string ShippingZip { get; set; }
        [Required(ErrorMessage = "Shipping Country is required")]
        public string ShippingCountry { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime CustomerCreated { get; set; }
        public byte[] CustomerUpdated { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public string ReturnDateForDisplay
        {
            get
            {
                return this.CustomerCreated.ToString("d");
            }
        }
    }
    
}
