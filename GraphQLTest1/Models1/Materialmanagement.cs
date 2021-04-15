using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models1
{
    public partial class Materialmanagement
    {
        public int Transno { get; set; }
        public int? Sno { get; set; }
        public int? Itemid { get; set; }
        public int? Traid { get; set; }
        public int? Tratype { get; set; }
        public int? Qtyin { get; set; }
        public int? Qtyout { get; set; }
        public double? Rat { get; set; }

        public virtual Items Item { get; set; }
    }
}
