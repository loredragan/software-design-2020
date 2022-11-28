using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.Connection;
using Client.ViewModels.Exceptions;

namespace Client.ViewModels.HelperClasses
{
    public class AdminManageUsersAdsHelper
    {
        #region Test

        public virtual IEnumerable<Ad> GetModelByIdTest(IDictionary<string, string> valuePairs, int admin)
        {
            return
                (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsRead",
                    "GetModelById");
        }

        public virtual IEnumerable<Ad> GetAllModelsTest(IDictionary<string, string> valuePairs, int admin)
        {
            return
                (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsRead",
                    "GetAllModels");
        }
        #endregion

        public static IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, int admin)
        {
            return 
                (IEnumerable<Ad>) ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsRead",
                    "GetModelById");
        }

        public static IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs,  int admin)
        {
            return 
                (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsRead",
                    "GetAllModels");
        }

        public static void UpdateModel(IDictionary<string, string> valuePairs,  int admin)
        {
                ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsCommand",
                    "UpdateModel");
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs, int admin)
        {
                ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsCommand",
                    "AddNewModel");
        }

        public static void DeleteModel(IDictionary<string, string> valuePairs, int admin)
        {
                ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsCommand",
                    "DeleteModel");
        }

    }
}
