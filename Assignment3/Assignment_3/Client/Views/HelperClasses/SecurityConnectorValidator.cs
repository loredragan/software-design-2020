using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels.HelperClasses;

namespace Client.Views.HelperClasses
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
