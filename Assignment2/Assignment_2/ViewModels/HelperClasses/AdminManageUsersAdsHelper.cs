using Assignment_2.Models;
using Assignment_2.Models.Repository;
using Assignment_2.Models.Repository.Interfaces;
using Assignment_2.ViewModels.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.HelperClasses
{
    public  static class AdminManageUsersAdsHelper
    {
        public static IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, IRepository<Ad> repository, int admin)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var result = repository.GetById(req);
            if (result == null)
                throw new NoResultException("No ad with id = " + req);

            var array = new List<Ad>()
            {
                result
            };

            return array;
        }

        public static IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, IRepository<Ad> repository, int admin)
        {
            var result = repository.GetAll().ToList();
            if (!result.Any())
                throw new NoResultException("There are no ads");

            return result;
        }

        public static void UpdateModel(IDictionary<string, string> valuePairs, IRepository<Ad> repository, int admin)
        {
            var req = Convert.ToInt32(valuePairs["id"]); 
            var toUpdate = repository.GetById(req);
            if (toUpdate == null)
                throw new NoResultException("No ad with id = " + req);

            var userid = Convert.ToInt32(valuePairs["userID"]);
            if (userid != toUpdate.userID)
                throw new InvalidInputException("You can't change the userID when updating");

            var newSize = Convert.ToDouble(valuePairs["size"]);
            var newPrice = Convert.ToDouble(valuePairs["price"]);
            if (!OnCreateValidateAd.IsEntityValid(newSize, newPrice))
                throw new InvalidInputException("Invalid size or price");

            toUpdate.userID = userid;
            toUpdate.size = newSize;
            toUpdate.price = newPrice;
            toUpdate.location = valuePairs["location"];

            repository.Update(toUpdate);
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs, IRepository<Ad> repository, int admin)
        {
            var newSize = Convert.ToDouble(valuePairs["size"]);
            var newPrice = Convert.ToDouble(valuePairs["price"]);
            if (!OnCreateValidateAd.IsEntityValid(newSize, newPrice))
                throw new InvalidInputException("Invalid size or price");

            var forUser = Convert.ToInt32(valuePairs["userID"]);
            var findUser = new Repository<User>(new Assignment2Entities()).GetAll().Where(ad => ad.id == forUser);
            if (!findUser.Any())
                throw new NoResultException("No User with id = " + forUser);

            var newAd = new Ad()
            {
                userID = forUser,
                location = valuePairs["location"],
                size = newSize,
                price = newPrice
            };

            repository.Insert(newAd);
        }

        public static void DeleteModel(IDictionary<string, string> valuePairs, IRepository<Ad> repository, int admin)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var result = repository.GetById(req);
            if (result == null)
                throw new NoResultException("No Ad with id = " + req);

            repository.Delete(result);
        }
    }
}
