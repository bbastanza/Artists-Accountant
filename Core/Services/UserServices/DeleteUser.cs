using System;
using Core.Services.DbServices;

namespace Core.Services.UserServices
{
    public interface IDeleteUser
    {
        void Delete(string username);
    }
    
    public class DeleteUser: IDeleteUser
    {
        private readonly IQueryDbService _queryDbService;

        public DeleteUser(IQueryDbService queryDbService)
        {
            _queryDbService = queryDbService;
        }
        public void Delete(string username)
        {
            var existingUser = _queryDbService.CheckExisting(username);
            
            // TODO custom exception class
            if (!existingUser)
                  throw new Exception("non-existing user");

            _queryDbService.DeleteUser(username);
        }
        
    }
}