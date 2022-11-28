using Assignment_2.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.View.HelperClasses
{
    class DisplayWindowService : IDisplayWindowService
    {
        public void DisplayAdminWindow()
        {
            throw new NotImplementedException();
        }

        public void DisplayAuthenticationWindow(string userType)
        {
            var openWindow = new AuthenticationWindow(userType);
            openWindow.Show();
        }

        public void DisplaySelectUserWindow()
        {
            throw new NotImplementedException();
        }

        public void DisplayUserWindow()
        {
            throw new NotImplementedException();
        }
    }
}
