using Client.ViewModels.HelperClasses.RegularUserAdsPersonalization;
using Client.ViewModels.Interfaces;
using Client.ViewModels.ViewModels.RegularUser;
using Client.Views.HelperClasses;
using Client.Views.Interfaces;
using FinalProject;
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

namespace Client.Views.Pages.RegularUser
{
    /// <summary>
    /// Interaction logic for RegularUserAdsPersonalizationPage.xaml
    /// </summary>
    public partial class RegularUserAdsPersonalizationPage : Page
    {
        #region Private Members
        private RegularUserViewModel<Favorite> FavoritesViewModel { get; set; }
        private RegularUserViewModel<Rating> RatingsViewModel { get; set; }
        private IMessageBoxService MessageBoxService { get; set; }
        private IValidator RatingsValidator { get; set; }
        private IValidator FavoritesValidator { get; set; }
        #endregion

        #region Exposed Members
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        #endregion

        #region Constructors
        public RegularUserAdsPersonalizationPage()
        {
            InitializeComponent();
            RatingsValidator = new RegularUserRatingsValidator();
            FavoritesValidator = new RegularUserFavoritesValidator();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            MessageBoxService = new WPFMessageBoxService();
            RatingsViewModel = new RegularUserManageRatingsViewModel(MessageBoxService, RatingsValidator);
            FavoritesViewModel = new RegularUserManageFavoritesViewModel(MessageBoxService, FavoritesValidator);
        }
        #endregion

        #region Private Methods

        #region List Data
        private void ShowData<BaseModel>(IEnumerable<BaseModel> ads)
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
            var list = AdsPersonalization.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        private void Button_GetAllRatings(object sender, EventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var result = (RatingsViewModel as RegularUserManageRatingsViewModel).GetAllModels(valuesFromUi, GetAuthenticatedUser().id);
                ShowData(result);
            }
            catch(Exception ex)
            {
                RatingsViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_RateAd(object sender, EventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationResult = (RatingsValidator as RegularUserRatingsValidator).ValidateInputsForAddNewModel(valuesFromUi);
                (RatingsViewModel as RegularUserManageRatingsViewModel).AddNewModel(valuesFromUi, validationResult, GetAuthenticatedUser().id);
                RatingsViewModel.ShowMessageWindow("Successfully added a new rating to ad");
            }
            catch (Exception ex)
            {
                RatingsViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_GetAllFavorites(object sender, EventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var result = (FavoritesViewModel as RegularUserManageFavoritesViewModel).GetAllModels(valuesFromUi, GetAuthenticatedUser().id);
                ShowData(result);
            }
            catch (Exception ex)
            {
                RatingsViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_AddFavorite(object sender, EventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationResult = (FavoritesValidator as RegularUserFavoritesValidator).ValidateInputsForAddNewModel(valuesFromUi);
                (FavoritesViewModel as RegularUserManageFavoritesViewModel).AddNewModel(valuesFromUi, validationResult, GetAuthenticatedUser().id);
                FavoritesViewModel.ShowMessageWindow("Successfully added a new ad to favorites");
            }
            catch (Exception ex)
            {
                FavoritesViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_DeleteFavorite(object sender, EventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationResult = (FavoritesValidator as RegularUserFavoritesValidator).ValidateInputsForDeleteModel(valuesFromUi);
                (FavoritesViewModel as RegularUserManageFavoritesViewModel).DeleteModel(valuesFromUi, validationResult, GetAuthenticatedUser().id);
                FavoritesViewModel.ShowMessageWindow("Successfully deleted the ad from favorites");
            }
            catch (Exception ex)
            {
                FavoritesViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowData<IModel>);

        internal void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsLetter(x));

        internal new void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsDigit(x));
        #endregion
    }
}
