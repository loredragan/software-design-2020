using Assignment_2.Model;
using Assignment_2.Models;
using Assignment_2.Models.Repository;
using Assignment_2.Models.Repository.Interfaces;
using Assignment_2.View.HelperClasses;
using Assignment_2.ViewModels.Interfaces;
using Assignment_2.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels
{
    class AdminViewModel<TModel> : IDisposable
        where TModel: class, IModel
    {
        #region Properties
        protected Assignment2Entities Context { get; set; }
        private IMessageBoxService MessageBoxService { get; set; }
        private Command<string> ShowMessage { get; set; }
        protected IValidator Validator { get; set; }
        protected IRepository<TModel> Repository { get; set; }
        #endregion

        #region Constructors
        public AdminViewModel(IMessageBoxService messageBoxService, IValidator validator)
        {
            Context = new Assignment2Entities();
            MessageBoxService = messageBoxService;
            Validator = validator;
            Repository = new Repository<TModel>(Context);
        }
        #endregion

        public virtual void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

        public void ShowMessageWindow(string message)
        {
            ShowMessage = new Command<string>((s) => MessageBoxService.ShowMessage(message, MessageType.Acknowledgment));
            ShowMessage.ExecuteCommand();
        }
    }
}
