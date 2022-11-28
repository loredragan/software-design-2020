using Client.Views.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views.HelperClasses
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
