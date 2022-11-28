using Client.ViewModels.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.AuthenticateUser
{
    class AuthenticationPageHelper
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
