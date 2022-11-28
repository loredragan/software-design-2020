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
using Assignment1.DomainLayer.HelperClasses;
using Assignment1.DomainLayer.Interfaces;
using Assignment1.DomainLayer.Models;
using Assignment1.DomainLayer.Modules;
using Assignment1.PresentationLayer.HelperClasses;

namespace Assignment1.PresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for EmployeeClientsPage.xaml
    /// </summary>
    public partial class EmployeeClientsPage : Page
    {
        #region Properties
        private const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Assignment1;Integrated Security=True";
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        private readonly ClientsModule _clientsModule;
        private readonly LogsModule _logsModule;
        #endregion

        #region Constructors
        public EmployeeClientsPage()
        {
            InitializeComponent();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            _clientsModule = new ClientsModule(ConnectionString);
            _logsModule = new LogsModule(ConnectionString);
        }
        #endregion

        #region Get Data From UI
        private Dictionary<string, string> GetValuesFromTextBoxes()
        {
            var list = mainGrid.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        #region List Data
        private void ShowClients<Client>(IEnumerable<Client> clients)
        {
            ListModelsPage.Value.dataGrid.ItemsSource = clients;
            NavigationService.Navigate(ListModelsPage.Value);
        }
        #endregion

        #region Get Authenticated Employee
        private Employee GetAuthenticatedEmployee()
        {
            var wndMain = Window.GetWindow(this) as MainWindow;
            var authenticatedEmployee = wndMain.Employee;

            return authenticatedEmployee;
        }
        #endregion

        internal void PreviewTextInputNumbers(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsLetter(x));

        internal new void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsDigit(x));

        private void Button_AddNewModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var newValues = GetValuesFromTextBoxes();
                var validation = EmployeeClientsInputValidator.ValidateInputsForAddNewModel(newValues);

                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var newClient = new Client(Convert.ToInt64(newValues["cnp"]), Convert.ToInt32(newValues["age"]),
                        newValues["name"], newValues["address"]);
                    _clientsModule.InsertClientData(newClient);
                    LogAction("AddClient");
                    MessageBox.Show("Client inserted successfully");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Button_ListModels(object sender, RoutedEventArgs e)
        {
            try
            {
                var clients = _clientsModule.GetClients();
                LogAction("ListClients");
                ShowClients(clients);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Button_UpdateModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var newValues = GetValuesFromTextBoxes();
                var validation = EmployeeClientsInputValidator.ValidateInputsForUpdateModel(newValues);

                if(validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var idCard = Convert.ToInt32(newValues["idCard"]);
                    //trebuia sa caut prima data clientul sa vad daca exista
                    var cnp = Convert.ToInt64(newValues["cnp"]);
                    var age = Convert.ToInt32(newValues["age"]);

                    var updatedClient = new Client(idCard, cnp, age, newValues["name"], newValues["address"]);
                    _clientsModule.UpdateClientData(updatedClient);
                    LogAction("UpdateClient");
                    MessageBox.Show("Client updated successfully");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void Button_FindByIdModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var newValues = GetValuesFromTextBoxes();
                var validation = EmployeeClientsInputValidator.ValidateInputsForFindById(newValues);

                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                { 
                    var id = Convert.ToInt32(newValues["idCard"]);
                    var result = _clientsModule.GetClientById(id);
                    if (result.Any())
                    {
                        LogAction("ListClientById");
                        ShowClients(result);
                    }
                    else
                    {
                        MessageBox.Show("No client with idCard = " + id);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowClients<IModel>);

        private void LogAction(string transactionType)
        {
            var newLog = new Log(GetAuthenticatedEmployee().Id, transactionType,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm"), "dbo.clientsinfo");
            _logsModule.InsertLog(newLog);
        }
    }
}
