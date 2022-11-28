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
    class ClientGateway : IDataGateway
    {
        #region Properties
        public SqlConnection Connection { get; }
        #endregion

        #region Constructors
        public ClientGateway(string connectionString)
        {
            Connection = EstablishConnection(connectionString);
        }
        #endregion

        #region View Client Data
        public DataTable GetClientData()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForGetClientDataQuery();
            adapter.Fill(resultTable);

            return resultTable;
        }

        private SqlCommand GenerateCommandForGetClientDataQuery()
        {
            var query = "SELECT * FROM dbo.clientsinfo;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;

            return command;
        }
        #endregion

        #region View Client Data By Id
        
        public DataTable GetClientDataById(int idCard)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForGetClientDataByIdQuery(idCard);
            adapter.Fill(resultTable);

            return resultTable;
        }

        private SqlCommand GenerateCommandForGetClientDataByIdQuery(int idCard)
        {
            var query = "SELECT * FROM dbo.clientsinfo WHERE idcard = @IdCard;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@IdCard", idCard);

            return command;
        }
        #endregion

        #region Insert New Client Data
        public void InsertClientData(long cnp, int age, string name, string address)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var command = GenerateCommandForInsertClientDataQuery(cnp, age, name, address);

            command.ExecuteNonQuery();
        }

        private SqlCommand GenerateCommandForInsertClientDataQuery(long cnp, int age,
            string name, string address)
        {
            var query = "INSERT INTO dbo.clientsinfo VALUES (@Name, @Cnp, @Age, @Address);";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Cnp", cnp);
            command.Parameters.AddWithValue("@Age", age);
            command.Parameters.AddWithValue("@Address", address);

            return command;
        }
        #endregion

        #region UpdateClientData

        public void UpdateClientData(int idCard, long cnp, int age,
            string name, string address)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var command = GenerateCommandForUpdateClientDataQuery(idCard, cnp, age, name, address);

            command.ExecuteNonQuery();
        }

        private SqlCommand GenerateCommandForUpdateClientDataQuery(int idCard, long cnp, int age,
            string name, string address)
        {
            var query = "UPDATE dbo.clientsinfo SET cnp = @Cnp, age = @Age, name = @Name, adress=@Address WHERE idcard = @IdCard;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Cnp", cnp);
            command.Parameters.AddWithValue("@Age", age);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@IdCard", idCard);

            return command;
        }
        #endregion

        public DataRow GetRow(int id)
        {
            string filter = $"idcard={id}";

            return GetClientData().Select(filter).FirstOrDefault();
        }

        public T GetColumn<T>(int id, string columnName)
        {
            return (T) GetRow(id)[columnName];
        }

        public SqlConnection EstablishConnection(string connectionString) => new SqlConnection(connectionString);
    }
}
