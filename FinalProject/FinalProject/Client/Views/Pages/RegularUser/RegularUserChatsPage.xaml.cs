using Client.ViewModels.HelperClasses.RegularUserChats;
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
    /// Interaction logic for RegularUserChatsPage.xaml
    /// </summary>
    public partial class RegularUserChatsPage : Page
    {
        #region Exposed Members
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        #endregion

        #region Private Members
        private RegularUserViewModel<ChatMessage> ViewModel { get; set; }
        private IMessageBoxService MessageBoxService { get; set; }
        private IValidator Validator { get; set; }
        #endregion

        #region Constructors
        public RegularUserChatsPage()
        {
            InitializeComponent();
            InitializeComponent();
            Validator = new RegularUserChatsValidator();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            MessageBoxService = new WPFMessageBoxService();
            ViewModel = new RegularUserChatsViewModel(MessageBoxService, Validator);
        }
        #endregion

        #region Private Methods
        #region List Data
        private void ShowAds<BaseModel>(IEnumerable<BaseModel> ads)
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
            var list = RegularUserChats.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        private void Button_SendMessage(object sender, RoutedEventArgs e)
        {
            try
            {
                var valuesFromUi = GetValuesFromTextBoxes();
                var validationResult = (Validator as RegularUserChatsValidator).ValidateInputsForSendMessage(valuesFromUi);
                (ViewModel as RegularUserChatsViewModel).SendMessage(valuesFromUi, validationResult, GetAuthenticatedUser().id);
                ViewModel.ShowMessageWindow("Message sent successfully");
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
                var result = (ViewModel as RegularUserChatsViewModel).GetInbox(valuesFromUi, GetAuthenticatedUser().id);
                ShowAds(result);
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowAds<IModel>);

        internal void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsLetter(x));

        internal new void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsDigit(x));
        #endregion
    }
}
