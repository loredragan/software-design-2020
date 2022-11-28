using Client.ViewModels.Connection;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.Interfaces;
using Client.Views.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.ViewModels.RegularUser
{
    public class RegularUserSearchAdsViewModel : RegularUserViewModel<Ad>
    {
        #region Private Members
        private const string _adsNotFound = "Ads Not Found";
        #endregion

        #region Constructors
        public RegularUserSearchAdsViewModel(IMessageBoxService messageBoxService, IFilterValidator<Ad> validator) : base(messageBoxService, validator)
        {

        }

        public IEnumerable<Ad> GetModelsFiltered(IDictionary<string, string> filterRequest)
        {
            IEnumerable<Ad> result;
            try
            {
                result =  (IEnumerable<Ad>)ConnectionHelper.SendRequest(filterRequest, 0, "RegularUserSearchAds",
                    "SearchWithFilter");
            }
            catch (Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(filterRequest, 0, "RegularUserSearchAds",
                    "SearchWithFilter"));
            }

            return result;
        }

        public IEnumerable<Rating> GetAdsByRating(IDictionary<string, string> valuePairs)
        {
            IEnumerable<Rating> result;
            try
            {
                result = (IEnumerable<Rating>)ConnectionHelper.SendRequest(valuePairs, 0, "RegularUserSearchAds",
                    "SearchByRating");
            }
            catch (Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, 0, "RegularUserSearchAds",
                    "SearchByRating"));
            }

            return result;
        }
        #endregion
    }
}
