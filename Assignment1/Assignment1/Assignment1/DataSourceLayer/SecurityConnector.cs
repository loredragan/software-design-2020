using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DataSourceLayer.Interfaces;
using Assignment1.Exceptions;

namespace Assignment1
{
    class SecurityConnector : ISecurityConnector
    {
        #region Properties
        public SqlConnection Connection;
        #endregion

        #region Constructors
        public SecurityConnector(string connectionString)
        {
            this.Connection = new SqlConnection(connectionString);
        }
        #endregion

        #region Login Methods
        public void EstablishLoginConnection(string username, string password, string userType)
        {
            try
            {
                ExecuteSelectDbQuery(username, password, userType);
            }
            catch (Exception ex)
            {
                throw new DbAuthenticationException(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public void ExecuteSelectDbQuery(string username, string password, string userType)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var queryResults = Convert.ToInt32(GenerateCommandForSelectDbQuery(username, password, userType).ExecuteScalar());
            if (queryResults != 1)
            {
                throw new DbAuthenticationException("Invalid username or password");
            }
        }

        private SqlCommand GenerateCommandForSelectDbQuery(string username, string password, string userType)
        {
            var query = string.Empty;

            query = userType.Equals("users", StringComparison.InvariantCultureIgnoreCase) ? "SELECT COUNT(1) FROM dbo.users WHERE username=@Username AND password=@Password" : "SELECT COUNT(1) FROM dbo.admins WHERE username=@Username AND password=@Password";

            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            return command;
        }
        #endregion

        #region Register Methods
        public void EstablishRegisterConnection(string newUsername, string newPassword, string userType)
        {
            try
            {
                ExecuteInsertDbQuery(newUsername, newPassword, userType);
            }
            catch (DbException ex)
            {
                throw new DbAuthenticationException(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public void ExecuteInsertDbQuery(string username, string password, string userType)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var checkIfUserExistsResult = Convert.ToInt32(CheckIfNewUsernameAlreadyExists(username, userType, Connection).ExecuteScalar());
            if (checkIfUserExistsResult != 0)
            {
                throw new DbAuthenticationException("Username already exists");
            }

            var queryResult = Convert.ToInt32(GenerateCommandForInsertDbQuery(username, password, userType).ExecuteNonQuery());
            if (queryResult != 1)
            {
                throw new DbAuthenticationException("Register failed");
            }
        }

        public SqlCommand GenerateCommandForInsertDbQuery(string username, string password, string userType)
        {
            var query = String.Empty;
            query = userType.Equals("users", StringComparison.InvariantCultureIgnoreCase) ? $"INSERT INTO dbo.users(username,password) VALUES ('{username}','{password}')" : $"INSERT INTO dbo.admins(username,password) VALUES ('{username}','{password}')";

            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;

            return command;
        }

        public SqlCommand CheckIfNewUsernameAlreadyExists(string username, string userType, SqlConnection connection)
        {
            var checkIfUsernameIsTakenQuery = String.Empty;
            checkIfUsernameIsTakenQuery = userType.Equals("users", StringComparison.InvariantCultureIgnoreCase) ? "SELECT COUNT(1) FROM dbo.users WHERE username=@Username" : "SELECT COUNT(1) FROM dbo.admins WHERE username=@Username";
           
            var command = new SqlCommand(checkIfUsernameIsTakenQuery, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Username", username);

            return command;
        }

        #endregion
    }
}
