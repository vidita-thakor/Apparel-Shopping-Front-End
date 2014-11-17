using System;
using System.Collections.Generic;

namespace Shopping.Models
{
    public partial class ProductParam
    {
        public ProductParam()
        {
            this.ParamValues = new List<ParamValue>();
        }

        public int ProductParamId { get; set; }
        public string ProductParamName { get; set; }
        public string ProductParamDescription { get; set; }
        public virtual ICollection<ParamValue> ParamValues { get; set; }
    }
}
