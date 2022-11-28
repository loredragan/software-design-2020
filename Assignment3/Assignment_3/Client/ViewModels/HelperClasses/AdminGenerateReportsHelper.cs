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
    //fac separat
    public static class AdminGenerateReportsHelper
    {
        public static IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, int admin)
        {
            var repoUsers = (IEnumerable<User>) ConnectionHelper.SendRequest(valuePairs, admin, "AdminManageUsersRead",
                "GetAllModels");
            var req = Convert.ToInt32(valuePairs["userID"]);
            var result = repoUsers.Where(s => s.id == req);
            if (!result.Any())
                throw new NoResultException("No user with id = " + req);

            var res = (IEnumerable<Ad>)ConnectionHelper.SendRequest(valuePairs, admin, "RegularUserManageAdsRead",
                "GetAllModels");
            var ress = res.Where(s => s.userID == req);

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
