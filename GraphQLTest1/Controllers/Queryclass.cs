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
        public IQueryable<Purchasesheader> GetPurchaseheader([Service] ShopInventory1Context db)
        {
            return db.Purchasesheader;
        }
        public IQueryable<Purchaseslines> GetPurchaselines([Service] ShopInventory1Context db)
        {
            return db.Purchaseslines;
        }
        public IQueryable<Salesheader> GetSalesheader([Service] ShopInventory1Context db)
        {
            return db.Salesheader;
        }
        public IQueryable<Saleslines> GetSaleslines([Service] ShopInventory1Context db)
        {
            return db.Saleslines;
        }
        public IQueryable<Pricelist> GetPricelist([Service] ShopInventory1Context db)
        {
            return db.Pricelist;
        }
        public IQueryable<Materialmanagement> GetMaterialmanagements([Service] ShopInventory1Context db)
        {
            return db.Materialmanagement;
        }
    }
}
