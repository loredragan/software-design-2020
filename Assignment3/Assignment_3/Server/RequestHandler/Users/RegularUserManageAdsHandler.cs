using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Server.Exceptions;
using Server.HelperClasses;
using Server.Repository;
using Server.Repository.Interfaces;

namespace Server.RequestHandler.Users
{
    public class RegularUserManageAdsHandler : UsersHelper
    {
        public IRepository<Ad> _repository;
        public IRepository<Favorite> favorites;

        public RegularUserManageAdsHandler()
        {
            this._repository = new Repository<Ad>(new Assignment3Entities());
            this.favorites = new Repository<Favorite>(new Assignment3Entities());
        }

        public IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, int user)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var userAds = _repository.GetAll().Where(ad => ad.userID == user)
                .Where(ad => ad.id == req).ToList();
            if (!userAds.Any())
                throw new NoResultException("No Ad with id = " + valuePairs["id"]);

            return userAds;
        }

        public IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, int user)
        {
            var userAds = _repository.GetAll().Where(ad => ad.userID == user).ToList();
            if (!userAds.Any())
                throw new NoResultException("You have no ads");

            return userAds;
        }

        public void UpdateModel(IDictionary<string, string> valuePairs, int user)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var userAds = _repository.GetAll().Where(ad => ad.userID == user).ToList();
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

            _repository.Update(toUpdate.First());
        }

        public void AddNewModel(IDictionary<string, string> valuePairs, int user)
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

            _repository.Insert(newModel);
        }

        public void DeleteModel(IDictionary<string, string> valuePairs, int user)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var userAds = _repository.GetAll().Where(ad => ad.userID == user).ToList();
            if (!userAds.Any())
                throw new NoResultException("You have no ads");

            var toDelete = userAds.Where(ad => ad.id == req).ToList();
            if (!toDelete.Any())
                throw new NoResultException("You have no ad with id = " + req);

            _repository.Delete(toDelete.First());
        }

        public void AddToFavourites(IDictionary<string, string> valuePairs, int user)
        {
            var adId = Convert.ToInt32(valuePairs["adID"]);
           

            var adsRepo = new Repository<Ad>(new Assignment3Entities());
            var existsAds = adsRepo.GetAll().Where(s => s.id == adId).ToList();
            if (!existsAds.Any())
            {
                throw new NoResultException("No ad with this id exists");
            }

            var ownerId = existsAds.First().userID;

            var newFavourite = new Favorite()
            {
                adID = adId,
                userID = user,
                ownerID = ownerId
            };

            var favourites = new Repository<Favorite>(new Assignment3Entities());
            var usersFavourites = favourites.GetAll().Where(s => s.userID == user).ToList();
            var exists = usersFavourites.Where(s => s.adID == adId);
            if (exists.Any())
                throw new InvalidInputException("This add is already in favourites");

            favourites.Insert(newFavourite);
        }

        public IEnumerable<Favorite> GetAllFavourites(IDictionary<string, string> valuePairs, int user)
        {
            var usersFavorites = favorites.GetAll().Where(s => s.userID == user).ToList();

            return usersFavorites;
        }

        public IEnumerable<ChatMessage> GetInbox(IDictionary<string, string> valuePairs, int user)
        {
            var messages = new Repository<ChatMessage>(new Assignment3Entities());
            var userMessages = messages.GetAll().Where(s => s.userID == user).ToList();

            return userMessages;
        }

        public void SendMessage(IDictionary<string, string> valuePairs, int user)
        {
            var userID = Convert.ToInt32(valuePairs["userID"]);
            var users = new Repository<User>(new Assignment3Entities());
            var exists = users.GetAll().Where(s => s.id == userID).ToList();

            if (!exists.Any())
            {
                throw new NoResultException("No user with this ID exists");
            }

            var sender = users.GetAll().Where(s => s.id == user).ToList();
            var senderName = sender.First().name;

            var newMessage = new ChatMessage()
            {
                fromUserID = user, //pun la fromuser idul celui care trimit pentru ca atunci cand voi afisa la cineva, fromUser
                                    //va afisa id-ul celui care a trimis mesajul
                userID = userID , //cui trimit
                content = valuePairs["messageContent"],
                fromUserName = senderName //
            };

            var messages = new Repository<ChatMessage>(new Assignment3Entities());
            messages.Insert(newMessage);
        }
    }
}
