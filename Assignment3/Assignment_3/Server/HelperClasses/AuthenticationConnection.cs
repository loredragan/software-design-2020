using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3;
using Assignment_3.Models;
using Server.RequestHandler;

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
