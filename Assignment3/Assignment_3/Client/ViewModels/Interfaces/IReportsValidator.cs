using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels.HelperClasses;

namespace Client.ViewModels.Interfaces
{
    public interface IReportsValidator : IValidator
    {
        ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs);
    }
}
