using Client.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses.RegularUserChats
{
    class RegularUserChatsValidator : IValidator
    {
        public virtual ValidationResult ValidateInputsForSendMessage(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["userId"]) || valuePairs["userId"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the user you want to send a message to");
            }

            if (string.IsNullOrWhiteSpace(valuePairs["messageContent"]) || valuePairs["userId"].Equals(string.Empty))
            {
                return new ValidationResult(false, "you can't send an empty message");
            }

            var userId = 0;
            try
            {
                userId = Convert.ToInt32(valuePairs["userId"]);
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "Invalid format for userID");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
