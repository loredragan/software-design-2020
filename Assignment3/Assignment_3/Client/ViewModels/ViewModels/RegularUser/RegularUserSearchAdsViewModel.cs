using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.Connection;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.Interfaces;
using Client.Views.Interfaces;

namespace Client.ViewModels.ViewModels.RegularUser
{
    public class RegularUserSearchAdsViewModel : RegularUserViewModel<Ad>
    {
        #region Properties
        private const string _adsNotFound = "Ads Not Found";
        #endregion

        #region Constructors
        public RegularUserSearchAdsViewModel(IMessageBoxService messageBoxService, IFilterValidator<Ad> validator) : base(messageBoxService, validator)
        {
        }
        #endregion

        public IEnumerable<Ad> GetModelsFiltered(IDictionary<string, string> filterRequest)
        {
            try
            {
                return (IEnumerable<Ad>)ConnectionHelper.SendRequest(filterRequest, 0, "RegularUserSearchAds",
                    string.Empty);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
