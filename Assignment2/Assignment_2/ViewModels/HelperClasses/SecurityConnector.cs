using Assignment_2.Model;
using Assignment_2.Models;
using Assignment_2.Models.Repository;
using Assignment_2.ViewModel.Exceptions;
using Assignment_2.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModel.HelperClasses
{
    class SecurityConnector : ISecurityConnector, IDisposable
        
    {
        #region Properties
        private Assignment2Entities _context;
        private Repository<Admin> _adminsRepository;
        private Repository<User> _usersRepository;
        #endregion

        #region Constructor
        public SecurityConnector()
        {
            this._context = new Assignment2Entities();
            this._adminsRepository = new Repository<Admin>(_context);
            this._usersRepository = new Repository<User>(_context);
        }
        #endregion

        public BaseModel AuthenticateUsers(string username, string password, string userType)
        {
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

        public virtual void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
