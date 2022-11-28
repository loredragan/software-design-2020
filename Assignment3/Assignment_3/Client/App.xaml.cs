using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using Client.ViewModels.Connection;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //here I take controll;
            var host = Dns.GetHostEntry("localhost");
            var ipAddress = host.AddressList.First();
            var serverEndpoint = new IPEndPoint(ipAddress, 9000);

            Socket serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Connect(serverEndpoint);

            //while (true)
            //{
                ConnectionHelper.ServerSocket = serverSocket;
            //}

        }
    }
}
