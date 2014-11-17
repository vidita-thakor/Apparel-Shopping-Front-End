using System;
using System.Collections.Generic;

namespace Shopping.Models
{
    public partial class Page
    {
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public System.DateTime PageCreated { get; set; }
        public byte[] PageUpdated { get; set; }
    }
}
