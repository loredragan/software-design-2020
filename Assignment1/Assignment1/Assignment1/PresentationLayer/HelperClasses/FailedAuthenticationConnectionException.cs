using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.PresentationLayer.HelperClasses
{
    class FailedAuthenticationConnectionException: Exception
    {
        public FailedAuthenticationConnectionException(string message) : base(message) { }
    }
}
