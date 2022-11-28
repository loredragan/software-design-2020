using FinalProject;
using FinalProject.Models;
using Server.RequestHandler.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.HelperClasses.Users
{
    class RegularUserChatsConnection
    {
        public static IEnumerable<BaseModel> HandleReadRequests(RegularUserChatsHandler helper, Message received)
        {
            if (received.Content.Equals("GetInbox", StringComparison.InvariantCultureIgnoreCase))
            {
                return helper.GetInbox(received.ValuePairs, received.UserId);
            }

            return null;
        }

        public static void HandleCommandRequests(RegularUserChatsHandler helper, Message received)
        {
            if (received.Content.Equals("SendMessage", StringComparison.InvariantCultureIgnoreCase))
            {
                helper.SendMessage(received.ValuePairs, received.UserId);
            }
        }
    }
}
