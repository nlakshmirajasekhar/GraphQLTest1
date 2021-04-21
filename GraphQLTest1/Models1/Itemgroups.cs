using System;
using System.Collections.Generic;

namespace GraphQLTest1.Models1
{
    public partial class Itemgroups
    {
      /*  public Itemgroups()
        {
            Items = new HashSet<Items>();
        }*/

        public int Grpid { get; set; }
        public string Grpname { get; set; }
        public string Maingrp { get; set; }

        public virtual ICollection<Items>? Items { get; set; }
    }
}
