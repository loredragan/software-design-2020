using FinalProject.Models;
using Server.Exceptions;
using Server.HelperClasses;
using Server.HelperClasses.Interfaces;
using Server.Repository;
using Server.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestHandler.Users
{
    class RegularUserSearchAdsHandler : RegularUserHandler
    {
        #region Private Members
        private readonly FinalProjectEntities _context;
        private readonly IRepository<Ad> _adsRepository;
        private readonly IFilterValidator<Ad> _validator;
        private readonly IRepository<Rating> _ratingsRepository;
        private const string _adsNotFound = "Ads Not Found";
        #endregion

        #region Constructors
        public RegularUserSearchAdsHandler()
        {
            this._context = new FinalProjectEntities();
            this._adsRepository = new Repository<Ad>(_context);
            this._validator = new FilterValidator<Ad>();
            this._ratingsRepository = new Repository<Rating>(_context);
        }
        #endregion

        #region Exposed Methods
        public IEnumerable<Ad> GetModelsFiltered(IDictionary<string, string> filterRequest, int userId)
        {
            try
            {
                return AdsFilter.Filter(_adsRepository.GetAll(), _validator, filterRequest, _adsNotFound);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Rating> SearchByRating(IDictionary<string, string> valuePairs, int userId)
        {

            IQueryable<Rating> rats = _ratingsRepository.GetAll();

            if (_validator.CheckIfArgumentIsNotDefault(valuePairs["rating"]))
            {
                var rate = 0;
                try
                {
                    rate = Convert.ToInt32(valuePairs["rating"]);

                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid number format");
                }

                if ((rate <= 0) || (rate > 5))
                    throw new InvalidInputException("Ads are rated with values between 1 and 5");
                rats = rats.Where(s => s.value == rate);
            }

            return rats.ToList();
        }
        #endregion
    }
}
