using Assignment_2.Models;
using Assignment_2.View.HelperClasses;
using Assignment_2.View.Interfaces;
using Assignment_2.Views.Pages;
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
    /// Interaction logic for UsersMenuPage.xaml
    /// </summary>
    public partial class UsersMenuPage : Page
    {
        #region Properties
        private Command _displayWindowCommand;
        private readonly IDisplayWindowService _displayWindowService;
        public User AuthenticatedUser;
        private readonly Lazy<RegularUserSearchAdsPage> _searchAdsPage;
        private readonly Lazy<RegularUserManagePersonalAdsPage> _managePersonalAdsPage;
        #endregion

        #region Constructors
        public UsersMenuPage()
        {
            _displayWindowService = new WPFDisplayWindowService();
            _searchAdsPage = new Lazy<RegularUserSearchAdsPage>(BuildSearchAdsPage);
            _managePersonalAdsPage = new Lazy<RegularUserManagePersonalAdsPage>(BuildManagePersonalAdsPage);

            InitializeComponent();
        }
        #endregion

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            _displayWindowCommand = new Command(() => _displayWindowService.DisplaySelectUserWindow());
            _displayWindowCommand.ExecuteCommand();
            Window.GetWindow(this).Close();
        }

        private void BtnSearchAds_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this) as UsersMenuWindow;
            AuthenticatedUser = currentWindow.AuthenticatedUser;
            NavigationService.Navigate(_searchAdsPage.Value);
        }

        private void BtnManagePersonalAds_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this) as UsersMenuWindow;
            AuthenticatedUser = currentWindow.AuthenticatedUser;
            NavigationService.Navigate(_managePersonalAdsPage.Value);
        }

        private RegularUserManagePersonalAdsPage BuildManagePersonalAdsPage() => new RegularUserManagePersonalAdsPage();

        private RegularUserSearchAdsPage BuildSearchAdsPage() => new RegularUserSearchAdsPage();
    }
}
