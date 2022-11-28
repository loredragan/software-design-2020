using Client.ViewModels.Connection;
using Client.ViewModels.Exceptions;
using Client.ViewModels.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses
{
    class SecurityConnector : ISecurityConnector
    {
        public BaseModel AuthenticateUsers(string username, string password, string userType)
        {
            var asDict = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            BaseModel result;
            try
            {
                result = (BaseModel)ConnectionHelper.SendRequest(asDict, 0, "AuthenticateUser", userType);
            }
            catch (Exception)
            {
                throw new FailedAuthenticationException((string)ConnectionHelper.SendRequest(asDict, 0, "AuthenticateUser", userType));
            }
            return result;
        }
    }
}
