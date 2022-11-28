using Assignment_2.ViewModel.HelperClasses;
using Assignment_2.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.HelperClasses
{
    class AdminManageUsersAdsValidator : ICrudValidator
    {
        public ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["userID"]) ||
                string.IsNullOrWhiteSpace(valuePairs["location"]) ||
                string.IsNullOrWhiteSpace(valuePairs["size"]) ||
                string.IsNullOrWhiteSpace(valuePairs["price"])
                ))
            {
                return new ValidationResult(false, "Columns userID, location, size, price should contain values");
            }

            double size = 0;
            double price = 0;

            try
            {
                size = Convert.ToDouble(valuePairs["size"]);
                price = Convert.ToDouble(valuePairs["price"]);
            }
            catch(FormatException)
            {
                return new ValidationResult(false, "Invalid values for size or price");
            }

            if (!string.IsNullOrEmpty(valuePairs["id"]))
            {
                return new ValidationResult(false, "Do not insert the id " + Environment.NewLine +
                                "it will be generated automatically");
            }

            return new ValidationResult(true, string.Empty);
        }

        public ValidationResult ValidateInputsForDeleteModel(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the ad you want to delete");
            }

            if (!((string.IsNullOrEmpty(valuePairs["userID"])) &&
                 (string.IsNullOrEmpty(valuePairs["location"])) &&
                 (string.IsNullOrEmpty(valuePairs["size"]) &&
                 string.IsNullOrEmpty(valuePairs["price"])
               )))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the Ad you want to find");
            }

            if (!((string.IsNullOrEmpty(valuePairs["userID"])) &&
                 (string.IsNullOrEmpty(valuePairs["location"])) &&
                 (string.IsNullOrEmpty(valuePairs["size"]) &&
                 string.IsNullOrEmpty(valuePairs["price"])
               )))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["userID"]) ||
                string.IsNullOrWhiteSpace(valuePairs["location"]) ||
                string.IsNullOrWhiteSpace(valuePairs["size"]) ||
                string.IsNullOrWhiteSpace(valuePairs["price"])
                ))
            {
                return new ValidationResult(false, "Columns userID, location, size, price should contain values");
            }


            if (string.IsNullOrEmpty(valuePairs["id"]))
            {
                return new ValidationResult(false, "Insert the id for the Ad you want to update");
            }

            double size = 0;
            double price = 0;

            try
            {
                size = Convert.ToDouble(valuePairs["size"]);
                price = Convert.ToDouble(valuePairs["price"]);
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "Invalid values for size or price");
            }



            return new ValidationResult(true, string.Empty);
        }
    }
}
