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
    public class Pricewrapper
    {
        public Pricelist price { get; set; }
        public int trans { get; set; }

        public String result { get; set; }

    }

    [ExtendObjectType(Name = "Mutation")]
    public class PricelistC
    {
        public String setPriceL([Service] ShopInventory1Context db, Pricewrapper pr)
        {
            var itemchk = db.Items.Where(a => a.Itemid == pr.price.Itemid).FirstOrDefault();

            String msg = "";
            try
            {
                if (DecChk(pr.price.Itemid))
                {
                    switch (pr.trans)
                    {
                        case 1:

                            db.Pricelist.Add(pr.price);
                            db.SaveChanges();

                            msg = "ok";
                            break;
                        case 2:
                            var u = db.Pricelist.Where(a => a.Itemid == pr.price.Itemid).FirstOrDefault();
                            u.Rat = pr.price.Rat;

                            db.SaveChanges();
                            msg = "ok";
                            break;
                        case 3:
                            var d = db.Pricelist.Where(a => a.Itemid == pr.price.Itemid).FirstOrDefault();
                            db.Pricelist.Remove(d);
                            db.SaveChanges();
                            msg = "ok";
                            break;
                    }

                }
                else
                {
                    msg = "item not exists";
                }


            }
            catch (Exception ee)
            {
                msg = ee.Message;
            }
            pr.result = msg;
            return pr.result;

        }
        public Boolean DecChk(int itemid)
        {
            Boolean b = false;
            ShopInventory1Context db = new ShopInventory1Context();
            var itemids = db.Items.Where(a => a.Itemid == itemid).FirstOrDefault();
            if(itemids!=null)
            {
                b = true;
            }
            return b;
        }
    }
}
