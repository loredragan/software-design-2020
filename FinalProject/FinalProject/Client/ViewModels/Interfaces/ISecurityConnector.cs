using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.Interfaces
{
    public interface ISecurityConnector
    {
        BaseModel AuthenticateUsers(string username, string password, string userType);
    }
}
