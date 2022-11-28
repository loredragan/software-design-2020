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
    /// Interaction logic for AdminEmployeesPage.xaml
    /// </summary>
    public partial class AdminEmployeesPage : Page
    {
        #region Properties
        private const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Assignment1;Integrated Security=True";
        public Lazy<ListModelsPage> ListModelsPage { get; set; }
        private readonly EmployeesModule _employeesModule;
        #endregion

        #region Constructors
        public AdminEmployeesPage()
        {
            InitializeComponent();
            ListModelsPage = new Lazy<ListModelsPage>(BuildListModelsView);
            _employeesModule = new EmployeesModule(ConnectionString);
        }
        #endregion

        #region Get Data From UI
        private Dictionary<string, string> GetValuesFromTextBoxes()
        {
            var list = employeeCrud.Children.OfType<TextBox>().ToList();
            var dictOfTb = new Dictionary<string, string>();

            foreach (var item in list)
            {
                dictOfTb.Add(item.Name, item.Text);
            }

            return dictOfTb;
        }
        #endregion

        #region List Data
        private void ShowEmployees<Employee>(IEnumerable<Employee> employees)
        {
            ListModelsPage.Value.dataGrid.ItemsSource = employees;
            NavigationService.Navigate(ListModelsPage.Value);
        }
        #endregion

        internal new void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !e.Text.Any(x => char.IsDigit(x));

        private void Button_AddNewModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var newValues = GetValuesFromTextBoxes();
                var validation = AdminEmployeesInputValidator.ValidateInputsForAddNewModel(newValues);

                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var newEmployee = new Employee(newValues["username"], newValues["password"]);
                    _employeesModule.InsertEmployeeData(newEmployee);
                    MessageBox.Show("Employee inserted successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Button_ListModels(object sender, RoutedEventArgs e)
        {
            try
            {
                var employees = _employeesModule.GetEmployees();
                ShowEmployees(employees);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_UpdateModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var newValues = GetValuesFromTextBoxes();
                var validation = AdminEmployeesInputValidator.ValidateInputsForUpdateModel(newValues);

                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var id = Convert.ToInt32(newValues["id"]);
                    var updatedEmployee = new Employee(id, newValues["username"], newValues["password"]);
                    _employeesModule.UpdateEmployeeData(updatedEmployee);

                    MessageBox.Show("Employee updated successfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_FindByIdModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var newValues = GetValuesFromTextBoxes();
                var validation = AdminEmployeesInputValidator.ValidateInputsForFindById(newValues);

                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var id = Convert.ToInt32(newValues["id"]);
                    var result = _employeesModule.GetEmployeeById(id);

                    if (result.Any())
                    {
                        ShowEmployees(result);
                    }
                    else
                    {
                        MessageBox.Show("No employee with id = " + id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_DeleteByIdModel(object sender, RoutedEventArgs e)
        {
            try
            {
                var newValues = GetValuesFromTextBoxes();
                var validation = AdminEmployeesInputValidator.ValidateInputsForDeleteModel(newValues);


                if (validation.IsValid == false)
                {
                    MessageBox.Show(validation.ValidationResultMessage);
                }
                else
                {
                    var id = Convert.ToInt32(newValues["id"]);
                    _employeesModule.DeleteEmployeeById(id);

                    MessageBox.Show("Employee deleted successfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private ListModelsPage BuildListModelsView() => new ListModelsPage(ShowEmployees<IModel>);
    }
}
