using Client.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.RegularUserManageAds
{
    public class RegularUserManagePersonalAdsValidator : ICrudValidator
    {
        public virtual ValidationResult ValidateInputsForDeleteModel(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the ad you want to delete");
            }

            if (!((string.IsNullOrEmpty(valuePairs["location"])) &&
                 (string.IsNullOrEmpty(valuePairs["size"])) &&
                 (string.IsNullOrEmpty(valuePairs["price"]))
                   ))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the ad you want to find");
            }

            if (!((string.IsNullOrEmpty(valuePairs["location"])) &&
                  (string.IsNullOrEmpty(valuePairs["size"])) &&
                  (string.IsNullOrEmpty(valuePairs["price"]))
                ))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["location"]) ||
                string.IsNullOrWhiteSpace(valuePairs["size"]) ||
                string.IsNullOrWhiteSpace(valuePairs["price"])))
            {
                return new ValidationResult(false, "Columns location, size, price should contain values");
            }

            if (!string.IsNullOrEmpty(valuePairs["id"]))
            {
                return new ValidationResult(false, "Do not insert the id " + Environment.NewLine +
                                "it will be generated automatically");
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
                return new ValidationResult(false, "Invalid amount or price");
            }

            if (!OnCreateValidateAd.IsEntityValid(size, price))
            {
                return new ValidationResult(false, "The values for the new ad are invalid");
            }

            return new ValidationResult(true, string.Empty);
        }

        public virtual ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["location"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["size"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["price"])))
            {
                return new ValidationResult(false, "Columns location, size, price should contain values");
            }

            if (string.IsNullOrEmpty(valuePairs["id"]))
            {
                return new ValidationResult(false, "Insert the id for the ad you want to update");
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
                return new ValidationResult(false, "Invalid amount or price");
            }

            if (!OnCreateValidateAd.IsEntityValid(size, price))
            {
                return new ValidationResult(false, "The values for the ad you want" + Environment.NewLine +
                    "to update are invalid");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
