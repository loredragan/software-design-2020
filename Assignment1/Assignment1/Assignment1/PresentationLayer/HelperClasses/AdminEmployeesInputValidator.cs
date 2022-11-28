using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.PresentationLayer.HelperClasses
{
    public static class AdminEmployeesInputValidator
    {
        public static ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["username"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["password"])))
            {
                return new ValidationResult(false, "Insert values for the new employee");
            }

            if (!(string.IsNullOrEmpty(valuePairs["id"])))
            {
                return new ValidationResult(false, "Do not insert the id for the new employee." + Environment.NewLine + " it will be set automatically");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForDeleteModel(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the employee you want to delete");
            }

            if (!((string.IsNullOrEmpty(valuePairs["username"])) &&
                  (string.IsNullOrEmpty(valuePairs["password"]))
                ))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["username"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["password"])))
            {
                return new ValidationResult(false, "Columns username and password should contain values");
            }

            if (string.IsNullOrEmpty(valuePairs["id"]))
            {
                return new ValidationResult(false, "Insert the id for the employee you want to update");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForFindById(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the employee you want to find");
            }

            if (!((string.IsNullOrEmpty(valuePairs["username"])) &&
                  (string.IsNullOrEmpty(valuePairs["password"]))
                ))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
