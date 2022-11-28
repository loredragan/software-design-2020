using Client.ViewModels.Connection;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.RegularUserAdsPersonalization
{
    class RegularUserFavoritesHelper
    {
        public static IEnumerable<Favorite> GetAllModels(IDictionary<string, string> valuePairs, int user)
        {
            IEnumerable<Favorite> result;
            try
            {
                result = (IEnumerable<Favorite>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserAdsPersonalizationRead",
                    "GetAllFavorites");
            }
            catch (Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserAdsPersonalizationRead",
                    "GetAllFavorites"));
            }

            return result;    
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs, int user)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserAdsPersonalizationCommand",
               "AddToFavorites");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }

        public static void DeleteModel(IDictionary<string, string> valuePairs, int user)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserAdsPersonalizationCommand",
               "RemoveFavoriteById");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }
    }
}
