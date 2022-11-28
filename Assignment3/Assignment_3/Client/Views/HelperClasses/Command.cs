using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Views.HelperClasses
{
    class Command : ICommand
    {

        #region Properties
        private readonly Action _action;
        #endregion

        #region Constructors
        public Command(Action action)
        {
            _action = action;
        }
        #endregion

        public void Execute(object parameter)
        {
            _action();
        }

        public void ExecuteCommand()
        {
            Execute(null);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 67
    }

    public class Command<T> : ICommand
    {
        #region Properties
        private readonly Action<T> _action;
        #endregion

        #region Constructor
        public Command(Action<T> action)
        {
            _action = action;
        }
        #endregion

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }

        public void ExecuteCommand()
        {
            Execute(null);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        //67 An event was declared but never used in the class in which it was declared.
        //supress warning
#pragma warning disable 67
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 67
    }
}
