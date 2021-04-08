using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models
{
    public partial class Purchaseheader
    {
        public int Mir { get; set; }
        public string Suppliername { get; set; }
        public long? Mobile { get; set; }
        public int? Baseamt { get; set; }
        public int? Taxes { get; set; }
        public int? Discount { get; set; }
        public long? Totalamt { get; set; }
    }
}
