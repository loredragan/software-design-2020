using Client.ViewModels.Interfaces;
using Client.Views.HelperClasses;
using Client.Views.Interfaces;
using FinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.ViewModels.Admin
{
    class AdminViewModel<TModel>
       where TModel : class, IModel
    {

        #region Private Members
        private IMessageBoxService MessageBoxService { get; set; }
        private Command<string> ShowMessage { get; set; }
        protected IValidator Validator { get; set; }
        #endregion

        #region Constructors
        public AdminViewModel(IMessageBoxService messageBoxService, IValidator validator)
        {
            MessageBoxService = messageBoxService;
            Validator = validator;
        }
        #endregion

        public void ShowMessageWindow(string message)
        {
            ShowMessage = new Command<string>((s) => MessageBoxService.ShowMessage(message, MessageType.Acknowledgment));
            ShowMessage.ExecuteCommand();
        }
    }
}
