using Client.ViewModels.Connection;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.AdminManageUsersAds
{
    class AdminManageUsersAdsHelper
    {
        public static IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, int admin)
        {
            IEnumerable<Ad> result;
            try
            {
                result = (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsRead",
                    "GetModelById");
            }
            catch (Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsRead",
                    "GetModelById"));
            }

            return result;
        }

        public static IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, int admin)
        {
            IEnumerable<Ad> result;

            try
            {
                result = (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsRead",
                    "GetAllModels");
            }
            catch (Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsRead",
                    "GetAllModels"));
            }

            return result;    
        }

        public static void UpdateModel(IDictionary<string, string> valuePairs, int admin)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsCommand",
                "UpdateModel");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs, int admin)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsCommand",
                "AddNewModel");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }

        public static void DeleteModel(IDictionary<string, string> valuePairs, int admin)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsCommand",
                "DeleteModel");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }
    }
}
