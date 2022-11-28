using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3;
using Assignment_3.Models;
using Client.ViewModels.Connection;
using Client.ViewModels.Interfaces;

namespace Client.ViewModels.HelperClasses
{
    class SecurityConnector: ISecurityConnector
    {
        public BaseModel AuthenticateUsers(string username, string password, string userType)
        {
            var asDict = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };
            return  (BaseModel)ConnectionHelper.SendRequest(asDict, 0, "AuthenticateUser", userType);
        }
    }
}

