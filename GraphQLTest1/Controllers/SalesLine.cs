using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using RVR.Models;

namespace RVR.Controllers
{
    public class SLWrapper
    {
        public Salesline lin { get; set; }
        public int trans { get; set; }
        public String result { get; set; }


    }
    [ExtendObjectType(Name = "Mutation")]
    public class SalesLine
    {
        public String setSales([Service] RVRContext db, SLWrapper purl)
        {
            String msg = "";
            try
            {
                switch (purl.trans)
                {
                    case 1:
                        var pr = db.Salesheader.
                            Where(a => a.Billno == purl.lin.Billno).FirstOrDefault();
                        if (pr != null)
                        {
                            db.Salesline.Add(purl.lin);
                            db.SaveChanges();
                            msg = "ok";
                        }
                        else
                        {

                            msg = "not possible";
                        }
                        break;
                    case 2:
                        var u = db.Salesline.Where(a => a.Billno == purl.lin.Billno).FirstOrDefault();
                        u.Rat = purl.lin.Rat;
                        u.Billno = purl.lin.Billno;
                        db.SaveChanges();
                        break;
                    case 3:
                        var d = db.Salesline.Where(a => a.Sno == purl.lin.Sno).FirstOrDefault();
                        db.Salesline.Remove(d);
                        db.SaveChanges();
                        msg = "ok";
                        break;






                }

            }
            catch (Exception ee)
            {
                msg = ee.Message;
            }

            purl.result = msg;
            return msg;
        }
    }
}
