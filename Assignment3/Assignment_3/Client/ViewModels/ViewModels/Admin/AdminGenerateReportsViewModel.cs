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
    class AdminGenerateReportsViewModel: AdminViewModel<Ad>
    {
        #region Constructors
        public AdminGenerateReportsViewModel(IMessageBoxService messageBoxService, IReportsValidator validator)
            : base(messageBoxService, validator) { }
        #endregion

        public void GenerateReport(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedAdmin, FileTypes file, FileCreator creator)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            AdminGenerateReportsHelper.GenerateReport(valuePairs, authenticatedAdmin, file, creator);
        }
    }
}
