using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DataSourceLayer.Interfaces;
using Assignment1.Exceptions;

namespace Assignment1.DataSourceLayer
{
    class EmployeeGateway : IDataGateway
    {
        #region Properties
        public SqlConnection Connection { get; }
        private SecurityConnector SecurityConnector { get; }
        #endregion

        #region Constructor
        public EmployeeGateway(string connectionString)
        {
            Connection = EstablishConnection(connectionString);
            SecurityConnector = new SecurityConnector(connectionString);
        }
        #endregion

        #region View Employee Data
        public DataTable GetEmployeeData()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForGetEmployeeDataQuery();
            adapter.Fill(resultTable);

            return resultTable;
        }

        public SqlCommand GenerateCommandForGetEmployeeDataQuery()
        {
            var query = "SELECT * FROM dbo.users;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;

            return command;
        }
        #endregion

        #region View Employee Data By Id
        public DataTable GetEmployeeDataById(int id)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForGetEmployeeDataById(id);
            adapter.Fill(resultTable);

            return resultTable;
        }

        private SqlCommand GenerateCommandForGetEmployeeDataById(int id)
        {
            var query = "SELECT * FROM dbo.users WHERE id = @Id;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Id", id);

            return command;
        }
        #endregion

        #region View Employee Data By Username
        public DataTable GetEmployeeDataByUsername(string username)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForGetEmployeeDataByUsername(username);
            adapter.Fill(resultTable);

            return resultTable;
        }

        private SqlCommand GenerateCommandForGetEmployeeDataByUsername(string username)
        {
            var query = "SELECT * FROM dbo.users WHERE username = @Username;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Username", username);

            return command;
        }
        #endregion

        #region Insert New Employee Data
        public void InsertEmployeeData(string username, string password)
        {
            SecurityConnector.EstablishRegisterConnection(username, password, "users");
        }
        #endregion

        #region Update Employee Data

        public void UpdateEmployeeData(int id, string username, string password)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var command = GenerateCommandForUpdateEmployeeData(id, username, password);

            command.ExecuteNonQuery();

        }


        public SqlCommand GenerateCommandForUpdateEmployeeData(int id, string username, string password)
        {
            var checkIfUserExists = Convert.ToInt32(SecurityConnector.CheckIfNewUsernameAlreadyExists(username, "users", Connection).ExecuteScalar());
            if (checkIfUserExists != 0)
            {
                throw new DbAuthenticationException("Username already exists");
            }

            var query = "UPDATE dbo.users SET username = @Username, password = @Password WHERE id = @Id;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@Id", id);

            return command;
        }
        #endregion

        #region Delete Employee By Id
        public void DeleteEmployeeById(int id)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var command = GenerateCommandForDeleteAccountById(id);

            command.ExecuteNonQuery();
        }

        private SqlCommand GenerateCommandForDeleteAccountById(int id)
        {
            var query = "DELETE FROM dbo.users WHERE id = @Id;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@Id", id);

            return command;
        }
        #endregion

        public DataRow GetRow(int id)
        {
            string filter = $"id={id}";

            return GetEmployeeData().Select(filter).FirstOrDefault();
        }

        public T GetColumn<T>(int id, string columnName)
        {
            throw new NotImplementedException();
        }

        public SqlConnection EstablishConnection(string connectionString) => new SqlConnection(connectionString);
    }
}
