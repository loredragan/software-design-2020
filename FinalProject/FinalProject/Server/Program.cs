using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Dns.GetHostEntry("localhost");
            var ipAddress = host.AddressList[0];
            var localEndPoint = new IPEndPoint(ipAddress, 9000);
            var serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(localEndPoint);
            serverSocket.Listen(10);

            while (true)
            {
                var clientSocket = serverSocket.Accept();
                var connection = new Connection(clientSocket);
            }
        }
    }
}
