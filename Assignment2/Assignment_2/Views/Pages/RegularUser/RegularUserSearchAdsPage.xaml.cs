using Assignment_2.Model;
using Assignment_2.Models;
using Assignment_2.View.HelperClasses;
using Assignment_2.ViewModels.Interfaces;
using Assignment_2.ViewModels.ViewModels;
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

namespace Assignment_2.Views.Pages
{
    /// <summary>
    /// Interaction logic for RegularUserSearchAdsPage.xaml
    /// </summary>
    public partial class RegularUserSearchAdsPage : Page
    {
        #region Properties
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        private RegularUserViewModel<Ad> ViewModel { get; set; }
        private IMessageBoxService MessageBoxService { get; set; }
        private IFilterValidator<Ad> Validator { get; set; }
        #endregion

        #region Constructors
        public RegularUserSearchAdsPage()
        {
            InitializeComponent();
            Validator = new FilterValidator<Ad>();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            MessageBoxService = new WPFMessageBoxService();
            ViewModel = new RegularUserSearchAdsViewModel(MessageBoxService, Validator);
        }
        #endregion

        #region Get Data From UI
        private Dictionary<string, string> GetValuesFromTextBoxes()
        {
            var list = UserSearchAdsGrid.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        #region Get Authenticated User
        private User GetAuthenticatedUser()
        {
            var wndMain = Window.GetWindow(this) as UsersMenuWindow;
            var authenticatedUser = wndMain.AuthenticatedUser;

            return authenticatedUser;
        }
        #endregion

        #region List Data
        private void ShowAds<Ad>(IEnumerable<Ad> ads)
        {
            ListModelsPage.Value.dataGrid.ItemsSource = ads;
            NavigationService.Navigate(ListModelsPage.Value);
        }
        #endregion

        private void Button_ListModelsFiltered(object sender, RoutedEventArgs e)
        {
            try
            {
                var filterRequest = RequestBuilder.BuildFindRequest(GetValuesFromTextBoxes());
                var filteredAds = (ViewModel as RegularUserSearchAdsViewModel).GetModelsFiltered(filterRequest);
                ShowAds(filteredAds);
            }
            catch(Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowAds<IModel>);

        internal void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsLetter(x));

        internal new void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsDigit(x));
    }
}
