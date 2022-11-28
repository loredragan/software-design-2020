using FinalProject;
using FinalProject.Models;
using Server.RequestHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.HelperClasses
{
    static class AuthenticationConnection
    {
        public static BaseModel HandleLoginRequest(AuthenticationHandler helper, Message received)
        {
            return helper.AuthenticateUser(received.ValuePairs, received.Content);
        }
    }
}
