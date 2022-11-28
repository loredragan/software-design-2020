using Client.ViewModels.HelperClasses.AdminManageRatings;
using Client.ViewModels.Interfaces;
using Client.ViewModels.ViewModels.Admin;
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

namespace Client.Views.Pages.Admin
{
    /// <summary>
    /// Interaction logic for AdminManageRatingsPage.xaml
    /// </summary>
    public partial class AdminManageRatingsPage : Page
    {
        #region Exposed Members
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        #endregion

        #region Private Members
        private IMessageBoxService MessageBoxService { get; set; }
        private IValidator Validator { get; set; }
        private AdminViewModel<Rating> ViewModel { get; set; }
        #endregion

        #region Constructors
        public AdminManageRatingsPage()
        {
            InitializeComponent();
            Validator = new AdminManageRatingsValidator();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            MessageBoxService = new WPFMessageBoxService();
            ViewModel = new AdminManageRatingsViewModel(MessageBoxService, Validator);
        }
        #endregion

        #region Private Methods

        #region Get Data From UI
        private Dictionary<string, string> GetValuesFromTextBoxes()
        {
            var list = AdminManageRating.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        #region Get Authenticated Admin
        private FinalProject.Models.Admin GetAuthenticatedAdmin()
        {
            var wndMain = Window.GetWindow(this) as AdminsMenuWindow;
            var authenticatedAdmin = wndMain.AuthenticatedAdmin;

            return authenticatedAdmin;
        }
        #endregion

        #region List Data
        private void ShowRatings<Rating>(IEnumerable<Rating> ratings)
        {
            ListModelsPage.Value.dataGrid.ItemsSource = ratings;
            NavigationService.Navigate(ListModelsPage.Value);
        }
        #endregion


        private void Button_ListModels(object sender, EventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var result = (ViewModel as AdminManageRatingsViewModel).GetAllModels(valuesFromUi, GetAuthenticatedAdmin().id);
                ShowRatings(result);
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_UpdateModel(object sender, EventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationresult = (Validator as AdminManageRatingsValidator).ValidateInputsForUpdateModel(valuesFromUi);
                (ViewModel as AdminManageRatingsViewModel).UpdateModelById(valuesFromUi, validationresult, GetAuthenticatedAdmin().id);
                ViewModel.ShowMessageWindow("Successfully updated rating");
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_FindByIdModel(object sender, EventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationresult = (Validator as AdminManageRatingsValidator).ValidateInputsForFindModelById(valuesFromUi);
                var result = (ViewModel as AdminManageRatingsViewModel).GetModelById(valuesFromUi, validationresult, GetAuthenticatedAdmin().id);
                ShowRatings(result);
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        internal void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsLetter(x));

        internal new void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsDigit(x));

        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowRatings<IModel>);
        #endregion
    }
}
