using Client.ViewModels.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.Interfaces
{
    interface IFavoritesValidator : IValidator
    {
        ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs);

        ValidationResult ValidateInputsForDeleteModel(IDictionary<string, string> valuePairs);
    }
}
