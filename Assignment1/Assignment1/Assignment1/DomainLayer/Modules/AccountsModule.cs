using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DataSourceLayer;
using Assignment1.DomainLayer.HelperClasses;
using Assignment1.DomainLayer.Interfaces;
using Assignment1.DomainLayer.Models;

namespace Assignment1.DomainLayer.Modules
{
    class AccountsModule: IBaseModule
    {
        #region Properties
        private AccountGateway Gateway { get; }
        #endregion

        #region Constructors
        public AccountsModule(string connectionString)
        {
            this.Gateway = new AccountGateway(connectionString);
        }
        #endregion

        public IEnumerable<Account> GetAccounts() => ContextCreator.CreateAccountsContext(Gateway.GetAccountsData());

        public IEnumerable<Account> GetAccountById(int id) => ContextCreator.CreateAccountsContext(Gateway.GetAccountsDataById(id));

        public void InsertNewAccountForClient(Account account) => Gateway.InsertAccountForClientGivenById(account.ClientId , account.Type, account.CreationDate, account.Amount);

        public void UpdateAccountByAccountId(int id, Account account) => Gateway.UpdateAccountDataForClientGivenById(id, account.Type, account.CreationDate, account.Amount);

        public void UpdateAccountInTransaction(int accountId, double amount) => Gateway.UpdateAmountForTransactionMethods(accountId, amount);

        public IEnumerable<Account> GetAccountsByClientId(int clientId) => ContextCreator.CreateAccountsContext(Gateway.GetAccountsDataByClientId(clientId));

        public void DeleteAccountById(int id) => Gateway.DeleteAccountById(id);
    }
}
