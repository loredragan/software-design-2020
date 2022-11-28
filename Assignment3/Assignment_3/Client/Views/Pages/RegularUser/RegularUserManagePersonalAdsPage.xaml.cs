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
using Client.ViewModels.ViewModels.RegularUser;
using Client.Views.HelperClasses;
using Client.Views.Interfaces;

namespace Client.Views.Pages.RegularUser
{
    /// <summary>
    /// Interaction logic for RegularUserManagePersonalAdsPage.xaml
    /// </summary>
    public partial class RegularUserManagePersonalAdsPage : Page
    {
        #region Properties
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        private RegularUserViewModel<Ad> ViewModel { get; set; }
        private IMessageBoxService MessageBoxService { get; set; }
        private ICrudValidator Validator { get; set; }
        #endregion

        #region Constructors
        public RegularUserManagePersonalAdsPage()
        {
            InitializeComponent();
            Validator = new UserManagePersonalAdsValidator();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            MessageBoxService = new WPFMessageBoxService();
            ViewModel = new RegularUserManageAdsViewModel(MessageBoxService, Validator);
        }
        #endregion

        #region List Data
        private void ShowAds<Ad>(IEnumerable<Ad> ads)
        {
            ListModelsPage.Value.dataGrid.ItemsSource = ads;
            NavigationService.Navigate(ListModelsPage.Value);
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

        #region Get Data From UI
        private Dictionary<string, string> GetValuesFromTextBoxes()
        {
            var list = UserManagePersonalAds.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        internal void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsLetter(x));

        internal new void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsDigit(x));

        #region CRUD
        private void Button_AddNewModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationResult = (Validator as UserManagePersonalAdsValidator).ValidateInputsForAddNewModel(valuesFromUi);
                (ViewModel as RegularUserManageAdsViewModel).AddNewModel(valuesFromUi, validationResult, GetAuthenticatedUser().id);
                ViewModel.ShowMessageWindow("Successfully added a new ad");
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
                var result = (ViewModel as RegularUserManageAdsViewModel).GetAllModels(valuesFromUi, GetAuthenticatedUser().id);
                ShowAds(result);
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_GetAllFavorites(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var result = (ViewModel as RegularUserManageAdsViewModel).GetAllFavorites(valuesFromUi, GetAuthenticatedUser().id);
                ShowAds(result);
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_SeeInbox(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var result = (ViewModel as RegularUserManageAdsViewModel).GetInbox(valuesFromUi, GetAuthenticatedUser().id);
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
                var validationresult = (Validator as UserManagePersonalAdsValidator).ValidateInputsForUpdateModel(valuesFromUi);
                (ViewModel as RegularUserManageAdsViewModel).UpdateModelById(valuesFromUi, validationresult, GetAuthenticatedUser().id);
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
                var validationresult = (Validator as UserManagePersonalAdsValidator).ValidateInputsForFindModelById(valuesFromUi);
                var result = (ViewModel as RegularUserManageAdsViewModel).GetModelById(valuesFromUi, validationresult, GetAuthenticatedUser().id);
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
                var validationResult = (Validator as UserManagePersonalAdsValidator).ValidateInputsForDeleteModel(valuesFromUi);
                (ViewModel as RegularUserManageAdsViewModel).DeleteModelById(valuesFromUi, validationResult, GetAuthenticatedUser().id);
                ViewModel.ShowMessageWindow("Successfully deleted the ad");
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_AddToFavorites(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationResult = (Validator as UserManagePersonalAdsValidator).ValidateInputForAddToFavourites(valuesFromUi);
                (ViewModel as RegularUserManageAdsViewModel).AddToFavorites(valuesFromUi, validationResult, GetAuthenticatedUser().id);
                ViewModel.ShowMessageWindow("Successfully added an ad to favorites");
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_SendMessage(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationResult = (Validator as UserManagePersonalAdsValidator).ValidateInputsForSendMessage(valuesFromUi);
                (ViewModel as RegularUserManageAdsViewModel).SendMessage(valuesFromUi, validationResult, GetAuthenticatedUser().id);
                ViewModel.ShowMessageWindow("Message sent successfully");
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        #endregion
        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowAds<IModel>);
    }
}
