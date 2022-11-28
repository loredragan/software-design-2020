using FinalProject.Models;
using Server.Exceptions;
using Server.Repository;
using Server.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestHandler.Users
{
    class RegularUserChatsHandler : RegularUserHandler
    {
        #region Private Members
        private readonly FinalProjectEntities _context;
        private readonly IRepository<ChatMessage> _messagesRepository;
        private readonly IRepository<User> _usersRepository;
        #endregion

        #region Constructors
        public RegularUserChatsHandler()
        {
            this._context = new FinalProjectEntities();
            this._messagesRepository = new Repository<ChatMessage>(_context);
            this._usersRepository = new Repository<User>(_context);
        }
        #endregion


        #region Exposed Methods
        public IEnumerable<ChatMessage> GetInbox(IDictionary<string, string> valuePairs, int userId)
        {
            var userMessages = _messagesRepository.GetAll().Where(s => s.userId == userId).ToList();

            return userMessages;
        }

        public void SendMessage(IDictionary<string, string> valuePairs, int userId)
        {
            var userID = Convert.ToInt32(valuePairs["userId"]);
            var exists = _usersRepository.GetAll().Where(s => s.id == userID).ToList();

            if (!exists.Any())
            {
                throw new NoResultException("No user with this ID exists");
            }

            var sender = _usersRepository.GetAll().Where(s => s.id == userId).ToList();
            var senderName = sender.First().name;

            var newMessage = new ChatMessage()
            {
                fromUserId = userId, //pun la fromuser idul celui care trimit pentru ca atunci cand voi afisa la cineva, fromUser
                                   //va afisa id-ul celui care a trimis mesajul
                userId = userID, //cui trimit
                message = valuePairs["messageContent"],
                fromUserName = senderName //
            };

            _messagesRepository.Insert(newMessage);
        }
        #endregion
    }
}
