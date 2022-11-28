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

namespace Assignment_2.ViewModels.ViewModels.Admin
{
    class AdminManageUsersAdsViewModel: AdminViewModel<Ad>, IDisposable
    {
        #region Constructors
        public AdminManageUsersAdsViewModel(IMessageBoxService messageBoxService, ICrudValidator validator)
            : base(messageBoxService, validator) { }
        #endregion

        public IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            return AdminManageUsersAdsHelper.GetModelById(valuePairs, Repository, authenticatedAdmin);
        }

        public void UpdateModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminManageUsersAdsHelper.UpdateModel(valuePairs, Repository, authenticatedAdmin);
        }

        public void DeleteModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminManageUsersAdsHelper.DeleteModel(valuePairs, Repository, authenticatedAdmin);
        }

        public void AddNewModel(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminManageUsersAdsHelper.AddNewModel(valuePairs, Repository, authenticatedAdmin);
        }

        public IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, int authenticatedAdmin)
        {
            return AdminManageUsersAdsHelper.GetAllModels(valuePairs, Repository, authenticatedAdmin);
        }
    }
}
