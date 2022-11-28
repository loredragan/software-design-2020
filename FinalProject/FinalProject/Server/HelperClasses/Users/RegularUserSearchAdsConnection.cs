using FinalProject;
using FinalProject.Models;
using Server.RequestHandler.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.HelperClasses
{
    class RegularUserSearchAdsConnection
    {
        public static IEnumerable<BaseModel> HandleReadRequests(RegularUserSearchAdsHandler handler, Message received)
        {
            if(received.Content.Equals("SearchWithFilter", StringComparison.InvariantCultureIgnoreCase))
            {
                return handler.GetModelsFiltered(received.ValuePairs, received.UserId);
            }
            else if(received.Content.Equals("SearchByRating", StringComparison.InvariantCultureIgnoreCase))
            {
                return handler.SearchByRating(received.ValuePairs, received.UserId);
            }

            return null;
        }
    }
}
