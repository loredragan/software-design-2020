using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModel.Exceptions
{
    [Serializable]
    class FailedAuthenticationException : Exception
    {
        public FailedAuthenticationException(string message) : base(message) { }
    }
}
