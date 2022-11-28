using Client.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.RegularUserAdsPersonalization
{
    class RegularUserFavoritesValidator : IFavoritesValidator
    {
        public ValidationResult ValidateInputsForDeleteModel(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["favId"]) || valuePairs["favId"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the ad you want to remove from favorites - favId");
            }

            if (!((string.IsNullOrEmpty(valuePairs["rating"])) &&
                 (string.IsNullOrEmpty(valuePairs["adId"]))
               ))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["adId"]) || valuePairs["adId"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the ad you want to add to favorites");
            }

            if (!((string.IsNullOrEmpty(valuePairs["rating"])) &&
                (string.IsNullOrEmpty(valuePairs["favId"]))
              ))
            {
                return new ValidationResult(false, "Only adId should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
