using Assignment_2.Models;
using Assignment_2.Models.Repository;
using Assignment_2.Models.Repository.Interfaces;
using Assignment_2.ViewModels.Exceptions;
using Assignment_2.Views.Pages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.HelperClasses
{
    public static class AdminGenerateReportsHelper
    {
        public static IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, IRepository<Ad> repository, int admin)
        {
            var repoUsers = new Repository<User>(new Assignment2Entities());
            var req = Convert.ToInt32(valuePairs["userID"]);
            var result = repoUsers.GetAll().Where(s => s.id == req);
            if (!result.Any())
                throw new NoResultException("No user with id = " + req);

            var res = repository.GetAll().Where(s => s.userID == req);
            if (!res.Any())
                throw new NoResultException("This user has no ads");

            return res;
        }

        public static void GenerateReport(IDictionary<string, string> valuePairs, IRepository<Ad> repository, int admin, FileTypes file, FileCreator fileCreator)
        {
            var result = GetModelById(valuePairs, repository, admin);
            var factory = fileCreator.ExecuteCreation(file, result);
            factory.GenerateReport();
        }
    }
}
