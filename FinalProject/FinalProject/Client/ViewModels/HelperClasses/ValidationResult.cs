using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses
{
    public class ValidationResult
    {
        #region Exposed Members
        public bool IsValid;
        public string ValidationResultMessage;
        #endregion

        #region Constructors
        public ValidationResult(bool isValid, string validationResultMessage)
        {
            this.IsValid = isValid;
            this.ValidationResultMessage = validationResultMessage;
        }
        #endregion
    }
}
