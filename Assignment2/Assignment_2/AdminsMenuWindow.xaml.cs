using Assignment_2.Models;
using System.Windows;

namespace Assignment_2
{
    /// <summary>
    /// Interaction logic for AdminsMenuWindow.xaml
    /// </summary>
    public partial class AdminsMenuWindow : Window
    {
        #region Properties
        public Admin AuthenticatedAdmin;
        #endregion

        #region Constructors
        public AdminsMenuWindow(Admin admin)
        {
            AuthenticatedAdmin = admin;
            InitializeComponent();
        }
        #endregion
    }
}
