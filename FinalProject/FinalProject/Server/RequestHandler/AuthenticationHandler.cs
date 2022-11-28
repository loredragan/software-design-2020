using FinalProject.Models;
using Server.Exceptions;
using Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestHandler
{
    class AuthenticationHandler
    {
        #region Properties
        private readonly FinalProjectEntities _context;
        private readonly Repository<Admin> _adminsRepository;
        private readonly Repository<User> _usersRepository;
        #endregion

        #region Constructor
        public AuthenticationHandler()
        {
            this._context = new FinalProjectEntities();
            this._adminsRepository = new Repository<Admin>(_context);
            this._usersRepository = new Repository<User>(_context);
        }
        #endregion

        public BaseModel AuthenticateUser(IDictionary<string, string> valuePairs, string userType)
        {
            var username = valuePairs["username"];
            var password = valuePairs["password"];
            //pair.key = username
            //pair.val = pass
            if (userType.Equals("admins"))
            {
                var result = _adminsRepository.GetAll().Where(s => s.password.Equals(password))
                    .Where(s => s.username.Equals(username)).ToList();
                if (!result.Any())
                    throw new FailedAuthenticationException("Invalid username or password");

                return result.FirstOrDefault();
            }
            else
            {
                var result = _usersRepository.GetAll().Where(s => s.password.Equals(password))
                    .Where(s => s.username.Equals(username)).ToList();
                if (!result.Any())
                    throw new FailedAuthenticationException("Invalid username or password");

                return result.FirstOrDefault();
            }
        }
    }
}
