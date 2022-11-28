using Assignment1.PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.Models;

namespace Assignment1.PresentationLayer.HelperClasses
{
    class WPFDisplayWindowService : IDisplayWindowService
    {
        public void DisplayMainWindow(Employee employee)
        {
            var openWindow = new MainWindow(employee);
            openWindow.Show();
        }

        public void DisplayLoginWindow(string userType)
        {
            var openWindow = new LoginWindow(userType);
            openWindow.Show();
        }

        public void DisplaySelectUserWindow()
        {
            var openWindow = new SelectUserWindow();
            openWindow.Show();
        }

        public void DisplayAdminWindow()
        {
            var openWindow = new AdminWindow();
            openWindow.Show();
        }
    }
}
