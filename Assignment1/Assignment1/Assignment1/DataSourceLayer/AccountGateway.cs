using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DataSourceLayer.Interfaces;

namespace Assignment1.DataSourceLayer
{
    //contul: id, type, amount, creation_date, clientID

    public class AccountGateway : IDataGateway
    {
        #region Properties
        public SqlConnection Connection { get; }
        #endregion

        #region Constructor
        public AccountGateway(string connectionString)
        {
            this.Connection = EstablishConnection(connectionString);
        }
        #endregion

        #region View ClientsAccounts Data

        public DataTable GetAccountsData()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForGetAccountsDataQuery();
            adapter.Fill(resultTable);

            return resultTable;
        }

        private SqlCommand GenerateCommandForGetAccountsDataQuery()
        {
            var query = "SELECT * FROM dbo.clientsaccounts2;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;

            return command;
        }
        #endregion

        #region View Accounts By Accounts ID

        public DataTable GetAccountsDataById(int id)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForGetAccountsDataByIdQuery(id);
            adapter.Fill(resultTable);

            return resultTable;
        }

        private SqlCommand GenerateCommandForGetAccountsDataByIdQuery(int id)
        {
            var query = "SELECT * FROM dbo.clientsaccounts2 WHERE id = @Id;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Id", id);

            return command;
        }
        #endregion

        #region View Accounts for A Client
        public DataTable GetAccountsDataByClientId(int clientId)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForGetAccountsDataByClientIdQuery(clientId);
            adapter.Fill(resultTable);

            return resultTable;
        }

        private SqlCommand GenerateCommandForGetAccountsDataByClientIdQuery(int clientId)
        {
            var query = "SELECT * FROM dbo.clientsaccounts2 WHERE clientID = @Id;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Id", clientId);

            return command;
        }
        #endregion

        #region Insert New Account For Client Given By Id
        public void InsertAccountForClientGivenById(int clientId, string type,
            string creationDate, double amount)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
            var command =
                GenerateCommandForInsertAccountFoClientGivenByIdQuery(clientId, type, creationDate, amount);

            command.ExecuteNonQuery();

        }

        private SqlCommand GenerateCommandForInsertAccountFoClientGivenByIdQuery(int clientId,
            string type, string creationDate, double amount)
        {
            var query = "INSERT INTO dbo.clientsaccounts2 VALUES(@Type, @Amount, @CreationDate, @ClientId);";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Type", type);
            command.Parameters.AddWithValue("@Amount", amount);
            command.Parameters.AddWithValue("@CreationDate", creationDate);
            command.Parameters.AddWithValue("@ClientId", clientId);

            return command;

        }
        #endregion

        #region Update Acount Data

        public void UpdateAccountDataForClientGivenById(int accountId, string type,
            string creationDate, double amount)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var command =
                GenerateCommandForUpdateAccountForClientQuery(accountId, type, creationDate, amount);

            command.ExecuteNonQuery();
        }

        private SqlCommand GenerateCommandForUpdateAccountForClientQuery(int id,
            string type,
            string creationDate, double amount)
        {
            var query =
                "UPDATE dbo.clientsaccounts2 SET type = @Type, creation_date = @CreationDate,  amount = @Amount WHERE id=@Id;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Type", type);
            command.Parameters.AddWithValue("@CreationDate", creationDate);
            command.Parameters.AddWithValue("@Amount", amount);
            command.Parameters.AddWithValue("@Id", id);

            return command;
        }
        #endregion

        #region Delete Account
        public void DeleteAccountById(int accountId)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var command = GenerateCommandForDeleteAccountById(accountId);

            command.ExecuteNonQuery();
        }

        private SqlCommand GenerateCommandForDeleteAccountById(int id)
        {
            var query = "DELETE FROM dbo.clientsaccounts2 WHERE id = @Id;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@Id", id);

            return command;
        }
        #endregion

        #region Update Amount In Transaction Methods

        public void UpdateAmountForTransactionMethods(int accountId, double amount)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var command = GenerateCommandForUpdateAmmountForTransactionQuery(accountId, amount);

            command.ExecuteNonQuery();
        }

        private SqlCommand GenerateCommandForUpdateAmmountForTransactionQuery(int accountId, double amount)
        {
            var query =
                "UPDATE dbo.clientsaccounts2 SET amount = @Amount WHERE id=@Id;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Amount", amount);
            command.Parameters.AddWithValue("@Id", accountId);

            return command;
        }
        #endregion

        public SqlConnection EstablishConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public DataRow GetRow(int id)
        {
            var filter = $"id={id}";
            return GetAccountsData().Select(filter).FirstOrDefault();
        }

        public T GetColumn<T>(int id, string columnName)
        {
            return (T) GetRow(id)[columnName];
        }
    }
}
