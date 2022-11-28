using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject;
using FinalProject.Models;
using Server.RequestHandler.Admins;

namespace Server.HelperClasses
{
    class AdminManageUsersAdsConnection
    {
        public static IEnumerable<BaseModel> HandleReadRequests(AdminManageUsersAdsHandler helper, Message received)
        {
            if (received.Content.Equals("GetModelById", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetModelById(received.ValuePairs, received.UserId);
            }
            else if (received.Content.Equals("GetAllModels", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetAllModels(received.ValuePairs, received.UserId);
            }

            return null;
        }

        public static void HandleCommandRequests(AdminManageUsersAdsHandler helper, Message received)
        {
            if (received.Content.Equals("UpdateModel", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.UpdateModel(received.ValuePairs, received.UserId);
            }
            else if (received.Content.Equals("AddNewModel", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.AddNewModel(received.ValuePairs, received.UserId);
            }
            else if (received.Content.Equals("DeleteModel", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.DeleteModel(received.ValuePairs, received.UserId);
            }
        }
    }
}
