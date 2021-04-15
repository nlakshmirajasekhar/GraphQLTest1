using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models1
{
    public partial class Saleslines
    {
        public int Billno { get; set; }
        public int Sno { get; set; }
        public int? Itemname { get; set; }
        public int? Qty { get; set; }
        public double? Rat { get; set; }

        public virtual Salesheader BillnoNavigation { get; set; }
        public virtual Pricelist ItemnameNavigation { get; set; }
    }
}
