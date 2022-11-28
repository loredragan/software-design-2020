using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Client.Views.Interfaces
{
    public interface IMessageBoxService
    {
        void ShowMessage(string text, MessageType message);
    }
}
