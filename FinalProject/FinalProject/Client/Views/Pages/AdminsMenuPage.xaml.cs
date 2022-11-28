using Client.Views.HelperClasses;
using Client.Views.Interfaces;
using Client.Views.Pages.Admin;
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
using FinalProject.Models;

namespace Client.Views.Pages
{
    /// <summary>
    /// Interaction logic for AdminsMenuPage.xaml
    /// </summary>
    public partial class AdminsMenuPage : Page
    {
        #region Private Members
        private readonly IDisplayWindowService _displayWindowService;
        private Command _displayWindowCommand;
        private readonly Lazy<AdminGenerateReportsPage> _generateReportsPage;
        private readonly Lazy<AdminManageUsersAdsPage> _manageUsersAdsPage;
        private readonly Lazy<AdminManageUsersPage> _manageUsersPage;
        private readonly Lazy<AdminManageRatingsPage> _manageRatings;
        #endregion

        #region Public Members
        public FinalProject.Models.Admin AuthenticatedAdmin;
        #endregion

        public AdminsMenuPage()
        {
            InitializeComponent();
            _generateReportsPage = new Lazy<AdminGenerateReportsPage>(BuildGenerateReportsPage);
            _manageUsersAdsPage = new Lazy<AdminManageUsersAdsPage>(BuildManageUsersAdsPage);
            _manageUsersPage = new Lazy<AdminManageUsersPage>(BuildManageUsersPage);
            _manageRatings = new Lazy<AdminManageRatingsPage>(BuildManageRatingsPage);
            _displayWindowService = new WPFDisplayWindowService();
        }

        private void BtnManageRatings_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this) as AdminsMenuWindow;
            AuthenticatedAdmin = currentWindow.AuthenticatedAdmin;
            NavigationService.Navigate(_manageRatings.Value);
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            _displayWindowCommand = new Command(() => _displayWindowService.DisplaySelectUserWindow());
            _displayWindowCommand.ExecuteCommand();
            Window.GetWindow(this).Close();
        }

        private void BtnManageUsers_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this) as AdminsMenuWindow;
            AuthenticatedAdmin = currentWindow.AuthenticatedAdmin;
            NavigationService.Navigate(_manageUsersPage.Value);
        }

        private void BtnManageUsersAds_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this) as AdminsMenuWindow;
            AuthenticatedAdmin = currentWindow.AuthenticatedAdmin;
            NavigationService.Navigate(_manageUsersAdsPage.Value);
        }

        private void BtnGenerateReports_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this) as AdminsMenuWindow;
            AuthenticatedAdmin = currentWindow.AuthenticatedAdmin;
            NavigationService.Navigate(_generateReportsPage.Value);
        }

        private AdminGenerateReportsPage BuildGenerateReportsPage() => new AdminGenerateReportsPage();

        private AdminManageUsersAdsPage BuildManageUsersAdsPage() => new AdminManageUsersAdsPage();

        private AdminManageUsersPage BuildManageUsersPage() => new AdminManageUsersPage();

        private AdminManageRatingsPage BuildManageRatingsPage() => new AdminManageRatingsPage();
    }
}
