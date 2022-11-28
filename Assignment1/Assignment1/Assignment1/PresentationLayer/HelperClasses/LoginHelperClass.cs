using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DataSourceLayer.Interfaces;
using Assignment1.DomainLayer.Interfaces;
using Assignment1.DomainLayer.Models;
using Assignment1.DomainLayer.Modules;
using Assignment1.Exceptions;
using Assignment1.PresentationLayer.Interfaces;

namespace Assignment1.PresentationLayer.HelperClasses
{
    class LoginHelperClass
    {
        #region Properties
        private readonly ConnectionModule _connectionModule;
        private IDisplayWindowService DisplayWindowService { get; set; }
        private Command DisplayWindow { get; set; }
        private Lazy<MainWindow> _mainWindow;
        private Lazy<AdminWindow> _adminWindow;
        private readonly EmployeesModule _employeesModule;
        private Employee AuthEmployee { get; set; }
        #endregion

        #region Constructors
        public LoginHelperClass(string connectionString)
        {
            this._employeesModule = new EmployeesModule(connectionString);
            this._connectionModule = new ConnectionModule(connectionString);
            DisplayWindowService = new WPFDisplayWindowService();
            _mainWindow = new Lazy<MainWindow>(BuildMainWindow);
            _adminWindow = new Lazy<AdminWindow>(BuildAdminWindow);
        }
        #endregion

        public void LogIn(ValidationResult validationResult, string username, string password, string userType)
        {
            AuthenticationPageHelper.CheckIfInputCredentialsAreValid(validationResult);

            ExecuteLoginOperation(validationResult, username, password, userType);
            if (userType.Equals("admins"))
            {
                DisplayWindow = new Command(() => DisplayWindowService.DisplayAdminWindow());
                DisplayWindow.ExecuteCommand();
            }
            else
            {
                AuthEmployee = _employeesModule.GetEmployeeByUsername(username).FirstOrDefault();
                DisplayWindow = new Command(() => DisplayWindowService.DisplayMainWindow(AuthEmployee));
                DisplayWindow.ExecuteCommand();
            }
        }

		private void ExecuteLoginOperation(ValidationResult inputValidationResult, string username, string password, string userType)
        {
            try
            {
                _connectionModule.AuthenticateUser(username, password, userType);
            }
            catch (DbAuthenticationException ex)
            {
                throw new FailedAuthenticationConnectionException(ex.Message);
            }
        }

        private MainWindow BuildMainWindow() => new MainWindow(AuthEmployee);

        private AdminWindow BuildAdminWindow() => new AdminWindow();
    }
}
