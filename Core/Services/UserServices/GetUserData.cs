using System;
using Core.Entities;
using Core.Services.DbServices;

namespace Core.Services.UserServices
{
    public interface IGetUserData
    {
        User GetUser(string username);
    }
    
    public class GetUserData : IGetUserData
    {
        private readonly IQueryDbService _queryDbService;

        public GetUserData(IQueryDbService queryDbService)
        {
            _queryDbService = queryDbService;
        }

        public User GetUser(string username)
        {
            return _queryDbService.GetUser(username);
        }
    }
}