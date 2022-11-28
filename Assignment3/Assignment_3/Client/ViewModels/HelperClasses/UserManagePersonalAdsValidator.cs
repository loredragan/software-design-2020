using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels.Interfaces;

namespace Client.ViewModels.HelperClasses
{
    public class UserManagePersonalAdsValidator: ICrudValidator
    {
        public virtual ValidationResult ValidateInputsForDeleteModel(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the ad you want to delete");
            }

            if (!((string.IsNullOrEmpty(valuePairs["location"])) &&
                 (string.IsNullOrEmpty(valuePairs["size"])) &&
                 (string.IsNullOrEmpty(valuePairs["price"])) &&
                 (string.IsNullOrEmpty(valuePairs["adID"]))
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
                  (string.IsNullOrEmpty(valuePairs["price"])) &&
                  (string.IsNullOrEmpty(valuePairs["adID"]))
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

            if (!((string.IsNullOrEmpty(valuePairs["adID"]))
                  ))
            {
                return new ValidationResult(false, "column adID should be empty");
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

            if (!((string.IsNullOrEmpty(valuePairs["userID"])) &&
                  (string.IsNullOrEmpty(valuePairs["adID"]))))
            {
                return new ValidationResult(false, "column userID and adID should be empty");
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

        public ValidationResult ValidateInputForAddToFavourites(IDictionary<string, string> valuePairs)
        {
            if (!((string.IsNullOrEmpty(valuePairs["location"])) &&
                  (string.IsNullOrEmpty(valuePairs["size"])) &&
                  (string.IsNullOrEmpty(valuePairs["price"])) &&
                  (string.IsNullOrEmpty(valuePairs["id"])) 
                ))
            {
                return new ValidationResult(false, "Only userID and adID should contain a value");
            }

            if (
                 string.IsNullOrWhiteSpace(valuePairs["adID"])
                 )
            {
                return new ValidationResult(false, "Column adID should contain values");
            }

            int ad = 0;
            try
            {
                ad = Convert.ToInt32(valuePairs["adID"]);
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "Invalid data for adID");
            }

            return new ValidationResult(true, string.Empty);
        }

        public virtual ValidationResult ValidateInputsForSendMessage(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["userID"]) || valuePairs["userID"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the user you want to send a message to");
            }

            if (string.IsNullOrWhiteSpace(valuePairs["messageContent"]) || valuePairs["userID"].Equals(string.Empty))
            {
                return new ValidationResult(false, "you can't send an empty message");
            }

            if (!((string.IsNullOrEmpty(valuePairs["location"])) &&
                  (string.IsNullOrEmpty(valuePairs["size"])) &&
                  (string.IsNullOrEmpty(valuePairs["price"])) &&
                  (string.IsNullOrEmpty(valuePairs["adID"])) &&
                  (string.IsNullOrEmpty(valuePairs["id"]))
                ))
            {
                return new ValidationResult(false, "Only userID and content should contain a value");
            }

            var userId = 0;
            try
            {
                userId = Convert.ToInt32(valuePairs["userID"]);
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "Invalid format for userID");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
