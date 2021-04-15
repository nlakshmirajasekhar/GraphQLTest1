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
    public class itemGwrapper
    {
        public Itemgroups itemG { get; set; }
        public int trans { get; set; }

        public String result { get; set; }

    }

    [ExtendObjectType(Name = "Mutation")]
    public class ItemGroup
    {
        public itemGwrapper setitemG([Service] ShopInventory1Context db,itemGwrapper it)
        {
            String msg = "";
            try
            {
                switch (it.trans)
                {
                    case 1:
                        //Here we are inserting the data into itemgroup
                        var chk = db.Itemgroups.Where(a => a.Grpname == it.itemG.Grpname).FirstOrDefault();
                        if(chk==null)
                        { 
                            //here we are using identity in database so no need findmax for grpid
                            db.Itemgroups.Add(it.itemG);
                            db.SaveChanges();
                        }
                        else
                        {
                            //here we are reassigning the same grpid if the groupname exists already
                            var grpid= db.Itemgroups.Where(a => a.Grpname == it.itemG.Grpname).Select(b => b.Grpid).FirstOrDefault();
                            var grp = db.Itemgroups.Where(a => a.Grpid == grpid).FirstOrDefault();
                            grp.Grpname = it.itemG.Grpname;
                            grp.Maingrp = it.itemG.Maingrp;
                        }
                        msg = "ok";
                        break;
                    case 2:
                        var u = db.Itemgroups.Where(a => a.Grpid == it.itemG.Grpid).FirstOrDefault();
                        u.Grpname = it.itemG.Grpname;
                        u.Maingrp = it.itemG.Maingrp;
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 3:
                        var lstitems = db.Items.Where(a => a.Grpid == it.itemG.Grpid).FirstOrDefault();
                        //here we check the list group consists of dependencies of items if exits then remove the entire dependency list items also
                        if (lstitems == null)
                        {
                            var d = db.Itemgroups.Where(a => a.Grpid == it.itemG.Grpid).FirstOrDefault();
                            db.Itemgroups.Remove(d);
                        }
                        else
                        {
                            //here we are removing based on grpid from list delete all grpid dependency items
                           var lst= db.Items.ToList();
                           lst.RemoveAll(a => a.Grpid == it.itemG.Grpid);
                           
                        }
                        db.SaveChanges();
                        msg = "ok";
                        break;
                }


            }
            catch (Exception ee)
            {
                msg = ee.Message;
            }
            it.result = msg;
            return it;

        }
    }
}
