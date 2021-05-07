using System;
using System.IO;
using Core.Entities;
using Core.Services.DbServices;
using Infrastructure.Exceptions;

namespace Core.Services.UserServices
{
    public interface IAddUser
    {
        void CreateUser(string username, string password);
    }

    public class AddUser : IAddUser
    {
        private readonly IGetUserAuth _getUserData;
        private readonly ISqlQuery _sqlQuery;
        private readonly string _path;

        public AddUser(
            IGetUserAuth getUserData,
            ISqlQuery sqlQuery)
        {
            _getUserData = getUserData;
            _sqlQuery = sqlQuery;
            _path = Path.GetFullPath(ToString());
        }

        public void CreateUser(string username, string password)
        {
            var existingUser = _getUserData.Get(username);

            if (existingUser != null)
                throw new ExistingUserException(_path, "Add()");

            var user = new User
            {
                Username = username,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                CreatedAt = DateTime.Now,
            };

            var query =
                $"INSERT INTO user_table (username, password, date_created) " +
                $"VALUES ('{user.Username}', '{user.Password}', '{user.CreatedAt}');";

            _sqlQuery.ExecuteVoid(query);
        }
    }
}