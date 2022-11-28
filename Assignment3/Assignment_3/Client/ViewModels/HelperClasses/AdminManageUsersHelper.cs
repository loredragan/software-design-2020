using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.Connection;

namespace Client.ViewModels.HelperClasses
{
     public class AdminManageUsersHelper
    {
        #region Test
        public virtual IEnumerable<User> GetModelByIdTest(IDictionary<string, string> valuePairs, int admin)
        {
            return
                (IEnumerable<User>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersRead",
                    "GetModelById");
        }

        public virtual IEnumerable<User> GetAllModelsTest(IDictionary<string, string> valuePairs, int admin)
        {
            return
                (IEnumerable<User>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersRead",
                    "GetAllModels");
        }
        #endregion
        public static  IEnumerable<User> GetModelById(IDictionary<string, string> valuePairs, int admin)
        {
            return 
                (IEnumerable<User>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersRead",
                    "GetModelById");
        }

        public static IEnumerable<User> GetAllModels(IDictionary<string, string> valuePairs, int admin)
        {
            return 
                (IEnumerable<User>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersRead",
                    "GetAllModels");
        }

        public static void UpdateModel(IDictionary<string, string> valuePairs, int admin)
        {
            ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersCommand",
                    "UpdateModel");
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs,  int admin)
        {
            ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersCommand",
                    "AddNewModel");
        }

        public static void DeleteModel(IDictionary<string, string> valuePairs,int admin)
        {
            ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersCommand",
                    "DeleteModel");
        }
    }
}
