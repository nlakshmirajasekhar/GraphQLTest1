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
    public class itemwrapper
    {
    
    
    }

    [ExtendObjectType(Name ="Mutation")]
    public class MutationClass
    {
        public String setitems([Service] inventory1Context db,Items it)
        {
            try
            {
                db.Items.Add(it);
                db.SaveChanges();
                return "ok";
            }
            catch(Exception ee)
            {
                return ee.Message;
            }
        }

    }
}
