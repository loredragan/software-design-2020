using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.Modules;
using Assignment1.Exceptions;

namespace Assignment1.PresentationLayer.HelperClasses
{
    class RegisterHelperClass
    {
        private readonly ConnectionModule _connectionModule;

        public RegisterHelperClass(string connectionString) => this._connectionModule = new ConnectionModule(connectionString);

        public void Register(ValidationResult result, string username, string password)
        {
            AuthenticationPageHelper.CheckIfInputCredentialsAreValid(result);

            try
            {
                _connectionModule.RegisterUser(username, password, "users");
            }
            catch (DbAuthenticationException ex)
            {
                throw new FailedAuthenticationConnectionException(ex.Message);
            }

        }
    }
}
