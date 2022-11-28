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
