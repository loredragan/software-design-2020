using Client.ViewModels.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.Interfaces
{
    public interface IRatingsValidator : IValidator
    {
        ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs);

        ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs);

        ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs);
    }
}
