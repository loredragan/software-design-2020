using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels.Interfaces;

namespace Client.ViewModels.HelperClasses
{
    class AdminGenerateReportsValidator  : IReportsValidator
    {
        public ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["userID"]) || valuePairs["userID"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the User you want to generate reports for");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
