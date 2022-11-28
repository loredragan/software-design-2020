using Client.ViewModels.Connection;
using Client.ViewModels.Exceptions;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.AdminGenerateReports
{
    class AdminGenerateReportsHelper
    {
        public static IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, int admin)
        {
            var repoUsers = (IEnumerable<User>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersRead",
                "GetAllModels");
            var req = Convert.ToInt32(valuePairs["userId"]);
            var result = repoUsers.Where(s => s.id == req);
            if (!result.Any())
                throw new NoResultException("No user with id = " + req);
            IEnumerable<Ad> res;
            try
            {
                res = (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsRead",
               "GetAllModels");
            }
            catch (Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersAdsRead",
               "GetAllModels"));
            }
            var ress = res.Where(s => s.userId == req);

            if (!res.Any())
                throw new NoResultException("This user has no ads");

            return res;
        }

        public static void GenerateReport(IDictionary<string, string> valuePairs, int admin, FileTypes file, FileCreator fileCreator)
        {
            var result = GetModelById(valuePairs, admin);
            var factory = fileCreator.ExecuteCreation(file, result);
            factory.GenerateReport();
        }
    }
}
