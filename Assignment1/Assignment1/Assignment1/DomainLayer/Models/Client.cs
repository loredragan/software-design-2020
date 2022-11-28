using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.Interfaces;

namespace Assignment1.DomainLayer.Models
{
    public class Client : IModel
    {
        #region Properties
        public int IdCard { get; set; }
        public long Cnp { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        #endregion

        #region Constructors
        public Client() { }

        public Client(long cnp, int age, string name, string address)
        {
            this.Cnp = cnp;
            this.Age = age;
            this.Name = name;
            this.Address = address;
        }

        public Client(int idCard, long cnp, int age, string name, string address)
        {
            this.Cnp = cnp;
            this.Age = age;
            this.Name = name;
            this.Address = address;
            this.IdCard = idCard;
        }
        #endregion
    }
}
