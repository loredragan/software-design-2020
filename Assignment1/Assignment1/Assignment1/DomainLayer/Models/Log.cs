using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.Interfaces;

namespace Assignment1.DomainLayer.Models
{
    public class Log : IModel
    {
        #region Properties
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public string TransactionType { get; set; }
        //public DateTime CreationDate { get; set; }
        public string TransactionDate { get; set; }
        public string SourceTable{ get; set; }
        #endregion

        #region Constructors
        public Log()
        {
        }

        public Log(int idEmployee, string transactionType, string transactionDate, string sourceTable)
        {
            this.IdEmployee = idEmployee;
            this.TransactionType = transactionType;
            this.TransactionDate = transactionDate;
            this.SourceTable = sourceTable;
        }
        #endregion
    }
}
