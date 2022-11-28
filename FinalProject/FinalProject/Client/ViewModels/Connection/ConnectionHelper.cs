using FinalProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.Connection
{
    public class ConnectionHelper
    {
        public static Socket ServerSocket { get; set; }

        public static object SendRequest(IDictionary<string, string> valuePairs, int userId, string requestType,
            string content)
        {
            var message = new Message
            {
                Content = content,
                UserId = userId,
                ValuePairs = valuePairs,
                RequestType = requestType
            };
            var stream = Serializer.ToStream(message);
            ServerSocket.Send(stream.GetBuffer());

            var buffer = new byte[16384];
            var bytesReceived = ServerSocket.Receive(buffer);
            if (bytesReceived != 0)
            {
                var receivedMessage = Serializer.FromStream(new MemoryStream(buffer));
                return receivedMessage;
            }
            return null;
        }
    }
}
