using Assignment_2.Models;
using Assignment_2.Models.Repository.Interfaces;
using Assignment_2.ViewModels.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.HelperClasses
{
    public static class RegularUserManageAdsHelper
    {
        public static IEnumerable<Ad> GetModelByIdHelper(IDictionary<string,string> valuePairs,IRepository<Ad> repository, int user)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var userAds = repository.GetAll().Where(ad => ad.userID == user)
                    .Where(ad => ad.id == req).ToList();
            if (!userAds.Any())
                throw new NoResultException("No Ad with id = " + valuePairs["id"]);

            return userAds;
        }

        public static IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs,IRepository<Ad> repository, int user)
        {
            var userAds = repository.GetAll().Where(ad => ad.userID == user).ToList();
            if (!userAds.Any())
                throw new NoResultException("You have no ads");

            return userAds;
        }

        public static void UpdateModel(IDictionary<string, string> valuePairs, IRepository<Ad> repository, int user)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var userAds = repository.GetAll().Where(ad => ad.userID == user).ToList();
            if (!userAds.Any())
                throw new NoResultException("You have no ads");

            var toUpdate = userAds.Where(ad => ad.id == req);
            if (!toUpdate.Any())
                throw new NoResultException("You have no ad with id = " + req);

            var newSize = Convert.ToDouble(valuePairs["size"]);
            var newPrice = Convert.ToDouble(valuePairs["price"]);
            if (!OnCreateValidateAd.IsEntityValid(newSize, newPrice))
                throw new InvalidInputException("Invalid size or price");

            toUpdate.First().location = valuePairs["location"];
            toUpdate.First().size = Convert.ToDouble(valuePairs["size"]);
            toUpdate.First().price = Convert.ToDouble(valuePairs["price"]);

            repository.Update(toUpdate.First());
        }

        public static void AddNewModel(IDictionary<string, string> valuePairs, IRepository<Ad> repository, int user)
        {
            var newSize = Convert.ToDouble(valuePairs["size"]);
            var newPrice = Convert.ToDouble(valuePairs["price"]);
            if (!OnCreateValidateAd.IsEntityValid(newSize, newPrice))
                throw new InvalidInputException("Invalid size or price");

            var newModel = new Ad()
            {
                userID = user,
                location = valuePairs["location"],
                size = Convert.ToDouble(valuePairs["size"]),
                price = Convert.ToDouble(valuePairs["price"])
            };

            repository.Insert(newModel);
        }

        public static void DeleteModel(IDictionary<string, string> valuePairs, IRepository<Ad> repository, int user)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var userAds = repository.GetAll().Where(ad => ad.userID == user).ToList();
            if (!userAds.Any())
                throw new NoResultException("You have no ads");

            var toDelete = userAds.Where(ad => ad.id == req).ToList();
            if (!toDelete.Any())
                throw new NoResultException("You have no ad with id = " + req);

            repository.Delete(toDelete.First());
        }
    }
}
