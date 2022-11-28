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
using Assignment1.DomainLayer.Models;
using Assignment1.PresentationLayer.HelperClasses;
using Assignment1.PresentationLayer.Interfaces;

namespace Assignment1.PresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for MainMenuPageEmployee.xaml
    /// </summary>
    public partial class MainMenuPageEmployee : Page
    {
        #region Properties
        private readonly Lazy<EmployeeClientsPage> _employeeClientsPage;
        private readonly Lazy<EmployeeAccountsPage> _employeeAccountsPage;
        private readonly IDisplayWindowService _displayWindowService;
        private Command _displayLoginWindow;
        private Employee AuthenticatedEmployee{ get; set; }
        #endregion

        #region Constructors
        public MainMenuPageEmployee()
        {
            InitializeComponent();
            _employeeAccountsPage = new Lazy<EmployeeAccountsPage>(BuildAccountsPage);
            _employeeClientsPage = new Lazy<EmployeeClientsPage>(BuildClientsPage);
            _displayWindowService = new WPFDisplayWindowService();

        }
        #endregion

        private void Button_ClientsActions(object sender, RoutedEventArgs e)
        {
            var wndMain = Window.GetWindow(this) as MainWindow;
            AuthenticatedEmployee = wndMain.Employee;
            NavigationService.Navigate(_employeeClientsPage.Value);
        }

        private void Button_AccountsActions(object sender, RoutedEventArgs e)
        {
            var wndMain = Window.GetWindow(this) as MainWindow;
            AuthenticatedEmployee = wndMain.Employee;
            NavigationService.Navigate(_employeeAccountsPage.Value);
        }

        private void Button_LogOutAction(object sender, RoutedEventArgs e)
        {
            _displayLoginWindow = new Command(() => _displayWindowService.DisplaySelectUserWindow());
            _displayLoginWindow.ExecuteCommand();
            Window.GetWindow(this).Close();
        }

        private EmployeeAccountsPage BuildAccountsPage() => new EmployeeAccountsPage();

        private EmployeeClientsPage BuildClientsPage() => new EmployeeClientsPage();
    }
}
