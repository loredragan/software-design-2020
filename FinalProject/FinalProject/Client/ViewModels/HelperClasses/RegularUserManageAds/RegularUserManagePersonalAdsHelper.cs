using Client.ViewModels.Connection;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.RegularUserManageAds
{
    class RegularUserManagePersonalAdsHelper
    {
        public static IEnumerable<Ad> GetModelByIdHelper(IDictionary<string, string> valuePairs, int user)
        {
            return (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsRead",
                "GetModelById");
        }

        public static IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, int user)
        {
            IEnumerable<Ad> result;

            try
            {
                result =  (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsRead",
                    "GetAllModels");
            }catch(Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsRead",
                    "GetAllModels"));
            }

            return result;
        }

        public static void UpdateModel(IDictionary<string, string> valuePairs, int user)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsCommand",
                "UpdateModel");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs, int user)
        {

            var result = (string)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsCommand",
                "AddNewModel");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }

        public static void DeleteModel(IDictionary<string, string> valuePairs, int user)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsCommand",
                "DeleteModel");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }
    }
}
