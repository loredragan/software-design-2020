using Client.ViewModels.Connection;
using Client.ViewModels.Exceptions;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.HelperClasses.RegularUserChats;
using Client.ViewModels.Interfaces;
using Client.Views.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.ViewModels.RegularUser
{
    class RegularUserChatsViewModel : RegularUserViewModel<ChatMessage>
    {
        #region Constructors
        public RegularUserChatsViewModel(IMessageBoxService messageBoxSerivce, IValidator validator)
            : base(messageBoxSerivce, validator) { }
        #endregion

        #region Exposed Methods
        public void SendMessage(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserChatsHelper.SendMessage(valuePairs, authenticatedUser);
        }

        public IEnumerable<ChatMessage> GetInbox(IDictionary<string, string> valuePairs, int authenticatedUser)
        {
            return RegularUserChatsHelper.GetInbox(valuePairs, authenticatedUser);
        }
        #endregion
    }
}
