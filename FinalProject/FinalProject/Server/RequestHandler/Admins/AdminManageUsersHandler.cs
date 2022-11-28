using FinalProject;
using FinalProject.Models;
using Server.Exceptions;
using Server.Repository;
using Server.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestHandler.Admins
{
    class AdminManageUsersHandler : AdminHandler
    {
        #region Private Members
        private readonly FinalProjectEntities _context;
        private readonly IRepository<User> _usersRepository;
        #endregion

        #region Constructors
        public AdminManageUsersHandler()
        {
            this._context = new FinalProjectEntities();
            this._usersRepository = new Repository<User>(_context);
        }
        #endregion

        #region Exposed Methods
        public IEnumerable<User> GetModelById(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var result = _usersRepository.GetById(req);
            if (result == null)
                throw new NoResultException("No user with id = " + req);

            var array = new List<User>
            {
                result
            };

            return array;
        }

        public IEnumerable<User> GetAllModels(IDictionary<string, string> valuePairs, int userID)
        {
            var result = _usersRepository.GetAll().ToList();
            if (!result.Any())
                throw new NoResultException("There are no users");

            return result;
        }

        public void UpdateModel(IDictionary<string, string> valuePairs, int userId)
        {
            //TODO: subscription
            var req = Convert.ToInt32(valuePairs["id"]);
            var toUpdate = _usersRepository.GetById(req);
            if (toUpdate == null)
                throw new NoResultException("No User with id = " + req);

            toUpdate.name = valuePairs["name"];
            toUpdate.username = valuePairs["username"];
            toUpdate.password = valuePairs["password"];

            _usersRepository.Update(toUpdate);
        }

        public void DeleteModel(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var toDelete = _usersRepository.GetById(req);
            if (toDelete == null)
                throw new NoResultException("No User with id = " + req);
            var adsRepo = new Repository<Ad>(new FinalProjectEntities());
            var ads = adsRepo.GetAll().Where(s => s.userId == req);
            _usersRepository.Delete(toDelete);
        }

        public void AddNewModel(IDictionary<string, string> valuePairs, int userId)
        {
            //TODO: subscription
            var newUsername = valuePairs["username"];
            var getUsers = _usersRepository.GetAll().Where(user => user.username.Equals(newUsername, StringComparison.InvariantCultureIgnoreCase));

            if (getUsers.Any())
                throw new InvalidInputException("Username already exists");

            var subscriptionType = valuePairs["subscription"];
            int subscriptionValue = 0;
            int nrAds = 0;

            if(subscriptionType.Equals("free", StringComparison.InvariantCultureIgnoreCase))
            {
                subscriptionValue = (int)Subscription.Free;
                nrAds = 2;
            }
            else if(subscriptionType.Equals("premium", StringComparison.InvariantCultureIgnoreCase))
            {
                subscriptionValue = (int)Subscription.Premium;
                nrAds = 5;
            }

            var newUser = new User()
            {
                password = valuePairs["password"],
                username = valuePairs["username"],
                name = valuePairs["name"],
                subscription = subscriptionValue,
                adsAllowed = nrAds,
                adsCounter = 0
            };

            _usersRepository.Insert(newUser);
        }

        //cand fac update se reseteaza nr de ads-uri care a fost pus in acea zi
        public void UpdateSubscription(IDictionary<string, string> valuePairs, int userId)
        {
            var user = valuePairs["id"];
            int id = 0;
            try
            {
                id = Convert.ToInt32(user);
            }
            catch (FormatException)
            {
                throw new InvalidInputException("Invalid format for Id");
            }

            if(id <= 0)
            {
                throw new InvalidInputException("Invalid format for Id");
            }

            var getUsers = _usersRepository.GetAll().Where(s => s.id == id);

            if (!getUsers.Any())
                throw new InvalidInputException("No user with id = " + id);

            int nrAds = 0;
            var subscriptionValue = 0;
            var newSubscription = valuePairs["subscription"];
            if (newSubscription.Equals("Free", StringComparison.InvariantCultureIgnoreCase))
            {
                subscriptionValue = (int)Subscription.Free;
                nrAds = 2;
            }
            else if (newSubscription.Equals("Premium", StringComparison.InvariantCultureIgnoreCase))
            {
                subscriptionValue = (int)Subscription.Premium;
                nrAds = 5;
            }

            getUsers.First().subscription = subscriptionValue;
            getUsers.First().adsAllowed = nrAds;
            getUsers.First().adsCounter = 0;
        }

        //public void AddNewSubscription(IDictionary<string, string> valuePairs, int userId)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
    }
}
