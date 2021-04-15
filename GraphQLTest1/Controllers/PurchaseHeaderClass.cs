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
    public class PurchaseHeaderwrapper
    {
        public Purchasesheader purchaseheader { get; set; }
        public List<Purchaseslines> purchaselines { get; set; }
       
        public int trans { get; set; }

        public String result { get; set; }

    }

    [ExtendObjectType(Name = "Mutation")]
    public class PurchaseHeaderClass
    {

        int x = 0;
        public PurchaseHeaderwrapper setPurchase([Service] ShopInventory1Context db, PurchaseHeaderwrapper phw)
        {
            String msg = "";
            Materialmanagement mr = new Materialmanagement();
            
            try
            {
                switch (phw.trans)
                {
                    case 1:
                        //getting the id from find id function
                        int id = findMaxID();
                        phw.purchaseheader.Mir= id;
                        //phw.purchaseheader.Baseamt = phw.purchaselines.Sum(a => a.qty*a.Rat);
                        phw.purchaseheader.Totamt = phw.purchaseheader.Baseamt + phw.purchaseheader.Taxes - phw.purchaseheader.Discount;
                        db.Purchasesheader.Add(phw.purchaseheader);
                        //creating a list of purchase bills for Consider Mir
                        int serialnumber= 1;
                       foreach(Purchaseslines line in phw.purchaselines)
                        {
                            line.Mir = id;
                            line.Sno = serialnumber;
                            serialnumber++;


                        }
                        List<Materialmanagement> mgt = new List<Materialmanagement>();
                        serialnumber = 1;
                        foreach (Purchaseslines line in phw.purchaselines)
                        {
                            mgt.Add(new Materialmanagement { Traid = id, Sno = serialnumber, Itemid = line.Pitem, Qtyin = line.Qty, Qtyout = 0, Tratype = 1 });
                            serialnumber++;

                        }
                        



                        //adding list to the the database purchaselines tables
                        db.Purchaseslines.AddRange(phw.purchaselines);
                        

                       
                        //adding the transaction to material management table
                        db.Materialmanagement.AddRange(mgt);
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 2:
                        int id2 = phw.purchaseheader.Mir;
                        var uprh = db.Purchasesheader.Where(a => a.Mir == phw.purchaseheader.Mir).FirstOrDefault();
                        uprh.Mobile = phw.purchaseheader.Mobile;
                        uprh.Purchesesdate = phw.purchaseheader.Purchesesdate;
                        uprh.Supplier = phw.purchaseheader.Supplier;
                        uprh.Purchesesdate = phw.purchaseheader.Purchesesdate;
                        //removing existing lines in database based on mir
                        var uprs = db.Purchaseslines.ToList();
                        uprs.RemoveAll(a => a.Mir == id2);
                        var upmr = db.Materialmanagement.ToList();
                        upmr.RemoveAll(a => a.Traid == id2);
                        //again inserting the lines given from input cs for update with the lines and updating the materialmanagement
                          int serialnumberu= 1;
                       foreach(Purchaseslines line in phw.purchaselines)
                        {
                            line.Mir = id2;
                            line.Sno = serialnumberu;
                            serialnumberu++;


                        }
                        List<Materialmanagement> mgtt = new List<Materialmanagement>();
                        serialnumberu = 1;
                        foreach (Purchaseslines line in phw.purchaselines)
                        {
                            mgtt.Add(new Materialmanagement { Traid = id2, Sno = serialnumberu, Itemid = line.Pitem, Qtyin = line.Qty, Qtyout = 0, Tratype = 1 });
                            serialnumberu++;

                        }
                       
                        db.Purchaseslines.AddRange(phw.purchaselines);
                        db.Materialmanagement.AddRange(mgtt);
                        
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 3:
                        var dlh = db.Purchasesheader.Where(a => a.Mir == phw.purchaseheader.Mir).FirstOrDefault();
                        int id3 = phw.purchaseheader.Mir;
                        
                        db.Purchasesheader.Remove(dlh);
                        //removing the purchase lines & Materialmanagement based on the MIR
                        var prsd = db.Purchaseslines.ToList();
                        prsd.RemoveAll(a => a.Mir == id3);
                        var mrd = db.Materialmanagement.ToList();
                        mrd.RemoveAll(a => a.Traid == id3);



                        db.SaveChanges();



                        break;



                }

            }
            catch (Exception ee)
            {
                msg = ee.Message;
            }



            phw.result = msg;
            return phw;

        }

        private int findMaxID()

        {
            int x = 0;
            ShopInventory1Context db = new ShopInventory1Context();
            var xx = db.Purchasesheader.FirstOrDefault();
            
                if (xx != null)
                {
                    x = db.Purchasesheader.Max(a => a.Mir);
                }
                x = x + 10;
            return x;
        }


    }
}
