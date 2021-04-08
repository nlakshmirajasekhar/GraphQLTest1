using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models
{
    public partial class Items
    {
        public int? Itemid { get; set; }
        public string Itemname { get; set; }
        public int? Grpid { get; set; }
        public string Uom { get; set; }

        public virtual ItemGroups Grp { get; set; }
    }
}
