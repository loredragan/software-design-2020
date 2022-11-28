using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views.Interfaces
{
    public interface IMessageBoxService
    {
        void ShowMessage(string text, MessageType message);
    }
}
