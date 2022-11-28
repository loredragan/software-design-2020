using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Exceptions
{
    [Serializable]
    class NoResultException : Exception
    {
        public NoResultException(string message) : base(message) { }
    }
}
