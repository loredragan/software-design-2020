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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.Views.HelperClasses;
using Client.Views.Interfaces;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for SelectUserTypePage.xaml
    /// </summary>
    public partial class SelectUserTypePage : Page
    {
        #region Properties
        private Lazy<AuthenticationWindow> _authenticationWindow { get; }
        private IDisplayWindowService _displayWindowService { get; }
        private Command DisplayAuthenticationWindowCommand { get; set; }
        public string UserType { get; set; }
        #endregion

        #region Constructors
        public SelectUserTypePage()
        {
            InitializeComponent();
            _displayWindowService = new WPFDisplayWindowService();
            _authenticationWindow = new Lazy<AuthenticationWindow>(BuildAuthenticationWindow);
        }
        #endregion

        private void BtnRegUser_Click(object sender, RoutedEventArgs e)
        {
            UserType = "users";
            DisplayAuthenticationWindowCommand = new Command(() => _displayWindowService.DisplayAuthenticationWindow(UserType));
            DisplayAuthenticationWindowCommand.ExecuteCommand();

            Window.GetWindow(this).Close();
        }

        private void BtnAdminUser_Click(object sender, RoutedEventArgs e)
        {
            UserType = "admins";
            DisplayAuthenticationWindowCommand = new Command(() => _displayWindowService.DisplayAuthenticationWindow(UserType));
            DisplayAuthenticationWindowCommand.ExecuteCommand();

            Window.GetWindow(this).Close();
        }

        private AuthenticationWindow BuildAuthenticationWindow() => new AuthenticationWindow(UserType);
    }
}
