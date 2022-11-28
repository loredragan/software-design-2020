using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.Models;

namespace Assignment1.PresentationLayer.Interfaces
{
    interface IDisplayWindowService
    {
        void DisplayMainWindow(Employee employee);

        void DisplayLoginWindow(string userType);

        void DisplaySelectUserWindow();

        void DisplayAdminWindow();
    }
}
