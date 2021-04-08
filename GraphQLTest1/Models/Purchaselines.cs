using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models
{
    public partial class Purchaselines
    {
        public int Mir { get; set; }
        public int? Sno { get; set; }
        public string Item { get; set; }
        public int? Qty { get; set; }
        public int? Rat { get; set; }

        public virtual Purchaseheader MirNavigation { get; set; }
    }
}
