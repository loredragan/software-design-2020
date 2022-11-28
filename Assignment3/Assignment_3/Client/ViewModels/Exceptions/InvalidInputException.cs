using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.Exceptions
{
    class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
