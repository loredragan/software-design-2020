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
    public class LogsModule: IBaseModule
    {
        #region Properties
        private LogsGateway Gateway { get; set; }
        public IEnumerable<Log> LogsDataSet { get; set; }
        #endregion

        #region Constructors
        public LogsModule(string connectionString)
        {
            Gateway = new LogsGateway(connectionString);
        }
        #endregion

        public IEnumerable<Log> GetLogsInInterval(int id, string fromDate, string toDate) =>
            ContextCreator.CreateLogsContext(Gateway.GetLogsInInterval(id, fromDate, toDate));

        public IEnumerable<Log> GetLogsByEmployeeId(int employeeId) =>
            ContextCreator.CreateLogsContext(Gateway.GetLogDataByEmployeeId(employeeId));
    
        public IEnumerable<Log> GetLogs() => ContextCreator.CreateLogsContext(Gateway.GetLogData());

        public void InsertLog(Log newLog) => Gateway.InsertLogData(newLog.IdEmployee, newLog.TransactionType,
            newLog.TransactionDate, newLog.SourceTable);
    }
}
