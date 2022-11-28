using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Server.Exceptions;
using Server.Repository;
using Server.Repository.Interfaces;

namespace Server.RequestHandler.Admins
{
    public class AdminManageUsersHandler:AdminsHandler
    {
        public IRepository<User> _repository;
        public AdminManageUsersHandler() : base()
        {
            this._repository = new Repository<User>(new Assignment3Entities());
        }

        public IEnumerable<User> GetModelById(IDictionary<string, string> valuePairs)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var result = _repository.GetById(req);
            if(result == null)
                throw new NoResultException("No user with id = " + req);

            var array = new List<User>
            {
                result
            };

            return array;
        }

        public IEnumerable<User> GetAllModels(IDictionary<string, string> valuePairs)
        {
            var result = _repository.GetAll().ToList();
            if(!result.Any())
                throw new NoResultException("There are no users");

            return result;
        }

        public void UpdateModel(IDictionary<string, string> valuePairs)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var toUpdate = _repository.GetById(req);
            if (toUpdate == null)
                throw new NoResultException("No User with id = " + req);

            toUpdate.name = valuePairs["name"];
            toUpdate.username = valuePairs["username"];
            toUpdate.password = valuePairs["password"];

            _repository.Update(toUpdate);
        }

        public void AddNewModel(IDictionary<string, string> valuePairs)
        {
            var newUsername = valuePairs["username"];
            var getUsers = _repository.GetAll().Where(user => user.username.Equals(newUsername, StringComparison.InvariantCultureIgnoreCase));
            if (getUsers.Any())
                throw new InvalidInputException("Username already exists");


            var newUser = new User()
            {
                password = valuePairs["password"],
                username = valuePairs["username"],
                name = valuePairs["name"]
            };

            _repository.Insert(newUser);
        }

        public void DeleteModel(IDictionary<string, string> valuePairs)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var toDelete = _repository.GetById(req);
            if (toDelete == null)
                throw new NoResultException("No User with id = " + req);
            var adsRepo = new Repository<Ad>(new Assignment3Entities());
            var ads = adsRepo.GetAll().Where(s => s.userID == req);
            _repository.Delete(toDelete);
        }

    }
}
