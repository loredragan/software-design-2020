using Client.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.RegularUserAdsPersonalization
{
    class RegularUserRatingsValidator : IRatingsValidator
    {
        public ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["adId"]) ||
                string.IsNullOrWhiteSpace(valuePairs["rating"]) 
                ))
            {
                return new ValidationResult(false, "Column adId, rating should contain values");
            }

            if (!string.IsNullOrEmpty(valuePairs["favId"]))
            {
                return new ValidationResult(false, "favId Column should be empty");
            }

            return new ValidationResult(true, string.Empty);
        }

        public ValidationResult ValidateInputsForFindModelById(IDictionary<string, string> valuePairs)
        {
            throw new NotImplementedException();
        }

        public ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs)
        {
            throw new NotImplementedException();
        }
    }
}
