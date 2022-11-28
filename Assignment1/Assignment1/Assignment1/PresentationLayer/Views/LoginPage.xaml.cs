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
using Assignment1.DomainLayer.Interfaces;
using Assignment1.DomainLayer.Modules;
using Assignment1.PresentationLayer.HelperClasses;
using Assignment1.PresentationLayer.Interfaces;

namespace Assignment1.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page, IPage
    {
        #region Properties
        private const string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Assignment1;Integrated Security=True";
        private const string RegisterSuccessMessage = "You have registered successfully.";
        private readonly LoginHelperClass _loginHelperClass;
        private readonly RegisterHelperClass _registerHelperClass;
        public string UserType { get; set; }
        #endregion

        #region Constructors
        public LoginPage()
        {
            InitializeComponent();
            _loginHelperClass = new LoginHelperClass(_connectionString);
            _registerHelperClass = new RegisterHelperClass(_connectionString);
        }
        #endregion

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var wndLogin = Window.GetWindow(this) as LoginWindow;
                UserType = wndLogin.UserType;
                var username = txtUsername.Text;
                var password = txtPassword.Password;

                var validationResult = SecurityConnectorValidator.CheckIfUsernameAndPasswordFieldsAreEmpty(username, password);
                _loginHelperClass.LogIn(validationResult, username, password, UserType);
                Window.GetWindow(this).Close();
            }
            catch (FailedAuthenticationConnectionException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
