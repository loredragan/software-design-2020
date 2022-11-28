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
using Assignment1.PresentationLayer.HelperClasses;
using Assignment1.PresentationLayer.Interfaces;

namespace Assignment1.Views
{
    /// <summary>
    /// Interaction logic for SelectUserTypePage.xaml
    /// </summary>
    public partial class SelectUserTypePage : Page, IPage
    {
        #region Properties
        private Lazy<LoginWindow> _loginWindow;
        private IDisplayWindowService DisplayWindowService { get; set; }
        private Command DisplayLoginWindow {get;set;}
        public string UserType { get; set; }
        #endregion

        #region Constructors
        public SelectUserTypePage()
        {
            InitializeComponent();
            DisplayWindowService = new WPFDisplayWindowService();
            _loginWindow = new Lazy<LoginWindow>(BuildLoginWindow);
        }
        #endregion

        private void BtnEmployeeUser_Click(object sender, RoutedEventArgs e)
        {
            UserType = "users";
            DisplayLoginWindow = new Command(() => DisplayWindowService.DisplayLoginWindow(UserType));
            DisplayLoginWindow.ExecuteCommand();

            Window.GetWindow(this).Close();

        }

        private void BtnAdminUser_Click(object sender, RoutedEventArgs e)
        {
            UserType = "admins";
            DisplayLoginWindow = new Command(() => DisplayWindowService.DisplayLoginWindow(UserType));
            DisplayLoginWindow.ExecuteCommand();

            Window.GetWindow(this).Close();
        }

        private LoginWindow BuildLoginWindow() => new LoginWindow(UserType);
    }
}
