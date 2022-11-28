using Assignment_2.Models;
using System.Windows;

namespace Assignment_2
{
    /// <summary>
    /// Interaction logic for UsersMenuWindow.xaml
    /// </summary>
    public partial class UsersMenuWindow : Window
    {
        #region Properties
        public User AuthenticatedUser;
        #endregion

        #region Constructors
        public UsersMenuWindow(User user)
        {
            AuthenticatedUser = user;
            InitializeComponent();
        }
        #endregion
    }
}
