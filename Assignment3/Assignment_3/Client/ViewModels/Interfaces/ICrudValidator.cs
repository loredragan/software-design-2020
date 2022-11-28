using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels.HelperClasses;

namespace Client.ViewModels.Interfaces
{
    interface ICrudValidator : IValidator
    {
        ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs);

        ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs);

        ValidationResult ValidateInputsForDeleteModel(IDictionary<string, string> valuePairs);

        ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs);
    }
}
