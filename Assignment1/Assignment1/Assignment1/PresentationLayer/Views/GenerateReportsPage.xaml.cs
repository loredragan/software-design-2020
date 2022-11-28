using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for GenerateReportsPage.xaml
    /// </summary>
    public partial class GenerateReportsPage : Page
    {
        #region Properties
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        private const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Assignment1;Integrated Security=True";
        private readonly LogsModule _logsModule;
        private readonly EmployeesModule _employeesModule;
        #endregion

        #region Constructors
        public GenerateReportsPage()
        {
            InitializeComponent();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            _logsModule = new LogsModule(ConnectionString);
            _employeesModule = new EmployeesModule(ConnectionString);
        }
        #endregion

        #region List Data
        private void ShowReports<Log>(IEnumerable<Log> logs)
        {
            ListModelsPage.Value.dataGrid.ItemsSource = logs;
            NavigationService.Navigate(ListModelsPage.Value);
        }
        #endregion

        #region Get Data From UI
        private Dictionary<string, string> GetValuesFromTextBoxes()
        {
            var list = GenerateReportsGrid.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        #region Generate Report
        private void GenerateReport(IEnumerable<Log> logs)
        {
            var toCsv = LinqToCSV.ToCsv(logs);
            var toDate = DateTime.Now.ToString();
            var filePath = "D:\\An 3\\Sem2\\Proiectare_Software\\2020-30236-project-loredragan\\Assignment1\\Assignment1\\rep.csv";
            using (TextWriter tw = File.CreateText(filePath))
            {
                tw.WriteLine(toCsv);
            }
        }
        #endregion

        internal new void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsDigit(x));

        private void Button_GenerateReport(object sender, RoutedEventArgs e)
        {
            try
            {
                var newValues = GetValuesFromTextBoxes();
                var validationResult =
                    AdminGenerateReportsInputValidator.ValidateInputsForGenerateReportInInterval(newValues);
                if (validationResult.IsValid == false)
                {
                    MessageBox.Show(validationResult.ValidationResultMessage);
                }
                else
                {
                    var id = Convert.ToInt32(newValues["id"]); 
                    var existsEmployee = _employeesModule.GetEmployeeById(id);
                    if (existsEmployee.Any())
                    {
                        var res = _logsModule.GetLogsInInterval(id, newValues["fromDate"], newValues["toDate"]);
                        if (res.Any())
                        {
                            //ShowReports(res);
                            GenerateReport(res);
                            MessageBox.Show("Report generated successfully");
                        }
                        else
                        {
                            MessageBox.Show("No reports matching the interval");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No employee with this ID");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Button_ListReports(object sender, RoutedEventArgs e)
        {
            try
            {
                var logs = _logsModule.GetLogs();
                ShowReports(logs);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowReports<IModel>);
    }
}
