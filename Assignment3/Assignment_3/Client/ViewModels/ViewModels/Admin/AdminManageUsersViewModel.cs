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
    class AdminManageUsersViewModel : AdminViewModel<User>
    {
        #region Constructors
        public AdminManageUsersViewModel(IMessageBoxService messageBoxService, ICrudValidator validator)
            : base(messageBoxService, validator) { }
        #endregion

        public IEnumerable<User> GetModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            return AdminManageUsersHelper.GetModelById(valuePairs, authenticatedAdmin);
        }

        public void UpdateModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminManageUsersHelper.UpdateModel(valuePairs, authenticatedAdmin);
        }

        public void DeleteModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminManageUsersHelper.DeleteModel(valuePairs, authenticatedAdmin);
        }

        public void AddNewModel(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminManageUsersHelper.AddNewModel(valuePairs, authenticatedAdmin);
        }

        public IEnumerable<User> GetAllModels(IDictionary<string, string> valuePairs, int authenticatedAdmin)
        {
            return AdminManageUsersHelper.GetAllModels(valuePairs, authenticatedAdmin);
        }
    }
}
