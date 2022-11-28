using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.HelperClasses.Admins
{
    class AdminManageUsersRatings
    {
        public static IEnumerable<User> HandleReadRequests(AdminManageUsersRatingsHandler handler, Message received)
        {
            if (received.Content.Equals("GetModelById", StringComparison.InvariantCultureIgnoreCase))
            {
                return handler.GetModelById(received.ValuePairs);
            }
            else if (received.Content.Equals("GetAllModels", StringComparison.InvariantCultureIgnoreCase))
            {
                return handler.GetAllModels(received.ValuePairs);
            }

            return null;
        }
    }
}
