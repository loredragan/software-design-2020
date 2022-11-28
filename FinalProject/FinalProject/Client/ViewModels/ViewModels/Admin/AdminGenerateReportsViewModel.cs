using Client.ViewModels.Exceptions;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.HelperClasses.AdminGenerateReports;
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
    class AdminGenerateReportsViewModel : AdminViewModel<Ad>
    {
        #region Constructors
        public AdminGenerateReportsViewModel(IMessageBoxService messageBoxService, IReportsValidator validator)
            : base(messageBoxService, validator) { }
        #endregion

        #region Exposed Methods
        public void GenerateReport(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin, FileTypes file, FileCreator creator)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminGenerateReportsHelper.GenerateReport(valuePairs, authenticatedAdmin, file, creator);
        }
        #endregion
    }
}
