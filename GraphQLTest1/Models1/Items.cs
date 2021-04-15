using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models1
{
    public partial class Items
    {
        public Items()
        {
            Materialmanagement = new HashSet<Materialmanagement>();
        }

        public int Itemid { get; set; }
        public string Itemname { get; set; }
        public int? Grpid { get; set; }
        public string Uom { get; set; }

        public virtual Itemgroups Grp { get; set; }
        public virtual Pricelist Pricelist { get; set; }
        public virtual ICollection<Materialmanagement> Materialmanagement { get; set; }
    }
}
