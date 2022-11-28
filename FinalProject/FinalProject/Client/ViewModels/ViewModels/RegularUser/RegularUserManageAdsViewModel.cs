using Client.ViewModels.Exceptions;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.HelperClasses.RegularUserManageAds;
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
    class RegularUserManageAdsViewModel : RegularUserViewModel<Ad>
    {
        #region Constructors
        public RegularUserManageAdsViewModel(IMessageBoxService messageBoxSerivce, ICrudValidator validator)
            : base(messageBoxSerivce, validator) { }
        #endregion

        #region Exposed Members
        public IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            return RegularUserManagePersonalAdsHelper.GetModelByIdHelper(valuePairs, authenticatedUser);
        }

        public void UpdateModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManagePersonalAdsHelper.UpdateModel(valuePairs, authenticatedUser);
        }

        public void DeleteModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManagePersonalAdsHelper.DeleteModel(valuePairs, authenticatedUser);
        }

        public void AddNewModel(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManagePersonalAdsHelper.AddNewModel(valuePairs, authenticatedUser);
        }

        public IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, int authenticatedUser)
        {
            return RegularUserManagePersonalAdsHelper.GetAllModels(valuePairs, authenticatedUser);
        }
        #endregion
    }
}
