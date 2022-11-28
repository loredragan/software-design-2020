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
using Assignment1.DomainLayer.Interfaces;
using Assignment1.DomainLayer.Models;
using Assignment1.DomainLayer.Modules;
using Assignment1.PresentationLayer.HelperClasses;

namespace Assignment1.PresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for EmployeeAccountsPage.xaml
    /// </summary>
    /// id, type, amount, creationDate, clientID
    public partial class EmployeeAccountsPage : Page
    {
        #region Properties
        private const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Assignment1;Integrated Security=True";
        private readonly AccountsModule _accountsModule;
        private readonly ClientsModule _clientsModule;
        private readonly LogsModule _logsModule;
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        #endregion

        #region Constructor
        public EmployeeAccountsPage()
        {
            InitializeComponent();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            _accountsModule = new AccountsModule(ConnectionString);
            _clientsModule = new ClientsModule(ConnectionString);
            _logsModule = new LogsModule(ConnectionString);
        }
        #endregion

        #region Get Data From UI
        private Dictionary<string, string> GetValuesFromTextBoxes()
        {
            var list = mainGrid.Children.OfType<TextBox>().ToList();

            return list.ToDictionary(item => item.Name, item => item.Text);
        }
        #endregion

        #region List Data
        private void ShowAccounts<Account>(IEnumerable<Account> accounts)
        {
            ListModelsPage.Value.dataGrid.ItemsSource = accounts;
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
                var validation = EmployeeAccountsInputValidator.ValidateInputsForAddNewModel(newValues);

                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var existsClient = _clientsModule.GetClientById(Convert.ToInt32(newValues["clientID"]));
                    if (existsClient.Any())
                    {
                        var newAccount = new Account(newValues["type"], Convert.ToDouble(newValues["amount"]),
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm tt"), Convert.ToInt32(newValues["clientID"]));
                        _accountsModule.InsertNewAccountForClient(newAccount);
                        LogAction("AddAccount");
                        MessageBox.Show("Account inserted successfully");
                    }
                    else
                    {
                        MessageBox.Show("No client with id = " + id);
                    }
                }
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
                var validation = EmployeeAccountsInputValidator.ValidateInputsForUpdateModel(newValues);

                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var id = Convert.ToInt32(newValues["id"]);
                    var existsAccount = _accountsModule.GetAccountById(Convert.ToInt32(newValues["id"]));
                    if (existsAccount.Any())
                    {
                        var newAmount = Convert.ToDouble(newValues["amount"]);
                        var newAccount = new Account(id, existsAccount.First().Type, newAmount, existsAccount.First().CreationDate,existsAccount.First().ClientId);
                        _accountsModule.UpdateAccountByAccountId(id, newAccount);
                        LogAction("UpdateAccount");
                        MessageBox.Show("Account updated successfully");

                    }
                    else
                    {
                        MessageBox.Show("No account with id = " + id);
                    }
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
                var accounts = _accountsModule.GetAccounts();
                LogAction("ListAccounts");
                ShowAccounts(accounts);
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
                var validation = EmployeeAccountsInputValidator.ValidateInputsForFindByAccountId(newValues);

                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var id = Convert.ToInt32(newValues["id"]);
                    var result = _accountsModule.GetAccountById(id);
                    if (result.Any())
                    {
                        LogAction("ListAccountById");
                        ShowAccounts(result);
                    }
                    else
                    {
                        MessageBox.Show("No account with id = " + id);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Button_DeleteModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var newValues = GetValuesFromTextBoxes();
                var validation = EmployeeAccountsInputValidator.ValidateInputsForDeleteModelById(newValues);
                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var id = Convert.ToInt32(newValues["id"]);
                    var existsAccount = _accountsModule.GetAccountById(id);
                    if (existsAccount.Any())
                    {
                        _accountsModule.DeleteAccountById(id);
                        LogAction("DeleteAccount");
                        MessageBox.Show("Account deleted successfully");
                    }
                    else
                    {
                        MessageBox.Show("No account with id = " + id);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Button_FindByClientId(object sender, RoutedEventArgs e)
        {
            try
            {
                var newValues = GetValuesFromTextBoxes();
                var validation = EmployeeAccountsInputValidator.ValidateInputsForFindAccountsForClientGivenById(newValues);
                if(validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var id = Convert.ToInt32(newValues["clientID"]);
                    var clientFound = _clientsModule.GetClientById(id);
                    if (clientFound.Any())
                    {
                        var resultedAccounts = _accountsModule.GetAccountsByClientId(id);
                        if (resultedAccounts.Any())
                        {
                            LogAction("ListAccountByClientId");
                            ShowAccounts(resultedAccounts);
                        }
                        else
                        {
                            MessageBox.Show("No Accounts for client with id = " + id);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Client with id = " + id);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowAccounts<IModel>);

        private void Button_TransferAmount(object sender, RoutedEventArgs e)
        {
            try
            {
                var values = GetValuesFromTextBoxes();
                var validation = EmployeeAccountsInputValidator.ValidateInputsForTransferAmount(values);

                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var sumToBeTransferred = Convert.ToDouble(GetValuesFromTextBoxes()["TransferSum"]);

                    if (sumToBeTransferred <= 0)
                    {
                        MessageBox.Show("You can't transfer 0 or a negative amount");
                    }
                    else
                    {
                        var sourceAccount= _accountsModule.GetAccountById(Convert.ToInt32(values["fromAccount"]));
                        var destinationAccount = _accountsModule.GetAccountById(Convert.ToInt32(values["toAccount"]));

                        if(sourceAccount.Any() && destinationAccount.Any())
                        {
                            if(sourceAccount.First().Type != sourceAccount.First().Type)
                            {
                                MessageBox.Show("You can't transfer money between accounts " + Environment.NewLine +
                                                "with different currencies");
                            }
                            else
                            {
                                var newSourceAmountForSource = sourceAccount.First().Amount - sumToBeTransferred;
                                var newSourceAmountForDestination = destinationAccount.First().Amount + sumToBeTransferred;

                                if(newSourceAmountForSource < 0)
                                {
                                    MessageBox.Show("Insufficient funds");
                                }
                                else
                                {
                                    _accountsModule.UpdateAccountInTransaction(sourceAccount.First().Id, newSourceAmountForSource);
                                    _accountsModule.UpdateAccountInTransaction(destinationAccount.First().Id,
                                        newSourceAmountForDestination);
                                    LogAction("MoneyTransfer");
                                    MessageBox.Show("Money transferred!");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nonexistent source or destination account");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Button_PayUtility(object sender, RoutedEventArgs e)
        {
            try
            {
                var values = GetValuesFromTextBoxes();
                var validationResults = EmployeeAccountsInputValidator.ValidateInputsForPayUtilities(values);

                if (validationResults.IsValid == false)
                {
                    MessageBox.Show(validationResults.ValidationResultMessage);
                }

                var accountToPay = _accountsModule.GetAccountById(Convert.ToInt32(values["idUtility"]));
                var sumToPay = Convert.ToDouble(values["UtilitySum"]);
                if (accountToPay.Any())
                {
                    if(sumToPay > 0)
                    {
                        var newSumForAccount = accountToPay.First().Amount - sumToPay;
                        _accountsModule.UpdateAccountInTransaction(accountToPay.First().Id, newSumForAccount);
                        LogAction("PayUtility");
                        MessageBox.Show("Utility paid!");
                        //maybe generate a receipt
                    }
                    else
                    {
                        MessageBox.Show("You can't pay 0 or a negative amount of money");
                    }
                }
                else
                {
                    MessageBox.Show("No account matches the id = " + values["idUtility"]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void LogAction(string transactionType)
        {
            var newLog = new Log(GetAuthenticatedEmployee().Id, transactionType,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm tt"), "dbo.clientsaccounts2");
            _logsModule.InsertLog(newLog);
        }
    }
}
