using System;
using System.Collections.Generic;

namespace Shopping.Models
{
    public partial class ParamValue
    {
        public ParamValue()
        {
            this.Inventories = new List<Inventory>();
            this.Inventories1 = new List<Inventory>();
        }

        public int ParamValueId { get; set; }
        public int ProductParamId { get; set; }
        public string ParamValue1 { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Inventory> Inventories1 { get; set; }
        public virtual ProductParam ProductParam { get; set; }
    }
}
