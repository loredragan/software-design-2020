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
    class RegularUserManageFavoritesViewModel : RegularUserViewModel<Favorite>
    {
        #region Constructors
        public RegularUserManageFavoritesViewModel(IMessageBoxService messageBoxSerivce, IValidator validator)
            : base(messageBoxSerivce, validator) { }
        #endregion

        #region Exposed Members
        public void AddNewModel(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserFavoritesHelper.AddNewModel(valuePairs, authenticatedUser);
        }

        public void DeleteModel(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserFavoritesHelper.DeleteModel(valuePairs, authenticatedUser);
        }

        public IEnumerable<Favorite> GetAllModels(IDictionary<string, string> valuePairs, int authenticatedUser)
        {
            return RegularUserFavoritesHelper.GetAllModels(valuePairs, authenticatedUser);
        }
        #endregion
    }
}
