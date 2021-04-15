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
    public class SalesWrapper
    {
        public Salesheader salesheader { get; set; }
        public List<Saleslines> saleslines { get; set; }

        public int trans { get; set; }

        public String result { get; set; }

    }

    [ExtendObjectType(Name = "Mutation")]
    public class SalesC
    {

        int x = 0;
        public SalesWrapper setSales([Service] ShopInventory1Context db, SalesWrapper sw)
        {
            String msg = "";
            Materialmanagement mr = new Materialmanagement();

            try
            {
                switch (sw.trans)
                {
                    case 1:
                        //getting the id from find id function
                        int id = findMaxID();
                        sw.salesheader.Billno = id;
                        sw.salesheader.Totamt = sw.salesheader.Baseamt + sw.salesheader.Taxes - sw.salesheader.Discount;
                        db.Salesheader.Add(sw.salesheader);
                        //creating a list of sales bills for Consider billno
                        int serialnumber = 1;
                        foreach (Saleslines line in sw.saleslines)
                        {
                            line.Billno = id;
                            line.Sno = serialnumber;
                            serialnumber++;


                        }
                        List<Materialmanagement> mgt = new List<Materialmanagement>();
                        serialnumber = 1;
                        foreach (Saleslines line in sw.saleslines)
                        {
                            // mgt.Add(new Materialmanagement { Traid = id, Sno = serialnumber, Itemid = line.Itemid, Qtyin = line.Qty, Qtyout = 0, Tratype = 2 });
                            serialnumber++;

                        }




                        //adding list to the the database saleslines tables
                        db.Saleslines.AddRange(sw.saleslines);



                        //adding the transaction to material management table
                        db.Materialmanagement.AddRange(mgt);
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 2:
                        int id2 = sw.salesheader.Billno;
                        var usrh = db.Salesheader.Where(a => a.Billno == sw.salesheader.Billno).FirstOrDefault();
                        usrh.Mobile = sw.salesheader.Mobile;
                        usrh.Salesdate = sw.salesheader.Salesdate;
                        usrh.Cname = sw.salesheader.Cname;
                        //removing existing lines in database based on billno
                        var usrs = db.Saleslines.ToList();
                        usrs.RemoveAll(a => a.Billno == id2);
                        var upmr = db.Materialmanagement.ToList();
                        upmr.RemoveAll(a => a.Traid == id2);
                        //again inserting the lines given from input cs for update with the lines and updating the materialmanagement
                        int serialnumberu = 1;
                        foreach (Saleslines line in sw.saleslines)
                        {
                            line.Billno = id2;
                            line.Sno = serialnumberu;
                            serialnumberu++;


                        }
                        List<Materialmanagement> mgtt = new List<Materialmanagement>();
                        serialnumberu = 1;
                        foreach (Saleslines line in sw.saleslines)
                        {
                            // mgtt.Add(new Materialmanagement { Traid = id2, Sno = serialnumberu, Itemid = line.itemid, Qtyin = 0, Qtyout = line.Qty, Tratype = 2 });
                            serialnumberu++;

                        }

                        db.Saleslines.AddRange(sw.saleslines);
                        db.Materialmanagement.AddRange(mgtt);

                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 3:
                        var dlh = db.Salesheader.Where(a => a.Billno == sw.salesheader.Billno).FirstOrDefault();
                        int id3 = sw.salesheader.Billno;

                        db.Salesheader.Remove(dlh);
                        //removing the sales lines & Materialmanagement based on the billno
                        var srsd = db.Saleslines.ToList();
                        srsd.RemoveAll(a => a.Billno == id3);
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



            sw.result = msg;
            return sw;

        }

        private int findMaxID()

        {
            int x = 0;
            ShopInventory1Context db = new ShopInventory1Context();
            var xx = db.Salesheader.FirstOrDefault();

            if (xx != null)
            {
                x = db.Salesheader.Max(a => a.Billno);
            }
            x = x + 1;
            return x;
        }


    }
}
