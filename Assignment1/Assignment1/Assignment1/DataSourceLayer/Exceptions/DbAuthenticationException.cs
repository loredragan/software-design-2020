using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Exceptions
{
    class DbAuthenticationException : DbException
    {
        #region Constructors
        public DbAuthenticationException(string message) : base(message) { }

        public DbAuthenticationException() : base() { }
        #endregion
    }
}
