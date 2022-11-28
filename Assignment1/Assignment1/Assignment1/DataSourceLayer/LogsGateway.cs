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
    public class LogsGateway : IDataGateway
    {
        #region Properties
        public SqlConnection Connection { get; }
        #endregion

        #region Constructors
        public LogsGateway(string connectionString)
        {
            Connection = EstablishConnection(connectionString);
        }
        #endregion

        #region View Log Data
        public DataTable GetLogData()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForGetLogDataQuery();
            adapter.Fill(resultTable);

            return resultTable;
        }

        private SqlCommand GenerateCommandForGetLogDataQuery()
        {
            var query = "SELECT * FROM dbo.employeelogs;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;

            return command;
        }
        #endregion

        #region View Log Data By Id
        public DataTable GetLogDataByEmployeeId(int employeeId)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForFetLogsByEmployeeId(employeeId);
            adapter.Fill(resultTable);

            return resultTable;
        }

        private SqlCommand GenerateCommandForFetLogsByEmployeeId(int employeeId)
        {
            var query = "SELECT * FROM dbo.employeelogs WHERE idEmployee = @Employee;";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("Employee", employeeId);

            return command;
        }

        #endregion

        #region Insert Log Data

        public void InsertLogData(int employeeId, string transactionType, string transactionDate, string sourceTable)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var command = GenerateCommandForInsertLogData(employeeId, transactionType, transactionDate, sourceTable);

            command.ExecuteNonQuery();
        }

        private SqlCommand GenerateCommandForInsertLogData(int employeeId, string transactionType,
            string transactionDate, string sourceTable)
        {
            var query =
                "INSERT INTO dbo.employeelogs VALUES(@EmployeeId, @TransactionType, @TransactionDate, @SourceTable);";
            var command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@EmployeeId", employeeId);
            command.Parameters.AddWithValue("@TransactionType", transactionType);
            command.Parameters.AddWithValue("@TransactionDate", transactionDate);
            command.Parameters.AddWithValue("@SourceTable", sourceTable);

            return command;

        }
        #endregion

        #region View Reports Between Interval of time

        public DataTable GetLogsInInterval(int id,string fromDate, string toDate)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var adapter = new SqlDataAdapter();
            var resultTable = new DataTable();
            adapter.SelectCommand = GenerateCommandForGetLogsInInterval(id,fromDate, toDate);
            adapter.Fill(resultTable);

            return resultTable;

        }

        private SqlCommand GenerateCommandForGetLogsInInterval(int id, string fromDate, string toDate)
        {
            var query = "SELECT * FROM dbo.employeelogs WHERE idEmployee = @IdEmp AND transaction_date BETWEEN @From and @To;";
            var command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@From", fromDate);
            command.Parameters.AddWithValue("@To", toDate);
            command.Parameters.AddWithValue("@IdEmp", id);
            command.CommandType = CommandType.Text;

            return command;
        }

        #endregion

        public DataRow GetRow(int id)
        {
            string filter = $"id={id}";

            return GetLogData().Select(filter).FirstOrDefault();
        }

        public T GetColumn<T>(int id, string columnName)
        {
            throw new NotImplementedException();
        }

        public SqlConnection EstablishConnection(string connectionString) => new SqlConnection(connectionString);
    }
}
