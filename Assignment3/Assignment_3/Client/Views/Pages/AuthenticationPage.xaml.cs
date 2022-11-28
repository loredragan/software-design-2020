using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Assignment_3.Models;
using Client.ViewModels.Exceptions;
using Client.ViewModels.ViewModels;
using Client.Views.HelperClasses;
using Client.Views.Interfaces;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for AuthenticationPage.xaml
    /// </summary>
    public partial class AuthenticationPage : Page
    {
        #region Properties

        private AuthenticationViewModel _authenticationViewModel;
        private IDisplayWindowService _displayWindowService;
        private IMessageBoxService _messageBoxService;
        public Lazy<AdminsMenuWindow> AdminsMenuWindow { get; set; }
        public Lazy<UsersMenuWindow> UsersMenuWindow { get; set; }
        private BaseModel _isAuthenticated { get; set; }
        public string UserType { get; set; }
        #endregion

        #region Constructors

        public AuthenticationPage()
        {
            InitializeComponent();
            _displayWindowService = new WPFDisplayWindowService();
            _messageBoxService = new WPFMessageBoxService();
            AdminsMenuWindow = new Lazy<AdminsMenuWindow>(BuildAdminsMenuWindow);
            UsersMenuWindow = new Lazy<UsersMenuWindow>(BuildUsersMenuWindow);
        }

        #endregion

        public void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var wndLogin = Window.GetWindow(this) as AuthenticationWindow;
                UserType = wndLogin.UserType;
                _authenticationViewModel =
                    new AuthenticationViewModel(_messageBoxService, _displayWindowService, UserType);

                try
                {
                    var username = txtUsername.Text;
                    var password = txtPassword.Password;

                    _authenticationViewModel.Login(SecurityConnectorValidator.CheckIfUsernameAndPasswordFieldsAreEmpty(username, password), username, password, UserType);
                    Window.GetWindow(this).Close();
                }
                catch (FailedAuthenticationException ex)
                {
                    _authenticationViewModel.ShowMessageWindow(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private AdminsMenuWindow BuildAdminsMenuWindow() => new AdminsMenuWindow(_isAuthenticated as Admin);
        private UsersMenuWindow BuildUsersMenuWindow() => new UsersMenuWindow(_isAuthenticated as User);

    }
}
