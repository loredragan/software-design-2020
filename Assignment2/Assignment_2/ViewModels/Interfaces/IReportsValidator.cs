using Assignment_2.ViewModel.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.Interfaces
{
    public interface IReportsValidator : IValidator
    {
        ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs);
    }
}
