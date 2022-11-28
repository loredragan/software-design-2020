using Server.RequestHandler.Admins;
using Server.RequestHandler.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FinalProject;
using System.IO;
using Server.HelperClasses;
using Server.RequestHandler;
using Server.HelperClasses.Users;

namespace Server
{
    class Connection
    {
        private readonly Socket _socket;
        private readonly RegularUserManageAdsHandler _regularUserManageAdsHandler;
        private readonly RegularUserChatsHandler _regularUserChatsHandler;
        private readonly RegularUserAdsPersonalizationHandler _regularUserAdsPersonalizationHandler;
        private readonly RegularUserSearchAdsHandler _regularUserSearchAdsHandler;
        private readonly AdminManageRatingsHandler _adminManageRatingsHandler;
        private readonly AdminManageUsersAdsHandler _adminManageUsersAdsHandler;
        private readonly AdminManageUsersHandler _adminManageUsersHandler;
        private readonly AuthenticationHandler _authenticationHandler;
        public Connection(Socket socket)
        {
            _socket = socket;
            _regularUserAdsPersonalizationHandler = new RegularUserAdsPersonalizationHandler();
            _regularUserChatsHandler = new RegularUserChatsHandler();
            _regularUserManageAdsHandler = new RegularUserManageAdsHandler();
            _regularUserSearchAdsHandler = new RegularUserSearchAdsHandler();
            _adminManageRatingsHandler = new AdminManageRatingsHandler();
            _adminManageUsersAdsHandler = new AdminManageUsersAdsHandler();
            _adminManageUsersHandler = new AdminManageUsersHandler();
            _authenticationHandler = new AuthenticationHandler();

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
                    var msgReceived = (Message)Serializer.FromStream(new MemoryStream(buffer));

                    #region AdminManageRatingsHandler
                    if (msgReceived.RequestType.Equals("AdminManageRatingsRead"))
                    {
                        try
                        {
                            result = AdminManageRatingsConnection.HandleReadRequests(_adminManageRatingsHandler, msgReceived);

                        }catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    else if (msgReceived.RequestType.Equals("AdminManageRatingsCommand"))
                    {
                        try
                        {
                            AdminManageRatingsConnection.HandleCommandRequests(_adminManageRatingsHandler, msgReceived);
                            result = string.Empty;
                        }
                        catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                        
                    }
                    #endregion

                    #region AdminManageUsersAdsHandler
                    else if (msgReceived.RequestType.Equals("AdminManageUsersAdsRead"))
                    {
                        try
                        {
                            result = AdminManageUsersAdsConnection.HandleReadRequests(_adminManageUsersAdsHandler, msgReceived);

                        }
                        catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    else if (msgReceived.RequestType.Equals("AdminManageUsersAdsCommand"))
                    {
                        try
                        {
                            AdminManageUsersAdsConnection.HandleCommandRequests(_adminManageUsersAdsHandler, msgReceived);
                            result = string.Empty;
                        }
                        catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    #endregion

                    #region AdminManageUsersHandler
                    else if (msgReceived.RequestType.Equals("AdminManageUsersRead"))
                    {
                        try
                        {
                            result = AdminManageUsersConnection.HandleReadRequests(_adminManageUsersHandler, msgReceived);

                        }
                        catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    else if (msgReceived.RequestType.Equals("AdminManageUsersCommand"))
                    {
                        try
                        {
                            AdminManageUsersConnection.HandleCommandRequests(_adminManageUsersHandler, msgReceived);
                            result = string.Empty;

                        }catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    #endregion

                    #region RegularUserAdsPersonalizationHandler
                    else if (msgReceived.RequestType.Equals("RegularUserAdsPersonalizationRead"))
                    {
                        try
                        {
                            result = RegularUserAdsPersonalizationConnection.HandleReadRequests(_regularUserAdsPersonalizationHandler, msgReceived);

                        }
                        catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    else if (msgReceived.RequestType.Equals("RegularUserAdsPersonalizationCommand"))
                    {
                        try
                        {
                            RegularUserAdsPersonalizationConnection.HandleCommandRequests(_regularUserAdsPersonalizationHandler, msgReceived);
                            result = string.Empty;
                        }
                        catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    #endregion

                    #region RegularUserChatsHandler
                    else if (msgReceived.RequestType.Equals("RegularUserChatsRead"))
                    {
                        try
                        {
                            result = RegularUserChatsConnection.HandleReadRequests(_regularUserChatsHandler, msgReceived);

                        }
                        catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    else if (msgReceived.RequestType.Equals("RegularUserChatsCommand"))
                    {
                        try
                        {
                            RegularUserChatsConnection.HandleCommandRequests(_regularUserChatsHandler, msgReceived);
                            result = string.Empty;
                        }
                        catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    #endregion

                    #region RegularUserManageAdsHandler
                    else if (msgReceived.RequestType.Equals("RegularUserManageAdsRead"))
                    {
                        try
                        {
                            result = RegularUserManageAdsConnection.HandleReadRequests(_regularUserManageAdsHandler, msgReceived);
                        }catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    else if (msgReceived.RequestType.Equals("RegularUserManageAdsCommand"))
                    {
                        try
                        {
                            RegularUserManageAdsConnection.HandleCommandRequests(_regularUserManageAdsHandler, msgReceived);
                            result = string.Empty;
                        }catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                        
                    }
                    #endregion

                    #region RegularUserSearchAdsHandler
                    else if (msgReceived.RequestType.Equals("RegularUserSearchAds"))
                    {
                        try
                        {
                            result = RegularUserSearchAdsConnection.HandleReadRequests(_regularUserSearchAdsHandler, msgReceived);

                        }
                        catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }


                    #endregion

                    #region AuthenticateUser
                    else if (msgReceived.RequestType.Equals("AuthenticateUser"))
                    {
                        try
                        {
                            result = AuthenticationConnection.HandleLoginRequest(_authenticationHandler, msgReceived);

                        }
                        catch(Exception ex)
                        {
                            result = ex.Message;
                        }
                    }
                    #endregion

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
