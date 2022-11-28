using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels.Exceptions;

namespace Client.ViewModels.HelperClasses
{
    static class AuthenticationPageHelper
    {
        public static void CheckIfInputCredentialsAreValid(ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                throw new FailedAuthenticationException(validationResult.ValidationResultMessage);
            }
        }
    }
}
