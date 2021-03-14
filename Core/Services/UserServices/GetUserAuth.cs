using System.Data.SqlClient;
using System.Linq;
using Core.Entities;
using Core.ExtensionMethods;
using Core.Services.DbServices;

namespace Core.Services.UserServices
{
    public interface IGetUserAuth
    {
        User Get(string username);
    }

    public class GetUserAuth : IGetUserAuth
    {
        private readonly ISqlServer _sqlServer;

        public GetUserAuth(ISqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }


        public User Get(string username)
        {
            var connection = _sqlServer.Connect();

            var query = $"SELECT username, password FROM user_table WHERE username = '{username}';";

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            return new User
                            {
                                Username = reader.GetDefaultString("username"),
                                Password = reader.GetDefaultString("password")
                            };
                        }
                }
            }

            return null;
        }
    }
}