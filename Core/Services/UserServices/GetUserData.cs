using System.Data.SqlClient;
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
        private readonly ISqlServer _sqlServer;

        public GetUserData(ISqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public User GetUser(string username)
        {
            var connection = _sqlServer.Connect();

            var query =$"SELECT * FROM user_table WHERE username = '{username}'";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var user = new User
                                {
                                    Username = reader.GetString(reader.GetOrdinal("username")),
                                    Password = reader.GetString(reader.GetOrdinal("password")),
                                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("date_created"))
                                };
                                return user;
                            }
                        }
                    }
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

            return null;
        }
    }
}