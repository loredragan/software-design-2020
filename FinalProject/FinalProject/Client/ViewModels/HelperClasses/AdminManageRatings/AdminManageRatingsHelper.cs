using Client.ViewModels.Connection;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.AdminManageRatings
{
    class AdminManageRatingsHelper
    {
        public static IEnumerable<Rating> GetModelById(IDictionary<string, string> valuePairs, int admin)
        {
            IEnumerable<Rating> result;
            try
            {
                result = (IEnumerable<Rating>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageRatingsRead",
                    "GetModelById");
            }
            catch (Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageRatingsRead",
                    "GetModelById"));
            }

            return result;
        }

        public static IEnumerable<Rating> GetAllModels(IDictionary<string, string> valuePairs, int admin)
        {
            IEnumerable<Rating> result;
            try
            {
                result = (IEnumerable<Rating>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageRatingsRead",
                    "GetAllModels");
            }
            catch (Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageRatingsRead",
                    "GetAllModels"));
            }

            return result;

        }

        public static void UpdateModel(IDictionary<string, string> valuePairs, int admin)
        {
            var result = (string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageRatingsCommand",
                    "UpdateModel");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }
    }
}
