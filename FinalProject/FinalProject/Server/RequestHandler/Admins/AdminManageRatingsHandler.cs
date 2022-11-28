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
    class AdminManageRatingsHandler : AdminHandler, IDisposable
    {
        #region Private Members
        private readonly FinalProjectEntities _context;
        private readonly IRepository<Rating> _ratingsRepository;
        private readonly IRepository<User> _usersRepository;
        #endregion

        #region Constructors
        public AdminManageRatingsHandler()
        {
            this._context = new FinalProjectEntities();
            this._ratingsRepository = new Repository<Rating>(_context);
            this._usersRepository = new Repository<User>(_context);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Exposed Methods
        public IEnumerable<Rating> GetAllModels(IDictionary<string, string> valuePairs, int userId)
        {
            var result = _ratingsRepository.GetAll().ToList();
            if (!result.Any())
                throw new NoResultException("There are no ratings");

            return result;
        }

        public IEnumerable<Rating> GetModelById(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var result = _ratingsRepository.GetById(req);
            if (result == null)
                throw new NoResultException("No rating with id = " + req);

            var array = new List<Rating>
            {
                result
            };

            return array;
        }

        public void UpdateModel(IDictionary<string, string> valuePairs, int userId)
        {
            var req = Convert.ToInt32(valuePairs["id"]);
            var toUpdate = _ratingsRepository.GetById(req);
            if (toUpdate == null)
                throw new NoResultException("No rating with id = " + req);
            


            var updatedRating = Convert.ToInt32(valuePairs["rating"]);
            toUpdate.userId = toUpdate.id;
            toUpdate.username = toUpdate.username;
            toUpdate.value = updatedRating;
            toUpdate.adId = toUpdate.adId;
        }
        #endregion
    }
}
