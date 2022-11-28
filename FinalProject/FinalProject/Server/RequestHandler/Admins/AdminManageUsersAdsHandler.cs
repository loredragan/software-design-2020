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

namespace Server.RequestHandler.Admins
{
    class AdminManageUsersAdsHandler : AdminHandler
    {
        #region Private Members
        private readonly FinalProjectEntities _context;
        private readonly IRepository<Ad> _adsRepository;
        private readonly IRepository<User> _usersRepository;
        #endregion


        #region Constructors
        public AdminManageUsersAdsHandler()
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
            var result = _adsRepository.GetById(req);
            if (result == null)
                throw new NoResultException("No ad with id = " + req);

            var array = new List<Ad>()
            {
                result
            };

            return array;
        }

        public IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, int userId)
        {
            var result = _adsRepository.GetAll().ToList();
            if (!result.Any())
                throw new NoResultException("There are no ads");

            return result;
        }

        public void UpdateModel(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var toUpdate = _adsRepository.GetById(req);
            if (toUpdate == null)
                throw new NoResultException("No ad with id = " + req);

            var userid = Convert.ToInt32(valuePairs["userId"]);
            if (userid != toUpdate.userId)
                throw new InvalidInputException("You can't change the userID when updating");

            var newSize = Convert.ToDouble(valuePairs["size"]);
            var newPrice = Convert.ToDouble(valuePairs["price"]);
            if (!OnCreateValidateAd.IsEntityValid(newSize, newPrice))
                throw new InvalidInputException("Invalid size or price");

            toUpdate.userId = userid;
            toUpdate.size = newSize;
            toUpdate.price = newPrice;
            toUpdate.location = valuePairs["location"];

            _adsRepository.Update(toUpdate);
        }

        public void AddNewModel(IDictionary<string, string> valuePairs, int userId)
        {
            var newSize = Convert.ToDouble(valuePairs["size"]);
            var newPrice = Convert.ToDouble(valuePairs["price"]);
            if (!OnCreateValidateAd.IsEntityValid(newSize, newPrice))
                throw new InvalidInputException("Invalid size or price");

            var forUser = Convert.ToInt32(valuePairs["userId"]);
            var findUser = _usersRepository.GetAll().Where(ad => ad.id == forUser);
            if (!findUser.Any())
                throw new NoResultException("No User with id = " + forUser);

            var newAd = new Ad()
            {
                userId = forUser,
                location = valuePairs["location"],
                size = newSize,
                price = newPrice,
                createdAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm tt"))
            };

            _adsRepository.Insert(newAd);
        }

        public void DeleteModel(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var result = _adsRepository.GetById(req);
            if (result == null)
                throw new NoResultException("No Ad with id = " + req);

            _adsRepository.Delete(result);
        }
        #endregion
    }
}
