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
    /// Interaction logic for AdminManageUsersPage.xaml
    /// </summary>
    public partial class AdminManageUsersPage : Page
    {
        #region Properties
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        private IMessageBoxService MessageBoxService { get; set; }
        private ICrudValidator Validator { get; set; }
        private AdminViewModel<User> ViewModel { get; set; }
        #endregion

        #region Constructors
        public AdminManageUsersPage()
        {
            InitializeComponent();
            Validator = new AdminManageUsersValidator();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            MessageBoxService = new WPFMessageBoxService();
            ViewModel = new AdminManageUsersViewModel(MessageBoxService, Validator);
        }
        #endregion

        #region Get Data From UI
        private Dictionary<string, string> GetValuesFromTextBoxes()
        {
            var list = AdminManageUsers.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        #region Get Authenticated Admin
        private Assignment_3.Models.Admin GetAuthenticatedAdmin()
        {
            var wndMain = Window.GetWindow(this) as AdminsMenuWindow;
            var authenticatedAdmin = wndMain.AuthenticatedAdmin;

            return authenticatedAdmin;
        }
        #endregion

        #region List Data
        private void ShowUsers<User>(IEnumerable<User> ads)
        {
            ListModelsPage.Value.dataGrid.ItemsSource = ads;
            NavigationService.Navigate(ListModelsPage.Value);
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
                var validationResult = (Validator as AdminManageUsersValidator).ValidateInputsForAddNewModel(valuesFromUi);
                (ViewModel as AdminManageUsersViewModel).AddNewModel(valuesFromUi, validationResult, GetAuthenticatedAdmin().id);
                ViewModel.ShowMessageWindow("Successfully added a new user");
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
                var result = (ViewModel as AdminManageUsersViewModel).GetAllModels(valuesFromUi, GetAuthenticatedAdmin().id);
                ShowUsers(result);
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
                var validationresult = (Validator as AdminManageUsersValidator).ValidateInputsForUpdateModel(valuesFromUi);
                (ViewModel as AdminManageUsersViewModel).UpdateModelById(valuesFromUi, validationresult, GetAuthenticatedAdmin().id);
                ViewModel.ShowMessageWindow("Successfully updated user");
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
                var validationresult = (Validator as AdminManageUsersValidator).ValidateInputsForFindModelById(valuesFromUi);
                var result = (ViewModel as AdminManageUsersViewModel).GetModelById(valuesFromUi, validationresult, GetAuthenticatedAdmin().id);
                ShowUsers(result);
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
                var validationResult = (Validator as AdminManageUsersValidator).ValidateInputsForDeleteModel(valuesFromUi);
                (ViewModel as AdminManageUsersViewModel).DeleteModelById(valuesFromUi, validationResult, GetAuthenticatedAdmin().id);
                ViewModel.ShowMessageWindow("Successfully deleted the user");
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }
        #endregion

        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowUsers<IModel>);
    }
}
