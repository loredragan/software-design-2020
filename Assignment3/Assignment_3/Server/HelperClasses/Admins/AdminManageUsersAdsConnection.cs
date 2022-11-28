using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3;
using Assignment_3.Models;
using Server.RequestHandler.Admins;

namespace Server.HelperClasses
{
    static class AdminManageUsersAdsConnection
    {
        public static IEnumerable<Ad> HandleReadRequests(AdminManageUsersAdsHandler helper, Message received)
        {
            if(received.Content.Equals("GetModelById", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetModelById(received.ValuePairs);
            }
            else if (received.Content.Equals("GetAllModels", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetAllModels(received.ValuePairs);
            }

            return null;
        }

        public static void HandleCommandRequests(AdminManageUsersAdsHandler helper, Message received)
        {
            if (received.Content.Equals("UpdateModel", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.UpdateModel(received.ValuePairs);
            }
            else if (received.Content.Equals("AddNewModel", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.AddNewModel(received.ValuePairs);
            }
            else if (received.Content.Equals("DeleteModel", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.DeleteModel(received.ValuePairs);
            }
        }
    }
}
