using Client.ViewModels.Connection;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.RegularUserAdsPersonalization
{
    class RegularUserRatingsHelper
    {
        public static IEnumerable<Rating> GetAllModels(IDictionary<string, string> valuePairs, int user)
        {
            IEnumerable<Rating> result;

            try
            {
                result = (IEnumerable<Rating>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserAdsPersonalizationRead",
                    "GetAllRatings");
            }
            catch (Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserAdsPersonalizationRead",
                    "GetAllRatings"));
            }

            return result;
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs, int user)
        {
             var result = ConnectionHelper.SendRequest(valuePairs, user, "RegularUserAdsPersonalizationCommand",
                "RateAdById");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }
    }
}
