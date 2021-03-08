using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
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
        private readonly IGetUserData _getUserData;
        private readonly ISqlServer _sqlServer;
        private readonly string _path;

        public AddUser(
            IGetUserData getUserData,
            ISqlServer sqlServer)
        {
            _getUserData = getUserData;
            _sqlServer = sqlServer;
            _path = Path.GetFullPath(ToString());
        }

        public void Add(string username, string password)
        {
            var existingUser = _getUserData.GetUser(username);
            
            if (existingUser != null)
                throw new ExistingUserException(_path, "Add()");

            var user = new User(username, password);

            var connection = _sqlServer.Connect();

            var query = new StringBuilder();
            query.Append("INSERT INTO user_table (username, password, date_created) VALUES");
            query.Append($" ('{user.Username}', '{user.Password}', CURRENT_TIMESTAMP);");

            try
            {
                using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                _sqlServer.CloseConnection();
            }
        }
    }
}