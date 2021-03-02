using System;
using Core.Services.DbServices;

namespace Core.Services.UserServices
{
    public interface IEditUser
    {
        void Edit(string username, string password);
    }

    public class EditUser : IEditUser
    {
        private readonly IQueryDbService _queryDbService;

        public EditUser(IQueryDbService queryDbService)
        {
            _queryDbService = queryDbService;
        }
        
        public void Edit(string username, string password)
        {
            var user = _queryDbService.GetUser(username);

            // TODO custom exception class
            if (user == null)
                throw new Exception("non-existing user");

            if (user.Username != username || user.Password != password)
                _queryDbService.ChangeUser(username, password);
        }
    }
}