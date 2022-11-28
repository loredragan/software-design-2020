using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.Interfaces;

namespace Assignment1.DomainLayer.Models
{
    public class Employee : IModel
    {
        #region Properties
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructors
        public Employee() { }

        public Employee(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public Employee(int id, string username, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
        }
        #endregion
    }
}
