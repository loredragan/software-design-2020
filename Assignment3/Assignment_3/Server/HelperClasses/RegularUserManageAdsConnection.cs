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
    static class RegularUserManageAdsConnection
    {
        public static IEnumerable<BaseModel> HandleReadRequests(RegularUserManageAdsHandler helper, Message received)
        {
            if(received.Content.Equals("GetModelById", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetModelById(received.ValuePairs, received.UserId);
            }
            else if (received.Content.Equals("GetAllModels", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetAllModels(received.ValuePairs, received.UserId);
            }
            else if (received.Content.Equals("GetAllFavourites", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetAllFavourites(received.ValuePairs, received.UserId);
            }
            else if (received.Content.Equals("GetInbox", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetInbox(received.ValuePairs, received.UserId);
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
            else if (received.Content.Equals("AddToFavourites", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.AddToFavourites(received.ValuePairs, received.UserId);
            }
            else if (received.Content.Equals("SendMessage", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.SendMessage(received.ValuePairs, received.UserId);
            }
        }
    }
}
