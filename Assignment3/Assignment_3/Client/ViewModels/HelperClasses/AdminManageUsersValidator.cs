
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels.Interfaces;

namespace Client.ViewModels.HelperClasses
{
    public class AdminManageUsersValidator: ICrudValidator
    {
        public virtual ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["username"]) ||
                string.IsNullOrWhiteSpace(valuePairs["password"]) ||
                string.IsNullOrWhiteSpace(valuePairs["name"])))
            {
                return new ValidationResult(false, "Columns username, password, name should contain values");
            }

            if (!string.IsNullOrEmpty(valuePairs["id"]))
            {
                return new ValidationResult(false, "Do not insert the id " + Environment.NewLine +
                                "it will be generated automatically");
            }

            return new ValidationResult(true, string.Empty);
        }

        public virtual ValidationResult ValidateInputsForDeleteModel(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the user you want to delete");
            }

            if (!((string.IsNullOrEmpty(valuePairs["username"])) &&
                 (string.IsNullOrEmpty(valuePairs["password"])) &&
                 (string.IsNullOrEmpty(valuePairs["name"]))
               ))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public virtual ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the User you want to find");
            }

            if (!((string.IsNullOrEmpty(valuePairs["username"])) &&
                  (string.IsNullOrEmpty(valuePairs["password"])) &&
                  (string.IsNullOrEmpty(valuePairs["name"]))
                ))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public virtual ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["username"]) ||
                string.IsNullOrWhiteSpace(valuePairs["password"]) ||
                string.IsNullOrWhiteSpace(valuePairs["name"])))
            {
                return new ValidationResult(false, "Columns username, password, name should contain values");
            }

            if (string.IsNullOrEmpty(valuePairs["id"]))
            {
                return new ValidationResult(false, "Insert the id for the User you want to update");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
