using System;
using System.Data.SqlClient;
using System.IO;
using Core.Entities;
using Core.Services.DbServices;
using Infrastructure.Exceptions;

namespace Core.Services.UserServices
{
    public interface IAddUser
    {
        void Add(string username, string password);
    }

    public class AddUser : IAddUser
    {
        private readonly IGetUserAuth _getUserData;
        private readonly ISqlServer _sqlServer;
        private readonly string _path;

        public AddUser(
            IGetUserAuth getUserData,
            ISqlServer sqlServer)
        {
            _getUserData = getUserData;
            _sqlServer = sqlServer;
            _path = Path.GetFullPath(ToString());
        }

        public void Add(string username, string password)
        {
            var existingUser = _getUserData.Get(username);

            if (existingUser != null)
                throw new ExistingUserException(_path, "Add()");

            var user = new User
            {
                Username = username,
                Password = password,
                CreatedAt = DateTime.Now,
            };
            

            var connection = _sqlServer.Connect();

            var query =
                $"INSERT INTO user_table (username, password, date_created) " +
                $"VALUES ('{user.Username}', '{user.Password}', '{user.CreatedAt}');";

            try
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                // TODO
            }
            finally
            {
                    _sqlServer.CloseConnection();
            }
        }
    }
}