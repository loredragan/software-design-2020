using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Assignment_3.Models;

namespace Client
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
