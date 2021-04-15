using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models1
{
    public partial class Salesheader
    {
        public Salesheader()
        {
            Saleslines = new HashSet<Saleslines>();
        }

        public int Billno { get; set; }
        public DateTime? Salesdate { get; set; }
        public string Cname { get; set; }
        public string Mobile { get; set; }
        public double? Baseamt { get; set; }
        public double? Taxes { get; set; }
        public double? Discount { get; set; }
        public double? Totamt { get; set; }

        public virtual ICollection<Saleslines> Saleslines { get; set; }
    }
}
