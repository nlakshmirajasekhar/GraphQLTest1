using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models
{
    public partial class Saleslines
    {
        public int Billno { get; set; }
        public int? Sno { get; set; }
        public string Item { get; set; }
        public int? Qty { get; set; }
        public int? Rat { get; set; }

        public virtual Salesheader BillnoNavigation { get; set; }
    }
}
