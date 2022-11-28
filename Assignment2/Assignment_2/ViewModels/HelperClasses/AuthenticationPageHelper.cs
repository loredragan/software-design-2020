using Assignment_2.ViewModel.Exceptions;
using Assignment_2.ViewModel.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.HelperClasses
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
