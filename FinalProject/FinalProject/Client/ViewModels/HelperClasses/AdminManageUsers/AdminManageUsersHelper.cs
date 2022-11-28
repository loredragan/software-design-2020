using Client.ViewModels.Connection;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.AdminManageUsers
{
    class AdminManageUsersHelper
    {
        public static IEnumerable<User> GetModelById(IDictionary<string, string> valuePairs, int admin)
        {
            IEnumerable<User> result;
            try
            {
                result = (IEnumerable<User>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersRead",
                    "GetModelById");
            }
            catch(Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersRead",
                    "GetModelById"));
            }

            return result;
        }

        public static IEnumerable<User> GetAllModels(IDictionary<string, string> valuePairs, int admin)
        {
            IEnumerable<User> result;
            try
            {
                result = (IEnumerable<User>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersRead",
                    "GetAllModels");
            }
            catch(Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersRead",
                    "GetAllModels"));
            }

            return result;
        }

        public static void UpdateModel(IDictionary<string, string> valuePairs, int admin)
        {
            var result = (string) ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersCommand",
                    "UpdateModel");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs, int admin)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersCommand",
                    "AddNewModel");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }

        public static void DeleteModel(IDictionary<string, string> valuePairs, int admin)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersCommand",
                    "DeleteModel");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }

        public static void UpdateSubscription(IDictionary<string, string> valuePairs, int admin)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersCommand",
                    "UpdateSubscription");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }
    }
}
