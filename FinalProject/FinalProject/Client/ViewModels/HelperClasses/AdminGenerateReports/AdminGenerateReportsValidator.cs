using Client.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.AdminGenerateReports
{
    class AdminGenerateReportsValidator : IReportsValidator
    {
        public ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["userId"]) || valuePairs["userId"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the User you want to generate reports for");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
