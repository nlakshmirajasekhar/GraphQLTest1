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
    public class purchasewrapper
    {
        public Purchasesheader purchasesheader { get; set; }
        public List<Purchaseslines> purchaseslines { get; set; }
        public List<Items> itemss { get; set; }
    }
    public class salesWrapper
    {
        public Salesheader salesheader { get; set; }
        public List<Saleslines> salesline { get; set; }
    
    }
    public class materialmanagementwrapper
    {
        public Materialmanagement mgt { set; get; }

        public int sumof { get; set; }
    }


    [ExtendObjectType(Name = "Query")]
    public class Queryclass
    {
        public IQueryable<Items> GetItems([Service] ShopInventory1Context db)
        {
            return db.Items;
        }
        public Items GetItemsbyId([Service] ShopInventory1Context db, int id)
        {
            return db.Items.Where(a => a.Itemid == id).FirstOrDefault();
        }
        public IQueryable<Itemgroups> GetItemGroups([Service] ShopInventory1Context db)
        {
            return db.Itemgroups;
        }
        public Itemgroups GetItemGroupsbyId([Service] ShopInventory1Context db, int grpid)
        {
            return db.Itemgroups.Where(a => a.Grpid == grpid).FirstOrDefault();
        }


        // returning the purchase header and purchase lines based on Mir
        public purchasewrapper GetPurchaselinesbyID([Service] ShopInventory1Context db, int MIR, purchasewrapper pwr)
        {
            pwr.purchasesheader = db.Purchasesheader.Where(a => a.Mir == MIR).FirstOrDefault();
            pwr.purchaseslines = db.Purchaseslines.Where(a => a.Mir == MIR).ToList();
            return pwr;
        }
        public purchasewrapper GetPurchaselines([Service] ShopInventory1Context db, purchasewrapper pwr)
        {
            var size = db.Purchasesheader.Count();
            for (int j = 0; j <= size; j++)
            {
                pwr.purchasesheader = db.Purchasesheader.Where(a => a.Mir == j).FirstOrDefault();
                pwr.purchaseslines = db.Purchaseslines.Where(a => a.Mir == j).ToList();
            }
            return pwr;
        }

        //returning the sales header and sales lines based on Billno
        public salesWrapper GetSaleslineByid([Service] ShopInventory1Context db, int Bill, salesWrapper swr)
        {
            swr.salesheader = db.Salesheader.Where(a => a.Billno == Bill).FirstOrDefault();
            swr.salesline = db.Saleslines.Where(a => a.Billno == Bill).ToList();
            return swr;
        }
        public SalesWrapper GetSaleslines([Service] ShopInventory1Context db, SalesWrapper swr)
        {
            var size = db.Salesheader.Count();
            for (int i = 1; i <= size; i++)
            {
                swr.salesheader = db.Salesheader.Where(a => a.Billno == i).FirstOrDefault();
                swr.saleslines = db.Saleslines.Where(a => a.Billno == i).ToList();
            }
            return swr;
        }

        public IQueryable<Pricelist> GetPricelist([Service] ShopInventory1Context db)
        {
            return db.Pricelist;
        }
        public Pricelist GetPricelistbyid([Service] ShopInventory1Context db, int pid)
        {
            return db.Pricelist.Where(a => a.Itemid == pid).FirstOrDefault();
        }
        /* public List<purchasewrapper> getpurchaseheaderbydate([Service]ShopInventory1Context db,DateTime fdate,DateTime tdate)
          {
            List<purchasewrapper> pwr = new List<purchasewrapper>();
             var  query = (from a in db.Purchasesheader where a.Purchesesdate >= fdate && a.Purchesesdate <= tdate select a).ToList();


              return query ;
          }*/
         
          public List<purchasewrapper> getpurchasebyitems([Service] ShopInventory1Context db,int itemid)
          {
            List<purchasewrapper> prr = new List<purchasewrapper>();
             var qeur = (from a in db.Purchasesheader join b in db.Purchaseslines.Where(a => a.Pitem == itemid) 
                    on a.Mir equals b.Mir into pur from pr in pur
                    select new {
                a.Supplier,
                a.Mir,
                pr.Sno,
                pr.Pitem,
                pr.Qty



            }).ToList();
            prr.AddRange(prr);
              return prr;
          }
    
        public List<Materialmanagement> getmaterialdet([Service]ShopInventory1Context db,int itemno)
        {
            List<Materialmanagement> mg = new List<Materialmanagement>();
            List<materialmanagementwrapper> lstnmgt = new List<materialmanagementwrapper>();
            var idd=from a in db.Materialmanagement.Where(a=>a.Itemid==itemno) group a.Itemid 
           // mg = db.Materialmanagement.ToList();
            //mg.GroupBy(a => a.Itemid).ToDictionary(b => b.Sum(a => a.Qtyin - a.Qtyout)).ToList();
            return mg;
            
        }
        public List<purchasewrapper> getpurchasedet([Service] ShopInventory1Context db,DateTime frdate,DateTime todate)
        {
            List<purchasewrapper> pp = new List<purchasewrapper>();
            purchasewrapper pur = new purchasewrapper();
            List<Purchasesheader> lsp = new List<Purchasesheader>();
            lsp = db.Purchasesheader.ToList();
            List<Purchaseslines> lin = new List<Purchaseslines>();
            
            foreach(Purchasesheader pd in lsp)
            {
                var id = pd.Mir;
                
                    pur.purchaseslines= (from a in db.Purchaseslines where a.Mir == id select a).ToList();

               
                
            }
            pp.Add(pur);

            return pp;

        }

    }
}
