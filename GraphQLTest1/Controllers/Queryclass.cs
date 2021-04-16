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
    }
    public class salesWrapper
    {
        public Salesheader salesheader { get; set; }
        public List<Saleslines> salesline { get; set; }
    
    }


    [ExtendObjectType(Name ="Query")]
    public class Queryclass
    {
        public IQueryable<Items> GetItems([Service] ShopInventory1Context db)
        {
            return db.Items;
        }
         public Items GetItemsbyId([Service] ShopInventory1Context db,int id)
        {
            return db.Items.Where(a=>a.Itemid==id).FirstOrDefault();
        }
        public IQueryable<Itemgroups> GetItemGroups([Service] ShopInventory1Context db)
        {
            return db.Itemgroups;
        }
        public Itemgroups GetItemGroupsbyId([Service] ShopInventory1Context db,int grpid)
        {
            return db.Itemgroups.Where(a=>a.Grpid==grpid).FirstOrDefault();
        }
     

        // returning the purchase header and purchase lines based on Mir
        public purchasewrapper GetPurchaselinesbyID([Service] ShopInventory1Context db,int MIR,purchasewrapper pwr)
        {
            pwr.purchasesheader = db.Purchasesheader.Where(a => a.Mir == MIR).FirstOrDefault();
            pwr.purchaseslines = db.Purchaseslines.Where(a => a.Mir == MIR).ToList();
            return pwr;
        }
        public purchasewrapper GetPurchaselines([Service] ShopInventory1Context db, purchasewrapper pwr)
        {
            var size = db.Purchasesheader.Count();
            for(int j=0;j<=size;j++)
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
             for(int i=1; i<=size;i++)
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
        public Pricelist GetPricelistbyid([Service] ShopInventory1Context db,int pid)
        {
            return db.Pricelist.Where(a=>a.Itemid==pid).FirstOrDefault();
        }
        public IQueryable<Materialmanagement> GetMaterialmanagements([Service] ShopInventory1Context db)
        {
            return db.Materialmanagement;
        }
        public List<Materialmanagement> GetMaterialmanagementsByid([Service] ShopInventory1Context db,int ptype)
        {
            return db.Materialmanagement.Where(a => a.Tratype == ptype).ToList();
        }
    }
}
