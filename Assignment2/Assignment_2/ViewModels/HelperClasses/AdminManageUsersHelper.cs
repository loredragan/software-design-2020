using Assignment_2.Models;
using Assignment_2.Models.Repository.Interfaces;
using Assignment_2.ViewModels.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2.Models.Repository;

namespace Assignment_2.ViewModels.HelperClasses
{
    public static class AdminManageUsersHelper
    {
        public static IEnumerable<User> GetModelById(IDictionary<string, string> valuePairs, IRepository<User> repository, int admin)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var result = repository.GetById(req);
            if (result == null)
                throw new NoResultException("No user with id = " + req);

            var array = new List<User>
            {
                result
            };

            return array;
        }

        public static IEnumerable<User> GetAllModels(IDictionary<string, string> valuePairs, IRepository<User> repository, int admin)
        {
            var result = repository.GetAll().ToList();
            if (!result.Any())
                throw new NoResultException("There are no users");

            return result;
        }

        public static void UpdateModel(IDictionary<string, string> valuePairs, IRepository<User> repository, int admin)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var toUpdate = repository.GetById(req);
            if (toUpdate == null)
                throw new NoResultException("No User with id = " + req);

            toUpdate.name = valuePairs["name"];
            toUpdate.username = valuePairs["username"];
            toUpdate.password= valuePairs["password"];

            repository.Update(toUpdate);
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs, IRepository<User> repository, int admin)
        {
            var newUsername = valuePairs["username"];
            var getUsers = repository.GetAll().Where(user => user.username.Equals(newUsername, StringComparison.InvariantCultureIgnoreCase));
            if (getUsers.Any())
                throw new InvalidInputException("Username already exists");


            var newUser = new User()
            {
                password = valuePairs["password"],
                username = valuePairs["username"],
                name = valuePairs["name"]
            };

            repository.Insert(newUser);
        }

        public static void DeleteModel(IDictionary<string, string> valuePairs, IRepository<User> repository, int admin)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var toDelete = repository.GetById(req);
            if (toDelete == null)
                throw new NoResultException("No User with id = " + req);
            var adsRepo = new Repository<Ad>(new Assignment2Entities());
            var ads = adsRepo.GetAll().Where(s => s.userID == req);
            repository.Delete(toDelete);
        }
    }
}
