using System;
using System.Collections.Generic;

namespace Shopping.Models
{
    public partial class ProductImage
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageTitle { get; set; }
        public string ImageAltText { get; set; }
        public string ImageName { get; set; }
        public bool ImageIsMain { get; set; }
        public System.DateTime ImageCreated { get; set; }
        public virtual Product Product { get; set; }
    }
}
