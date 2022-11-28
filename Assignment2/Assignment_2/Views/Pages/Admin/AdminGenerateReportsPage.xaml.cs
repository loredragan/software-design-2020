using Assignment_2.Models;
using Assignment_2.ViewModels;
using Assignment_2.ViewModels.HelperClasses;
using Assignment_2.ViewModels.Interfaces;
using Assignment_2.ViewModels.ViewModels.Admin;
using Assignment_2.Views.HelperClasses;
using Assignment_2.Views.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for AdminGenerateReportsPage.xaml
    /// </summary>
    public partial class AdminGenerateReportsPage : Page
    {
        #region Properties
        private IMessageBoxService MessageBoxService { get; set; }
        private IReportsValidator Validator { get; set; }
        private AdminViewModel<Ad> ViewModel { get; set; }
        private FileCreator _fileCreator;
        #endregion

        public AdminGenerateReportsPage()
        {
            InitializeComponent();
            Validator = new AdminGenerateReportsValidator();
            MessageBoxService = new WPFMessageBoxService();
            ViewModel = new AdminGenerateReportsViewModel(MessageBoxService, Validator);
            _fileCreator = new FileCreator();
        }

        internal void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsLetter(x));

        internal new void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsDigit(x));

        #region Get Data From UI
        private Dictionary<string, string> GetValuesFromTextBoxes()
        {
            var list = AdminGenerateReports.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        #region Get Authenticated Admin
        private Admin GetAuthenticatedAdmin()
        {
            var wndMain = Window.GetWindow(this) as AdminsMenuWindow;
            var authenticatedAdmin = wndMain.AuthenticatedAdmin;

            return authenticatedAdmin;
        }
        #endregion

        private void Button_GenerateCSV(object sender, RoutedEventArgs e)
        {
            try
            {
                var values = GetValuesFromTextBoxes();
                var validationResult = Validator.ValidateInputsForFindModelById(values);
                (ViewModel as AdminGenerateReportsViewModel).GenerateReport(values, validationResult, GetAuthenticatedAdmin().id, FileTypes.Text, _fileCreator);
                ViewModel.ShowMessageWindow("File successfully created!");
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }

        private void Button_GeneratePDF(object sender, RoutedEventArgs e)
        {
            try
            {
                var values = GetValuesFromTextBoxes();
                var validationResult = Validator.ValidateInputsForFindModelById(values);
                (ViewModel as AdminGenerateReportsViewModel).GenerateReport(values, validationResult, GetAuthenticatedAdmin().id, FileTypes.Pdf, _fileCreator);
                ViewModel.ShowMessageWindow("File successfully created!");
            }
            catch (Exception ex)
            {
                ViewModel.ShowMessageWindow(ex.Message);
            }
        }
    }
}
