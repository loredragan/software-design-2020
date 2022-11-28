using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.Models;
using Assignment1.DomainLayer.Modules;

namespace Assignment1.PresentationLayer.HelperClasses
{
    static class AuthenticationPageHelper
    {
        public static void CheckIfInputCredentialsAreValid(ValidationResult validationResult)
        {
            if (validationResult.IsValid) return;
            var errorMessage = validationResult.ValidationResultMessage;
            throw new FailedAuthenticationConnectionException(errorMessage);
        }
	}
}
