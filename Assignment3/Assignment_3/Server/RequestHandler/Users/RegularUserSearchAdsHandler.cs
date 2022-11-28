using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Server.HelperClasses;
using Server.HelperClasses.Interfaces;
using Server.Repository;
using Server.Repository.Interfaces;

namespace Server.RequestHandler.Users
{
    public class RegularUserSearchAdsHandler
    {
        public IRepository<Ad> _repository;
        private readonly IFilterValidator<Ad> _validator;
        private const string _adsNotFound = "Ads Not Found";

        public RegularUserSearchAdsHandler()
        {
            this._validator = new FilterValidator<Ad>();
            this._repository = new Repository<Ad>(new Assignment3Entities());
        }

        public virtual IEnumerable<Ad> GetModelsFiltered(IDictionary<string, string> filterRequest)
        {
            try
            {
                return AdsFilter.Filter(_repository.GetAll(), _validator, filterRequest, _adsNotFound);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
