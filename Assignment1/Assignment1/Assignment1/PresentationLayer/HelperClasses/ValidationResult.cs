using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.PresentationLayer.HelperClasses
{
    public struct  ValidationResult
    {
        #region Properties
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
