using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views.Interfaces
{
    interface IDisplayWindowService
    {
        void DisplaySelectUserWindow(); //mainWindow holds select user page

        void DisplayAuthenticationWindow(string userType);

        void DisplayUserWindow(User model);

        void DisplayAdminWindow(Admin model);
    }
}
