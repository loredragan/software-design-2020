using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Server.Exceptions;
using Server.HelperClasses;
using Server.Repository;
using Server.Repository.Interfaces;

namespace Server.RequestHandler.Admins
{
    public class AdminManageUsersAdsHandler : AdminsHandler
    {
        private readonly IRepository<Ad> _repository;

        public AdminManageUsersAdsHandler() : base()
        {
            this._repository = new Repository<Ad>(new Assignment3Entities());
        }

        public IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var result = _repository.GetById(req);
            if (result == null)
                throw new NoResultException("No ad with id = " + req);

            var array = new List<Ad>()
            {
                result
            };

            return array;
        }

        public IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs)
        {
            var result = _repository.GetAll().ToList();
            if (!result.Any())
                throw new NoResultException("There are no ads");

            return result;
        }

        public void UpdateModel(IDictionary<string, string> valuePairs)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var toUpdate = _repository.GetById(req);
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

            _repository.Update(toUpdate);
        }

        public void AddNewModel(IDictionary<string, string> valuePairs)
        {
            var newSize = Convert.ToDouble(valuePairs["size"]);
            var newPrice = Convert.ToDouble(valuePairs["price"]);
            if (!OnCreateValidateAd.IsEntityValid(newSize, newPrice))
                throw new InvalidInputException("Invalid size or price");

            var forUser = Convert.ToInt32(valuePairs["userID"]);
            var findUser = new Repository<User>(new Assignment3Entities()).GetAll().Where(ad => ad.id == forUser);
            if (!findUser.Any())
                throw new NoResultException("No User with id = " + forUser);

            var newAd = new Ad()
            {
                userID = forUser,
                location = valuePairs["location"],
                size = newSize,
                price = newPrice
            };

            _repository.Insert(newAd);
        }

        public void DeleteModel(IDictionary<string, string> valuePairs)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var result = _repository.GetById(req);
            if (result == null)
                throw new NoResultException("No Ad with id = " + req);

            _repository.Delete(result);
        }
    }
}
