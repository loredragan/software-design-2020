using Client.ViewModels.Connection;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.RegularUserChats
{
    class RegularUserChatsHelper
    {
        public static void SendMessage(IDictionary<string, string> valuePairs, int user)
        {
            
            var result = (string)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserChatsCommand", "SendMessage");
            if (!result.Equals(string.Empty))
                throw new Exception((string)result);
        }

        public static IEnumerable<ChatMessage> GetInbox(IDictionary<string, string> valuePairs, int user)
        {
            IEnumerable<ChatMessage> result;

            try
            {
                result = (IEnumerable<ChatMessage>)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserChatsRead",
                "GetInbox");
            }
            catch (Exception)
            {
                throw new Exception((string)ConnectionHelper.SendRequest(valuePairs, user, "RegularUserChatsRead",
                "GetInbox"));
            }

            return result;
        }
    }
}
