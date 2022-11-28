using Assignment_2.Models;
using Assignment_2.View.HelperClasses;
using Assignment_2.View.Interfaces;
using Assignment_2.ViewModel.Exceptions;
using Assignment_2.ViewModel.ViewModels;
using Assignment_2.Views.HelperClasses;
using Assignment_2.Views.Interfaces;
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

namespace Assignment_2.View.Pages
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
            var wndLogin = Window.GetWindow(this) as AuthenticationWindow;
            UserType = wndLogin.UserType;
            _authenticationViewModel = new AuthenticationViewModel(_messageBoxService,_displayWindowService, UserType);

            try
            {
                var username = txtUsername.Text;
                var password = txtPassword.Password;

                _authenticationViewModel.Login(SecurityConnectorValidator.CheckIfUsernameAndPasswordFieldsAreEmpty(username, password), username, password, UserType);
                Window.GetWindow(this).Close();
            }
            catch(FailedAuthenticationException ex)
            {
                _authenticationViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private AdminsMenuWindow BuildAdminsMenuWindow() => new AdminsMenuWindow(_isAuthenticated as Admin);
        private UsersMenuWindow BuildUsersMenuWindow() => new UsersMenuWindow(_isAuthenticated as User);
    }
}
