using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models1
{
    public partial class Purchaseslines
    {
        public int Mir { get; set; }
        public int Sno { get; set; }
        public int? Pitem { get; set; }
        public int? Qty { get; set; }
        public double? Rat { get; set; }

        public virtual Purchasesheader MirNavigation { get; set; }
        public virtual Pricelist PitemNavigation { get; set; }
    }
}
