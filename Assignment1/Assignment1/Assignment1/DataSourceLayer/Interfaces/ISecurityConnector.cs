using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.DataSourceLayer.Interfaces
{
    public interface ISecurityConnector
    {
        void EstablishLoginConnection(string username, string password, string userType);

        void EstablishRegisterConnection(string newUsername, string newPassword, string userType);
    }
}
