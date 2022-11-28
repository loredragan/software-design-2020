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
using Assignment_3.Models;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.Interfaces;
using Client.ViewModels.ViewModels.Admin;
using Client.Views.HelperClasses;
using Client.Views.Interfaces;

namespace Client.Views.Pages.Admin
{
    /// <summary>
    /// Interaction logic for AdminManageUsersAdsPage.xaml
    /// </summary>
    public partial class AdminManageUsersAdsPage : Page
    {
        #region Properties
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        private IMessageBoxService MessageBoxService { get; set; }
        private ICrudValidator Validator { get; set; }
        private AdminViewModel<Ad> ViewModel { get; set; }
        #endregion

        public AdminManageUsersAdsPage()
        {
            InitializeComponent();
            Validator = new AdminManageUsersAdsValidator();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            MessageBoxService = new WPFMessageBoxService();
            ViewModel = new AdminManageUsersAdsViewModel(MessageBoxService, Validator);
        }

        #region Get Authenticated Admin
        private Assignment_3.Models.Admin GetAuthenticatedAdmin()
        {
            var wndMain = Window.GetWindow(this) as AdminsMenuWindow;
            var authenticatedAdmin = wndMain.AuthenticatedAdmin;

            return authenticatedAdmin;
        }
        #endregion

        #region Get Data From UI
        private Dictionary<string, string> GetValuesFromTextBoxes()
        {
            var list = AdminManageUsersAds.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        #region List Data
        private void ShowAds<Ad>(IEnumerable<Ad> ads)
        {
            ListModelsPage.Value.dataGrid.ItemsSource = ads;
            NavigationService.Navigate(ListModelsPage.Value);
        }
        #endregion

        internal void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsLetter(x));

        internal new void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsDigit(x));

        private void Button_AddNewModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationResult = (Validator as AdminManageUsersAdsValidator).ValidateInputsForAddNewModel(valuesFromUi);
                (ViewModel as AdminManageUsersAdsViewModel).AddNewModel(valuesFromUi, validationResult, GetAuthenticatedAdmin().id);
                ViewModel.ShowMessageWindow("Successfully added new ad");
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_ListModels(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var result = (ViewModel as AdminManageUsersAdsViewModel).GetAllModels(valuesFromUi, GetAuthenticatedAdmin().id);
                ShowAds(result);
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_UpdateModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationresult = (Validator as AdminManageUsersAdsValidator).ValidateInputsForUpdateModel(valuesFromUi);
                (ViewModel as AdminManageUsersAdsViewModel).UpdateModelById(valuesFromUi, validationresult, GetAuthenticatedAdmin().id);
                ViewModel.ShowMessageWindow("Successfully updated ad");
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_FindByIdModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationresult = (Validator as AdminManageUsersAdsValidator).ValidateInputsForFindModelById(valuesFromUi);
                var result = (ViewModel as AdminManageUsersAdsViewModel).GetModelById(valuesFromUi, validationresult, GetAuthenticatedAdmin().id);
                ShowAds(result);
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_DeleteByIdModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationResult = (Validator as AdminManageUsersAdsValidator).ValidateInputsForDeleteModel(valuesFromUi);
                (ViewModel as AdminManageUsersAdsViewModel).DeleteModelById(valuesFromUi, validationResult, GetAuthenticatedAdmin().id);
                ViewModel.ShowMessageWindow("Successfully deleted the ad");
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowAds<IModel>);
    }
}

