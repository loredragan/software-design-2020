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
    class RegularUserAdsPersonalizationHandler : RegularUserHandler
    {
        #region Private Members
        private readonly FinalProjectEntities _context;
        private readonly IRepository<Favorite> _favoritesRepository;
        private readonly IRepository<Rating> _ratingsRepository;
        private readonly IRepository<User> _usersRepository;
        #endregion


        #region Constructors
        public RegularUserAdsPersonalizationHandler()
        {
            this._context = new FinalProjectEntities();
            this._favoritesRepository = new Repository<Favorite>(_context);
            this._ratingsRepository = new Repository<Rating>(_context);
            this._usersRepository = new Repository<User>(_context);
        }
        #endregion

        #region Exposed Methods
        public IEnumerable<Favorite> GetAllFavorites(IDictionary<string, string> valuePairs, int userId)
        {
            var usersFavorites = _favoritesRepository.GetAll().Where(s => s.userId == userId).ToList();

            return usersFavorites;
        }

        public IEnumerable<Rating> GetAllRatings(IDictionary<string, string> valuePairs, int userId)
        {
            var usersRatings = _ratingsRepository.GetAll().Where(s => s.userId == userId).ToList();

            return usersRatings;
        }

        public IEnumerable<Rating> SearchByRating(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["rating"]);
            var ratings = _ratingsRepository.GetAll().Where(s => s.value == req).ToList();

            return ratings;
        }

        public void AddToFavorites(IDictionary<string, string> valuePairs, int userId)
        {
            var adId = Convert.ToInt32(valuePairs["adId"]);


            var adsRepo = new Repository<Ad>(new FinalProjectEntities());
            var existsAds = adsRepo.GetAll().Where(s => s.id == adId).ToList();
            if (!existsAds.Any())
            {
                throw new NoResultException("No ad with this id exists");
            }

            var ownerId = existsAds.First().userId;

            var newFavourite = new Favorite()
            {
                adId = adId,
                userId = userId,
                ownerId = ownerId
            };

            var usersFavourites = _favoritesRepository.GetAll().Where(s => s.userId == userId).ToList();
            var exists = usersFavourites.Where(s => s.adId == adId);
            if (exists.Any())
                throw new InvalidInputException("This add is already in favourites");

            _favoritesRepository.Insert(newFavourite);
        }

        public void RemoveFavoriteById(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["favId"]);
            var favoritesOfUser = _favoritesRepository.GetAll().Where(s => s.userId == userId).ToList();

            var searchToRemove = favoritesOfUser.Where(s => s.id == req);
            if (!searchToRemove.Any())
                throw new NoResultException("You have no ad with id = " + req + " in favorites list");

            _favoritesRepository.Delete(searchToRemove.First());
        }

        public void RateAdById(IDictionary<string, string> valuePairs, int userId)
        {
            var adToRate = Convert.ToInt32(valuePairs["adId"]);
            var valueToRate = Convert.ToInt32(valuePairs["rating"]);

            if (!OnCreateValidateRating.CheckIfRatingIsValid(valueToRate))
                throw new InvalidInputException("Rating should be between 1 and 5");

            var ratings = _ratingsRepository.GetAll().Where(s => s.userId == userId);

            var existsRatingForAd = ratings.Where(s => s.adId == adToRate);
            if (existsRatingForAd.Any())
                throw new NoResultException("You can't rate an ad more than once");
            var username = _usersRepository.GetAll().Where(s => s.id == userId).FirstOrDefault().username;

            var newRating = new Rating()
            {
                userId = userId,
                adId = adToRate,
                value = valueToRate,
                username = username
            };

            _ratingsRepository.Insert(newRating);
        }
        #endregion
    }
}
