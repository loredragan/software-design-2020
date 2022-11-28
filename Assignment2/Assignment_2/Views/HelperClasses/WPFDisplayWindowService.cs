using Assignment_2.Models;
using Assignment_2.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.View.HelperClasses
{
    class WPFDisplayWindowService : IDisplayWindowService
    {
        public void DisplayAdminWindow(Admin admin)
        {
            var openWindow = new AdminsMenuWindow(admin);
            openWindow.Show();
        }

        public void DisplayUserWindow(User user)
        {
            var openWindow = new UsersMenuWindow(user);
            openWindow.Show();
        }

        public void DisplayAuthenticationWindow(string userType)
        {
            var openWindow = new AuthenticationWindow(userType);
            openWindow.Show();
        }

        public void DisplaySelectUserWindow()
        {
            var openWindow = new MainWindow();
            openWindow.Show();
        }
    }
}
