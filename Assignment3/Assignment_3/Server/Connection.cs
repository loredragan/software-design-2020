using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Assignment_3;
using Assignment_3.Models;
using Server.HelperClasses;
using Server.RequestHandler;
using Server.RequestHandler.Admins;
using Server.RequestHandler.Users;

namespace Server
{
    public class Connection
    {
        private readonly Socket _socket;
        public readonly RegularUserManageAdsHandler _regularUserManageAdsHandler;
        private readonly RegularUserSearchAdsHandler _regularUserSearchAdsHandler;
        private readonly AdminManageUsersAdsHandler _adminManageUsersAdsHandler;
        private readonly AdminManageUsersHandler _adminManageUsersHandler;
        private readonly AuthenticationHandler _authenticationHandler;

        public Connection(Socket socket)
        {
            this._socket = socket;
            this._regularUserSearchAdsHandler = new RegularUserSearchAdsHandler();
            this._adminManageUsersAdsHandler = new AdminManageUsersAdsHandler();
            this._adminManageUsersHandler = new AdminManageUsersHandler();
            this._regularUserManageAdsHandler = new RegularUserManageAdsHandler();
            this._authenticationHandler = new AuthenticationHandler();

            Console.WriteLine($"Connected to client: {_socket.RemoteEndPoint}");
            Task.Factory.StartNew(() => Execute(_socket));
        }

        private void Execute(Socket socket)
        {
            while (true)
            {
                var buffer = new byte[8192];
                var bytesCount = socket.Receive(buffer);
                object result = null;

                if (bytesCount != 0)
                {
                    var msgReceived = (Message) Serializer.FromStream(new MemoryStream(buffer));
                    //Console.WriteLine($"Received msg: {msgReceived.Content}");

                    
                    if (msgReceived.RequestType.Equals("RegularUserManageAdsRead"))
                    {
                       result = RegularUserManageAdsConnection.HandleReadRequests(_regularUserManageAdsHandler, msgReceived);
                    }
                    else if (msgReceived.RequestType.Equals("RegularUserManageAdsCommand"))
                    {
                        RegularUserManageAdsConnection.HandleCommandRequests(_regularUserManageAdsHandler, msgReceived);
                        result = true;
                    }
                    else if (msgReceived.RequestType.Equals("RegularUserSearchAds"))
                    {
                        result = RegularUserSearchAdsConnection.HandleReadRequests(_regularUserSearchAdsHandler, msgReceived);
                    }
                    else if (msgReceived.RequestType.Equals("AdminManageUsersRead"))
                    {
                        result = AdminManageUsersConnection.HandleReadRequests(_adminManageUsersHandler, msgReceived);
                    }
                    else if (msgReceived.RequestType.Equals("AdminsManageUsersCommand"))
                    {
                        AdminManageUsersConnection.HandleCommandRequests(_adminManageUsersHandler, msgReceived);
                        result = true;
                    }
                    else if (msgReceived.RequestType.Equals("AdminManageUsersAdsRead"))
                    {
                        result = AdminManageUsersAdsConnection.HandleReadRequests(_adminManageUsersAdsHandler, msgReceived);
                    }
                    else if (msgReceived.RequestType.Equals("AdminManageUsersAdsCommand"))
                    {
                        AdminManageUsersAdsConnection.HandleCommandRequests(_adminManageUsersAdsHandler, msgReceived);
                        result = true;
                    }
                    else if (msgReceived.RequestType.Equals("AuthenticateUser"))
                    {
                        result = AuthenticationConnection.HandleLoginRequest(_authenticationHandler, msgReceived);
                    }

                    if (result != null)
                    {
                        //var message = new Message { ResultData = result };
                        Console.WriteLine("Sent Request Result");
                        var stream = Serializer.ToStream(result);
                        //var byteSent = socket.Send(stream.GetBuffer());
                        socket.Send(stream.GetBuffer());
                    }
                }

                Thread.Sleep(500);
            }
        }

    }

}
