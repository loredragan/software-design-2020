using Assignment_2.Models;

namespace Assignment_2.View.Interfaces
{
    interface IDisplayWindowService
    {
        void DisplaySelectUserWindow(); //mainWindow holds select user page

        void DisplayAuthenticationWindow(string userType);

        void DisplayUserWindow(User model);

        void DisplayAdminWindow(Admin model);
    }
}
