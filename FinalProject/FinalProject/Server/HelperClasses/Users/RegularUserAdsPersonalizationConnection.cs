using FinalProject;
using FinalProject.Models;
using Server.RequestHandler.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.HelperClasses.Users
{
    class RegularUserAdsPersonalizationConnection
    {
        public static IEnumerable<BaseModel> HandleReadRequests(RegularUserAdsPersonalizationHandler helper, Message received)
        {
            if (received.Content.Equals("GetAllFavorites", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetAllFavorites(received.ValuePairs, received.UserId);
            }

            else if(received.Content.Equals("GetAllRatings", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetAllRatings(received.ValuePairs, received.UserId);
            }

            else if(received.Content.Equals("SearchByRating", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.SearchByRating(received.ValuePairs, received.UserId);
            }

            return null;
        }

        public static void HandleCommandRequests(RegularUserAdsPersonalizationHandler helper, Message received)
        {
            if (received.Content.Equals("AddToFavorites", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.AddToFavorites(received.ValuePairs, received.UserId);
            }

            else if (received.Content.Equals("RemoveFavoriteById", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.RemoveFavoriteById(received.ValuePairs, received.UserId);
            }

            else if (received.Content.Equals("RateAdById", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.RateAdById(received.ValuePairs, received.UserId);
            }
        }
    }
}
