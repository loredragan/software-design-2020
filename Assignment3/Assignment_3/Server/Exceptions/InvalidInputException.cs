using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Exceptions
{
    class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
