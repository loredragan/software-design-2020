using Client.ViewModels.Exceptions;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.HelperClasses.AuthenticateUser;
using Client.ViewModels.Interfaces;
using Client.Views.HelperClasses;
using Client.Views.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.ViewModels
{
    class AuthenticationViewModel
    {
        #region Exposed Members
        public IMessageBoxService MessageBoxService { get; set; }
        public IDisplayWindowService DisplayWindowService { get; set; }
        #endregion

        #region Private Members
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

        #region Private Methods
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
            catch (FailedAuthenticationException ex)
            {
                throw new FailedAuthenticationException(ex.Message);
            }
        }

        public BaseModel Login(ValidationResult validationResult, string username, string password, string userType)
        {
            var isAuthenticated = ExecuteLoginOperation(validationResult, username, password, userType);

            if (userType.Equals("admins"))
            {
                DisplayMenuWindowCommand = new Command(() => DisplayWindowService.DisplayAdminWindow(isAuthenticated as FinalProject.Models.Admin));
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
        #endregion

        #region Public Methods
        public void ShowMessageWindow(string message)
        {
            _showMessage = new Command<string>(delegate (string s) { MessageBoxService.ShowMessage(message, MessageType.Acknowledgment); });
            _showMessage.ExecuteCommand();
        }
        #endregion
    }
}
