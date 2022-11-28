using FinalProject.Models;
using Server.Exceptions;
using Server.HelperClasses;
using Server.Repository;
using Server.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestHandler.Users
{
    class RegularUserManageAdsHandler : RegularUserHandler
    {
        #region Private Members
        private readonly FinalProjectEntities _context;
        private readonly IRepository<Ad> _adsRepository;
        private readonly IRepository<User> _usersRepository;
        #endregion

        #region Constructors
        public RegularUserManageAdsHandler()
        {
            this._context = new FinalProjectEntities();
            this._adsRepository = new Repository<Ad>(_context);
            this._usersRepository = new Repository<User>(_context);
        }
        #endregion

        #region Exposed Methods
        public IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var userAds = _adsRepository.GetAll().Where(ad => ad.userId == userId)
                .Where(ad => ad.id == req).ToList();
            if (!userAds.Any())
                throw new NoResultException("No Ad with id = " + valuePairs["id"]);

            return userAds;
        }

        public IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, int userId)
        {
            var userAds = _adsRepository.GetAll().Where(ad => ad.userId == userId).ToList();
            if (!userAds.Any())
                throw new NoResultException("You have no ads");

            return userAds;
        } 

        public void UpdateModel(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var userAds = _adsRepository.GetAll().Where(ad => ad.userId == userId).ToList();
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

            _adsRepository.Update(toUpdate.First());
        }

        //validate for subscription type
        public void AddNewModel(IDictionary<string, string> valuePairs, int userId)
        {
            //reset counter if new day, but only if the list with ads is not empty
            var usersAds = _adsRepository.GetAll().Where(s => s.userId == userId);
            var currentUser = _usersRepository.GetById(userId);
            if (usersAds.Any())
            {
                var lastAdCreated = usersAds.ToList().OrderBy(s => s.createdAt).Last();
                if (usersAds.Any())
                {
                    if (DateTime.Now.Day > lastAdCreated.createdAt.Day)
                    {
                        currentUser.adsCounter = 0;
                    }
                }
            }

            var newSize = Convert.ToDouble(valuePairs["size"]);
            var newPrice = Convert.ToDouble(valuePairs["price"]);
            if (!OnCreateValidateAd.IsEntityValid(newSize, newPrice))
                throw new InvalidInputException("Invalid size or price");

            //var forUser = Convert.ToInt32(valuePairs["userId"]);
            //var findUser = _usersRepository.GetAll().Where(ad => ad.id == forUser);
            //if (!findUser.Any())
            //    throw new NoResultException("No User with id = " + forUser);

            var newAd = new Ad()
            {
                userId = userId,
                location = valuePairs["location"],
                size = newSize,
                price = newPrice,
                createdAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm tt"))
            };

            if (currentUser.subscription == 1)
            {
                if (currentUser.adsCounter == 2)
                    throw new NoResultException("You've reached the limit of ads to post today!");
            }
            else
            {
                if (currentUser.adsCounter == 5)
                    throw new NoResultException("You've reached the limit of ads to post today!");
            }
            currentUser.adsCounter += 1;
            _adsRepository.Insert(newAd);
        }

        public void DeleteModel(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var userAds = _adsRepository.GetAll().Where(ad => ad.userId == userId).ToList();
            if (!userAds.Any())
                throw new NoResultException("You have no ads");

            var toDelete = userAds.Where(ad => ad.id == req).ToList();
            if (!toDelete.Any())
                throw new NoResultException("You have no ad with id = " + req);

            _adsRepository.Delete(toDelete.First());
        }
        #endregion
    }
}
