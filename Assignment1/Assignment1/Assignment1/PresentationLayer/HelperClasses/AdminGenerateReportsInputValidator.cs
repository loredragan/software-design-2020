using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1.PresentationLayer.HelperClasses
{
    public static class AdminGenerateReportsInputValidator
    {
        public static ValidationResult ValidateInputsForGenerateReportInInterval(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the employee you want to " + Environment.NewLine + 
                                                   "generate reports for");
            }

            if (((string.IsNullOrEmpty(valuePairs["fromDate"])) &&
                  (string.IsNullOrEmpty(valuePairs["toDate"]))
                ))
            {
                return new ValidationResult(false, "Insert the time interval");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
