using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.Exceptions;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.Interfaces;
using Client.Views.Interfaces;

namespace Client.ViewModels.ViewModels.Admin
{
    class AdminManageUsersAdsViewModel: AdminViewModel<Ad>
    {

        #region Constructors
        public AdminManageUsersAdsViewModel(IMessageBoxService messageBoxService, ICrudValidator validator)
            : base(messageBoxService, validator) { }
        #endregion

        public IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            return AdminManageUsersAdsHelper.GetModelById(valuePairs, authenticatedAdmin);
        }

        public void UpdateModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminManageUsersAdsHelper.UpdateModel(valuePairs, authenticatedAdmin);
        }

        public void DeleteModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminManageUsersAdsHelper.DeleteModel(valuePairs, authenticatedAdmin);
        }

        public void AddNewModel(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminManageUsersAdsHelper.AddNewModel(valuePairs, authenticatedAdmin);
        }

        public IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, int authenticatedAdmin)
        {
            return AdminManageUsersAdsHelper.GetAllModels(valuePairs, authenticatedAdmin);
        }
    }
}
