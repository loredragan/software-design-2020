using Assignment_2.Models;
using Assignment_2.View.HelperClasses;
using Assignment_2.View.Interfaces;
using Assignment_2.ViewModel.Exceptions;
using Assignment_2.ViewModel.HelperClasses;
using Assignment_2.ViewModel.Interfaces;
using Assignment_2.ViewModels.HelperClasses;
using Assignment_2.Views.Interfaces;
using System.Messaging;

namespace Assignment_2.ViewModel.ViewModels
{
     class AuthenticationViewModel
    {
        #region Properties
        public IMessageBoxService MessageBoxService { get; set; }
        public IDisplayWindowService DisplayWindowService { get; set; }
        private Command<string> _showMessage { get; set; }
        private ISecurityConnector _securityConnector { get; set; }
        private Command DisplayMenuWindowCommand { get; set; }
        #endregion

        #region Constructors
        public AuthenticationViewModel(IMessageBoxService messageBoxService, IDisplayWindowService displayWindowService, string userType)
        {
            MessageBoxService = messageBoxService;
            DisplayWindowService = displayWindowService;
            _securityConnector = new SecurityConnector();
        }
        #endregion

        #region Login
        private BaseModel ExecuteLoginOperation(ValidationResult inputValidationResult, string username, string password, string userType)
        {
            AuthenticationPageHelper.CheckIfInputCredentialsAreValid(inputValidationResult);
            BaseModel isAuthenticated;

            try
            {
                isAuthenticated = _securityConnector.AuthenticateUsers(username, password, userType);

                return isAuthenticated;
            }
            catch(FailedAuthenticationException ex)
            {
                throw new FailedAuthenticationException(ex.Message);
            }
        }

        public BaseModel Login(ValidationResult validationResult, string username, string password, string userType)
        {
            var isAuthenticated = ExecuteLoginOperation(validationResult, username, password, userType);

            if (userType.Equals("admins"))
            {
                DisplayMenuWindowCommand = new Command(() => DisplayWindowService.DisplayAdminWindow(isAuthenticated as Admin));
                DisplayMenuWindowCommand.ExecuteCommand();
            }
            else
            {
                DisplayMenuWindowCommand = new Command(() => DisplayWindowService.DisplayUserWindow(isAuthenticated as User));
                DisplayMenuWindowCommand.ExecuteCommand();
            }

            return isAuthenticated;
        }
        #endregion

        public void ShowMessageWindow(string message)
        {
            _showMessage = new Command<string>(delegate (string s) { MessageBoxService.ShowMessage(message, MessageType.Acknowledgment); });
            _showMessage.ExecuteCommand();
        }
    }
}
