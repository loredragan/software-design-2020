using Client.ViewModels.Exceptions;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.HelperClasses.RegularUserAdsPersonalization;
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
    class RegularUserManageRatingsViewModel : RegularUserViewModel<Rating>
    {
        #region Constructors
        public RegularUserManageRatingsViewModel(IMessageBoxService messageBoxSerivce, IValidator validator)
            : base(messageBoxSerivce, validator) { }
        #endregion

        #region Exposed Members
        public void AddNewModel(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserRatingsHelper.AddNewModel(valuePairs, authenticatedUser);
        }

        public IEnumerable<Rating> GetAllModels(IDictionary<string, string> valuePairs, int authenticatedUser)
        {
            return RegularUserRatingsHelper.GetAllModels(valuePairs, authenticatedUser);
        }
        #endregion
    }
}
