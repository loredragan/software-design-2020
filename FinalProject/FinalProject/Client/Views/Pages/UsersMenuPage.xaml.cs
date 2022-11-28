using Client.Views.HelperClasses;
using Client.Views.Interfaces;
using Client.Views.Pages.RegularUser;
using FinalProject.Models;
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

namespace Client.Views.Pages
{
    /// <summary>
    /// Interaction logic for UsersMenuPage.xaml
    /// </summary>
    public partial class UsersMenuPage : Page
    {
        #region Private Members
        private Command _displayWindowCommand;
        private readonly IDisplayWindowService _displayWindowService;
        private readonly Lazy<RegularUserSearchAdsPage> _searchAdsPage;
        private readonly Lazy<RegularUserManageAdsPage> _managePersonalAdsPage;
        private readonly Lazy<RegularUserChatsPage> _chatsPage;
        private readonly Lazy<RegularUserAdsPersonalizationPage> _adsPersonalizationPage;
        #endregion

        #region Exposed Members
        public User AuthenticatedUser;
        #endregion

        #region Constructors
        public UsersMenuPage()
        {
            _displayWindowService = new WPFDisplayWindowService();
            _searchAdsPage = new Lazy<RegularUserSearchAdsPage>(BuildSearchAdsPage);
            _managePersonalAdsPage = new Lazy<RegularUserManageAdsPage>(BuildManagePersonalAdsPage);
            _chatsPage = new Lazy<RegularUserChatsPage>(BuildChatsPage);
            _adsPersonalizationPage = new Lazy<RegularUserAdsPersonalizationPage>(BuildAdsPersonalizationPage);
            InitializeComponent();
        }
        #endregion

        #region Private Methods
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

        private void BtnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this) as UsersMenuWindow;
            AuthenticatedUser = currentWindow.AuthenticatedUser;
            NavigationService.Navigate(_chatsPage.Value);
        }

        private void BtnAdsPersonalization_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this) as UsersMenuWindow;
            AuthenticatedUser = currentWindow.AuthenticatedUser;
            NavigationService.Navigate(_adsPersonalizationPage.Value);
        }

        private RegularUserManageAdsPage BuildManagePersonalAdsPage() => new RegularUserManageAdsPage();

        private RegularUserSearchAdsPage BuildSearchAdsPage() => new RegularUserSearchAdsPage();

        private RegularUserChatsPage BuildChatsPage() => new RegularUserChatsPage();

        private RegularUserAdsPersonalizationPage BuildAdsPersonalizationPage() => new RegularUserAdsPersonalizationPage();
        #endregion
    }
}
