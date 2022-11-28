using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.Models;

namespace Assignment1.DomainLayer.HelperClasses
{
    public class ContextCreator
    {
        public static  IEnumerable<Client> CreateClientsContext(DataTable dataTable)
        {
            var convertedClients = (from rw in dataTable.AsEnumerable()
                select new Client()
                {
                    IdCard = Convert.ToInt32(rw["idcard"]),
                    Name = Convert.ToString(rw["name"]),
                    Cnp = Convert.ToInt64(rw["cnp"]),
                    Age = Convert.ToInt32(rw["age"]),
                    Address = Convert.ToString(rw["adress"])
                }).AsEnumerable();

            return convertedClients;
        }

        public static  IEnumerable<Account> CreateAccountsContext(DataTable dataTable)
        {
            var convertedAccounts = (from rw in dataTable.AsEnumerable()
                select new Account()
                {
                   Id = Convert.ToInt32(rw["id"]),
                   Type = Convert.ToString(rw["type"]),
                   Amount = Convert.ToDouble(rw["amount"]),
                    //CreationDate = Convert.ToDateTime(rw["creation_date"]),
                    CreationDate = Convert.ToString(rw["creation_date"]),
                    ClientId = Convert.ToInt32(rw["clientID"])
                }).AsEnumerable();

            return convertedAccounts;
        }

        public static IEnumerable<Employee> CreateEmployeesContext(DataTable dataTable)
        {
            var convertedEmployees = (from rw in dataTable.AsEnumerable()
                select new Employee()
                {
                    Id = Convert.ToInt32(rw["id"]),
                    Username = Convert.ToString(rw["username"]),
                    Password = Convert.ToString(rw["password"])
                }).AsEnumerable();

            return convertedEmployees;
        }

        public static IEnumerable<Log> CreateLogsContext(DataTable dataTable)
        {
            var convertedLogs = (from rw in dataTable.AsEnumerable()
                select new Log()
                {
                    Id = Convert.ToInt32(rw["id"]),
                    IdEmployee = Convert.ToInt32(rw["idEmployee"]),
                    TransactionType = Convert.ToString(rw["transaction_type"]),
                    TransactionDate = Convert.ToString(rw["transaction_date"]),
                    SourceTable = Convert.ToString(rw["source_table"])
                }).AsEnumerable();

            return convertedLogs;
        }
    }
}
