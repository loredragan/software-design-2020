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
    class RegularUserManageAdsConnection
    {
        public static IEnumerable<BaseModel> HandleReadRequests(RegularUserManageAdsHandler helper, Message received)
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

        public static void HandleCommandRequests(RegularUserManageAdsHandler helper, Message received)
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
