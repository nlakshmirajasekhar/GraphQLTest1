using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models1
{
    public partial class Pricelist
    {
        public Pricelist()
        {
            Purchaseslines = new HashSet<Purchaseslines>();
            Saleslines = new HashSet<Saleslines>();
        }

        public int Itemid { get; set; }
        public double? Rat { get; set; }

        public virtual Items Item { get; set; }
        public virtual ICollection<Purchaseslines> Purchaseslines { get; set; }
        public virtual ICollection<Saleslines> Saleslines { get; set; }
    }
}
