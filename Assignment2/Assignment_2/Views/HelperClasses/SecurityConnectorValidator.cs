using Assignment_2.ViewModel.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Views.HelperClasses
{
    public static class SecurityConnectorValidator
    {
        public static ValidationResult CheckIfUsernameAndPasswordFieldsAreEmpty(string username, string password)
        {
            if ((string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)))
                return new ValidationResult(false, "Insert your username and password!");
            return new ValidationResult(true, string.Empty);
        }
    }
}
