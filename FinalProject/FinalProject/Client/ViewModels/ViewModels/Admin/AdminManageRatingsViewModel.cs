using Client.ViewModels.Exceptions;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.HelperClasses.AdminManageRatings;
using Client.ViewModels.Interfaces;
using Client.Views.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.ViewModels.Admin
{
    class AdminManageRatingsViewModel : AdminViewModel<Rating>
    {
        #region Constructors
        public AdminManageRatingsViewModel(IMessageBoxService messageBoxService, IValidator validator)
            : base(messageBoxService, validator) { }
        #endregion

        public IEnumerable<Rating> GetModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            return AdminManageRatingsHelper.GetModelById(valuePairs, authenticatedAdmin);
        }

        public void UpdateModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminManageRatingsHelper.UpdateModel(valuePairs, authenticatedAdmin);
        }

        public IEnumerable<Rating> GetAllModels(IDictionary<string, string> valuePairs, int authenticatedAdmin)
        {
            return AdminManageRatingsHelper.GetAllModels(valuePairs, authenticatedAdmin);
        }
    }
}
