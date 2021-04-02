using System.Data.SqlClient;
using System.IO;
using Core.Entities;
using Core.ExtensionMethods;
using Core.Services.DbServices;
using Infrastructure.Exceptions;

namespace Core.Services.UserServices
{
    public interface IGetUserAuth
    {
        User Get(string username);
    }

    public class GetUserAuth : IGetUserAuth
    {
        private readonly ISqlServer _sqlServer;
        private readonly string _path;

        public GetUserAuth(ISqlServer sqlServer)
        {
            _sqlServer = sqlServer;
            _path = Path.GetFullPath(ToString());
        }

        public User Get(string username)
        {
            var connection = _sqlServer.Connect();

            var query = $"SELECT id, username, password FROM user_table WHERE username = '{username}';";

            User user = null;

            try
            {
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                user = new User
                                {
                                    Username = reader.GetDefaultString("username"),
                                    Password = reader.GetDefaultString("password")
                                };
                            }
                    }
                }
                return user;
            }
            catch
            {
                throw new NonExistingUserException(_path, "Get()");
            }
            finally
            {
                _sqlServer.CloseConnection();
            }
        }
    }
}