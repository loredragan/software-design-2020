using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.DataSourceLayer.Interfaces
{
    public interface IDataGateway
    { 
        DataRow GetRow(int id);

        T GetColumn<T>(int id, string columnName);

        SqlConnection EstablishConnection(string connectionString);
    }
}
