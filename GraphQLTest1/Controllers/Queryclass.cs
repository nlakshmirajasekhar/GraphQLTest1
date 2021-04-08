using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using GraphQLTest1.Models;

namespace GraphQLTest1.Controllers
{
    [ExtendObjectType(Name ="Query")]
    public class Queryclass
    {
        public IQueryable<Items> GetItems([Service] inventory1Context db)
        {
            return db.Items;
        }
        public IQueryable<ItemGroups> GetItemGroups([Service] inventory1Context db)
        {
            return db.ItemGroups;
        }
        public IQueryable<Purchaseheader> GetPurchaseheader([Service] inventory1Context db)
        {
            return db.Purchaseheader;
        }
        public IQueryable<Purchaselines> GetPurchaselines([Service] inventory1Context db)
        {
            return db.Purchaselines;
        }
        public IQueryable<Salesheader> GetSalesheader([Service] inventory1Context db)
        {
            return db.Salesheader;
        }
        public IQueryable<Saleslines> GetSaleslines([Service] inventory1Context db)
        {
            return db.Saleslines;
        }
        public IQueryable<PriceList> GetPricelist([Service] inventory1Context db)
        {
            return db.PriceList;
        }
        public IQueryable<Materialmanagement> GetMaterialmanagements([Service] inventory1Context db)
        {
            return db.Materialmanagement;
        }
    }
}
