using Assignment_2.ViewModel.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.Interfaces
{
    interface ICrudValidator : IValidator
    {
        ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs);

        ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs);

        ValidationResult ValidateInputsForDeleteModel(IDictionary< string, string> valuePairs);

        ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs);
    }
}
