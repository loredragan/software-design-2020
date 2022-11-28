using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.HelperClasses;

namespace Assignment1.PresentationLayer.HelperClasses
{
    static class EmployeeClientsInputValidator
    {
        public static ValidationResult ValidateInputsForFindById(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["idCard"]) || valuePairs["idCard"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the IdCard for the client you want to find");
            }

            if (!((string.IsNullOrEmpty(valuePairs["name"])) &&
                  (string.IsNullOrEmpty(valuePairs["cnp"])) &&
                  (string.IsNullOrEmpty(valuePairs["age"])) &&
                  (string.IsNullOrEmpty(valuePairs["address"]))
                  ))
            {
                return new ValidationResult(false, "Only IdCard should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["name"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["cnp"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["age"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["address"])))
            {
                return new ValidationResult(false, "Insert values for the new client");
            }

            if (!(string.IsNullOrEmpty(valuePairs["idCard"])))
            {
                return new ValidationResult(false, "Do not insert the IdCard for the new client." + Environment.NewLine + " it will be set automatically");
            }

            long newCnp;
            int newAge;

            try
            {
                newCnp = Convert.ToInt64(valuePairs["cnp"]);
                newAge = Convert.ToInt32(valuePairs["age"]);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Invalid age or cnp");
            }


            if (OnCreateValidateClient.IsEntityValid(valuePairs["name"], newCnp, newAge, valuePairs["address"]) == false)
            {
                return new ValidationResult(false, "The values for the new client are invalid");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["name"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["cnp"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["age"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["address"])))
            {
                return new ValidationResult(false, "Columns name, age, cnp and address should contain values");
            }

            if (string.IsNullOrEmpty(valuePairs["idCard"]))
            {
                return new ValidationResult(false, "Insert the idCard for the client you want to update");
            }

            long newCnp;
            int newAge;

            try
            {
                newCnp = Convert.ToInt64(valuePairs["cnp"]);
                newAge = Convert.ToInt32(valuePairs["age"]);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Invalid age or cnp");
            }

            if (OnCreateValidateClient.IsEntityValid(valuePairs["name"], newCnp, newAge, valuePairs["address"]) == false)
            {
                return new ValidationResult(false, "The new values for the client are invalid");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
