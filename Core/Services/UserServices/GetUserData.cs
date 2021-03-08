using System;
using System.Data.SqlClient;
using System.Text;
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

            var query = new StringBuilder();
            query.Append($"SELECT * FROM user_table WHERE username = '{username}'");

            try
            {
                using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var user = new User();
                                user.Username = reader.GetString(reader.GetOrdinal("username"));
                                user.Password = reader.GetString(reader.GetOrdinal("password"));
                                user.CreatedAt = reader.GetDateTime(reader.GetOrdinal("date_created"));
                                return user;
                            }
                        }
                    }
                }
            }
            finally
            {
                _sqlServer.CloseConnection();
            }

            return null;
        }
    }
}