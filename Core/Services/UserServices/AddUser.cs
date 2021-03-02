using System;
using Core.Entities;
using Core.Services.DbServices;

namespace Core.Services.UserServices
{
    public interface IAddUser
    {
        void Add(string username, string password);
    }
    
    public class AddUser : IAddUser
    {
        private readonly IQueryDbService _queryDbService;

        public AddUser(IQueryDbService queryDbService)
        {
            _queryDbService = queryDbService;
        }

        public void Add(string username, string password)
        {
            var existingUser = _queryDbService.CheckExisting(username);
            
            // TODO custom exception class
            if (existingUser)
                  throw new Exception("existing user");

            var user = new User(username, password);

            _queryDbService.AddUser(user);
        }
    }
}