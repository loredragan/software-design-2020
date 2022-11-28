using Client.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Views.HelperClasses
{
    public class WPFMessageBoxService : IMessageBoxService
    {
        public void ShowMessage(string text, MessageType message)
        {
            MessageBox.Show(text);
        }
    }
}
