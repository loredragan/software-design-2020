using Client.ViewModels.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.Interfaces
{
    public interface IChatValidator : IValidator
    {
        ValidationResult ValidateInputsForSendMessage(IDictionary<string, string> valuePairs);

        ValidationResult ValidateInputsForGetInbox(IDictionary<string, string> valuePairs);
    }
}
