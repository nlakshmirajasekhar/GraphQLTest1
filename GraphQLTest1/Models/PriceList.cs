using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models
{
    public partial class PriceList
    {
        public int? Itemid { get; set; }
        public int? Rate { get; set; }

        public virtual Items Item { get; set; }
    }
}
