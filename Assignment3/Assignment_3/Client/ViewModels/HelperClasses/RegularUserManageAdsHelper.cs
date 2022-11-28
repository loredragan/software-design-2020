using Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels.Connection;

namespace Client.ViewModels.HelperClasses
{
    public class RegularUserManageAdsHelper
    {
        #region forTest
        //test
        public virtual IEnumerable<Ad> GetAllModelsTest(IDictionary<string, string> valuePairs, int user)
        {
            return
                (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsRead",
                    "GetAllModels");
        }

        public virtual IEnumerable<Ad> GetModelByIdHelperTest(IDictionary<string, string> valuePairs, int user)
        {
            return (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsRead",
                "GetModelById");
        }

        public virtual IEnumerable<Favorite> GetFavouriteModelsTest(IDictionary<string, string> valuePairs, int user)
        {
            return
                (IEnumerable<Favorite>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsRead",
                    "GetAllFavourites");
        }

        #endregion
        public static IEnumerable<Ad> GetModelByIdHelper(IDictionary<string, string> valuePairs, int user)
        {
                return (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsRead",
                    "GetModelById");
        }

        public static IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs,  int user)
        {
            return 
                (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsRead",
                    "GetAllModels");
        }

        public static IEnumerable<Favorite> GetFavouriteModels(IDictionary<string, string> valuePairs, int user)
        {
            return 
                (IEnumerable<Favorite>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsRead",
                    "GetAllFavourites");
        }

        public static void UpdateModel(IDictionary<string, string> valuePairs, int user)
        {
                ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsCommand",
                    "UpdateModel");
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs, int user)
        {
                ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsCommand",
                    "AddNewModel");
        }

        public static void DeleteModel(IDictionary<string, string> valuePairs, int user)
        {
                ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsCommand",
                    "DeleteModel");
        }

        public static void AddToFavourites(IDictionary<string, string> valuePairs, int user)
        {
                ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsCommand",
                    "AddToFavourites");
        }

        public static void SendMessage(IDictionary<string, string> valuePairs, int user)
        {
            ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsCommand", "SendMessage");
        }

        public static IEnumerable<ChatMessage> GetInbox(IDictionary<string, string> valuePairs, int user)
        {
            return (IEnumerable<ChatMessage>) ConnectionHelper.SendRequest(valuePairs, user, "RegularUserManageAdsRead",
                "GetInbox");
        }
    }
}
