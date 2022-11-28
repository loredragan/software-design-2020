using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.Interfaces;
using Client.Views.HelperClasses;
using Client.Views.Interfaces;

namespace Client.ViewModels.ViewModels.RegularUser
{
    public class RegularUserViewModel<TModel> 
        where TModel : class, IModel
    {
        #region Properties
        private IMessageBoxService MessageBoxService { get; set; }
        private Command<string> ShowMessage { get; set; }
        protected IValidator Validator { get; set; }
        #endregion

        #region Constructors
        public RegularUserViewModel(IMessageBoxService messageBoxService, IValidator validator)
        {
            MessageBoxService = messageBoxService;
            Validator = validator;
        }

        //pentru TESTE
        //public RegularUserViewModel(IRepository<TModel> repository)
        //{
        //    MessageBoxService = new WPFMessageBoxService();
        //    Validator = new FilterValidator<TModel>();
        //}
        #endregion

        public void ShowMessageWindow(string message)
        {
            ShowMessage = new Command<string>((s) => MessageBoxService.ShowMessage(message, MessageType.Acknowledgment));
            ShowMessage.ExecuteCommand();
        }
    }
}
