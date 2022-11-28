using Client.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.AdminManageRatings
{
    class AdminManageRatingsValidator : IRatingsValidator
    {
        public ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs)
        {
            throw new NotImplementedException();
        }

        public ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the rating you want to find");
            }

            if (!((string.IsNullOrEmpty(valuePairs["rating"]))
               ))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["rating"]))
            {
                return new ValidationResult(false, "Column rating should contain a value");
            }

            if (string.IsNullOrEmpty(valuePairs["id"]))
            {
                return new ValidationResult(false, "Insert the id for the rating you want to update");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
