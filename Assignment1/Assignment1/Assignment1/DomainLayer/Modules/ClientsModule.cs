using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DataSourceLayer;
using Assignment1.DataSourceLayer.Interfaces;
using Assignment1.DomainLayer.HelperClasses;
using Assignment1.DomainLayer.Interfaces;
using Assignment1.DomainLayer.Models;

namespace Assignment1.DomainLayer.Modules
{

    class ClientsModule : IBaseModule
    {
        #region Properties
        private ClientGateway Gateway { get; }
        public IEnumerable<Client> ClientsDataSet { get; set; }
        #endregion

        #region Constructors
        public ClientsModule(string connectionString)
        {
            Gateway = new ClientGateway(connectionString);
        }
        #endregion

        public IEnumerable<Client> GetClients() => ContextCreator.CreateClientsContext(Gateway.GetClientData());

        public IEnumerable<Client> GetClientById(int id) => ContextCreator.CreateClientsContext(Gateway.GetClientDataById(id));

        public void InsertClientData(Client newClient) => Gateway.InsertClientData(newClient.Cnp, newClient.Age, newClient.Name, newClient.Address);

        public void UpdateClientData(Client updatedClient) =>Gateway.UpdateClientData(updatedClient.IdCard, updatedClient.Cnp, updatedClient.Age, updatedClient.Name, updatedClient.Address);
    }
}
