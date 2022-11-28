using Client.ViewModels.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.Interfaces
{
    public interface ISubscriptionValidator : IValidator
    {
        ValidationResult ValidateInputsForUpdateSubscription(IDictionary<string, string> valuePairs);
    }
}
