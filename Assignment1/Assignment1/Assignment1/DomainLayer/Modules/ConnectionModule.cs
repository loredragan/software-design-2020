using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DataSourceLayer.Interfaces;
using Assignment1.DomainLayer.Interfaces;

namespace Assignment1.DomainLayer.Modules
{
    public class ConnectionModule : IBaseModule
    {
        #region Properties
        private readonly ISecurityConnector _connector;
        #endregion

        #region Constructors
        public ConnectionModule(string connectionString) => this._connector = new SecurityConnector(connectionString);
        #endregion

        public void AuthenticateUser(string username, string password, string userType) => _connector.EstablishLoginConnection(username, password, userType);

        public void RegisterUser(string username, string password, string userType) => _connector.EstablishRegisterConnection(username, password, userType);
    }
}
