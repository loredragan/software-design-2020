using Assignment_2.Models;
using Assignment_2.ViewModel.HelperClasses;
using Assignment_2.ViewModels.Exceptions;
using Assignment_2.ViewModels.HelperClasses;
using Assignment_2.ViewModels.Interfaces;
using Assignment_2.Views.Interfaces;
using Assignment_2.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.ViewModels.Admin
{
    class AdminGenerateReportsViewModel:AdminViewModel<Ad>, IDisposable
    {
        #region Constructors
        public AdminGenerateReportsViewModel(IMessageBoxService messageBoxService, IReportsValidator validator)
            : base(messageBoxService, validator) { }
        #endregion

        public void GenerateReport(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin, FileTypes file, FileCreator creator)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminGenerateReportsHelper.GenerateReport(valuePairs, Repository, authenticatedAdmin, file, creator);
        }
    }
}
