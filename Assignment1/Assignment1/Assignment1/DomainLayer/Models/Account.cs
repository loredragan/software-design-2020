using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.Interfaces;

namespace Assignment1.DomainLayer.Models
{
    public class Account : IModel
    {
        #region Properties
        public int Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string CreationDate { get; set; }
        public int ClientId { get; set; }
        #endregion

        #region Constructors
        public Account() { }

        public Account(string type, double amount, string dateTime, int clientID)
        {
            this.Type = type;
            this.Amount = amount;
            this.CreationDate = dateTime;
            this.ClientId = clientID;
        }

        public Account(int id, string type, double amount, string dateTime, int clientID)
        {
            this.Type = type;
            this.Amount = amount;
            this.CreationDate = dateTime;
            this.ClientId = clientID;
            this.Id = id;
        }
        #endregion

        public void AddAmount(double amount) => this.Amount = amount;

        public void SubstractAmount(double amount) => this.Amount -= amount;
    }
}
