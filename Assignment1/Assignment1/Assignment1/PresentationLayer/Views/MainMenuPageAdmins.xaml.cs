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

namespace Assignment1.PresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for MainMenuPageAdmins.xaml
    /// </summary>
    public partial class MainMenuPageAdmins : Page
    {
        #region Properties
        private readonly IDisplayWindowService _displayWindowService;
        private Command _displayLoginWindow;
        private readonly Lazy<AdminEmployeesPage> _adminEmployeesPage;
        private readonly Lazy<GenerateReportsPage> _generateRepotsPage;
        #endregion

        #region Constructors
        public MainMenuPageAdmins()
        {
            InitializeComponent();
            _displayWindowService = new WPFDisplayWindowService();
            _adminEmployeesPage = new Lazy<AdminEmployeesPage>(BuildAdminEmployeesPage);
            _generateRepotsPage = new Lazy<GenerateReportsPage>(BuildGenerateReportsPage);
        }
        #endregion

        private void Button_EmployeesActions(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_adminEmployeesPage.Value);
        }

        private void Button_ReportsActions(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_generateRepotsPage.Value);
        }

        private void Button_LogOutAction(object sender, RoutedEventArgs e)
        {
            _displayLoginWindow = new Command(() => _displayWindowService.DisplaySelectUserWindow());
            _displayLoginWindow.ExecuteCommand();
            Window.GetWindow(this).Close();
        }

        private AdminEmployeesPage BuildAdminEmployeesPage() => new AdminEmployeesPage();

        private GenerateReportsPage BuildGenerateReportsPage() => new GenerateReportsPage();
    }
}
