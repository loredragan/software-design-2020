using Assignment_2.Model;
using Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModel.Interfaces
{
    interface ISecurityConnector
    {
        BaseModel AuthenticateUsers(string username, string password, string userType);
    }
}
