using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using GraphQLTest1.Models1;


namespace GraphQLTest1.Controllers
{
    public class itemwrapper
    {
       public Items items { get; set; }

        public int trans { get; set; }

       public String result { get; set; }
      
    }

    [ExtendObjectType(Name ="Mutation")]
    public class ItemsC
    {
        public String setitems([Service] ShopInventory1Context db,itemwrapper it)
        {
            String msg = "";
            try
            {
                switch (it.trans)
                {
                    case 1:
                        var grpi = db.Itemgroups.Where(a => a.Grpid == it.items.Grpid).FirstOrDefault();
                        //checking if the grpid is exit or not
                        if (grpi != null)
                        {
                            db.Items.Add(it.items);
                            db.SaveChanges();
                        }
                        else
                        {
                            msg = "grpid not exits";
                        }
                        msg = "ok";
                        break;
                    case 2:
                        var u = db.Items.Where(a => a.Itemid == it.items.Itemid).FirstOrDefault();
                        u.Itemname = it.items.Itemname;
                        u.Grpid = it.items.Grpid;
                        u.Grp = it.items.Grp;
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 3:
                        var d= db.Items.Where(a => a.Itemid == it.items.Itemid).FirstOrDefault();
                        db.Items.Remove(d);
                        db.SaveChanges();
                        msg = "ok";
                        break;
                }


            }
            catch(Exception ee)
            {
                msg = ee.Message;
            }
            it.result = msg;
            return it.result;

            }
    }
}
