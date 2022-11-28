using Assignment_2.Models;
using Assignment_2.Models.Repository;
using Assignment_2.Models.Repository.Interfaces;
using Assignment_2.View.HelperClasses;
using Assignment_2.ViewModels.Exceptions;
using Assignment_2.ViewModels.HelperClasses;
using Assignment_2.ViewModels.Interfaces;
using Assignment_2.Views.HelperClasses;
using Assignment_2.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using Assignment_2.Model;

namespace Assignment_2.ViewModels.ViewModels
{
    public class RegularUserSearchAdsViewModel : RegularUserViewModel<Ad>, IDisposable
    {
        #region Properties
        private const string _adsNotFound = "Ads Not Found";
        #endregion

        #region Constructors
        public RegularUserSearchAdsViewModel(IMessageBoxService messageBoxService, IFilterValidator<Ad> validator):base(messageBoxService, validator)
        {
        }

        public RegularUserSearchAdsViewModel(IRepository<Ad> repository) : base(repository){}
        #endregion

        public IEnumerable<Ad> GetModelsFiltered(IDictionary<string, string> filterRequest)
        {
            try
            {
                return AdsFilter.Filter(Repository.GetAll(), Validator as FilterValidator<Ad>, filterRequest, _adsNotFound);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
