using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3;
using Assignment_3.Models;
using Server.RequestHandler.Users;

namespace Server.HelperClasses
{
    static class RegularUserSearchAdsConnection
    {
        public static IEnumerable<Ad> HandleReadRequests(RegularUserSearchAdsHandler handler, Message received)
        {
            return handler.GetModelsFiltered(received.ValuePairs);
        }
    }
}
