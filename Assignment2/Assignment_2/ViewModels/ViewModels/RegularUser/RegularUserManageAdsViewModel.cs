using Assignment_2.Models;
using Assignment_2.ViewModel.HelperClasses;
using Assignment_2.ViewModels.Exceptions;
using Assignment_2.ViewModels.HelperClasses;
using Assignment_2.ViewModels.Interfaces;
using Assignment_2.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.ViewModels
{
    class RegularUserManageAdsViewModel : RegularUserViewModel<Ad>, IDisposable
    {
        #region Constructors
        public RegularUserManageAdsViewModel(IMessageBoxService messageBoxSerivce, ICrudValidator validator)
            :base(messageBoxSerivce, validator) { }
        #endregion

        public IEnumerable<Ad> GetModelById( IDictionary<string, string> valuePairs,ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            return RegularUserManageAdsHelper.GetModelByIdHelper(valuePairs, Repository, authenticatedUser);
        }

        public void UpdateModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManageAdsHelper.UpdateModel(valuePairs, Repository, authenticatedUser);
        }

        public void DeleteModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManageAdsHelper.DeleteModel(valuePairs, Repository, authenticatedUser);
        }

        public void AddNewModel(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManageAdsHelper.AddNewModel(valuePairs, Repository, authenticatedUser);
        }

        public IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, int autheticatedUser)
        {
            return RegularUserManageAdsHelper.GetAllModels(valuePairs, Repository, autheticatedUser);
        }
    }
}
