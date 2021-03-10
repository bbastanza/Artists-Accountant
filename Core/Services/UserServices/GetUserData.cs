using System.Data.SqlClient;
using Core.Entities;
using Core.Services.ArtWorkServices;
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
        private readonly IGetArtWorks _getArtworks;

        public GetUserData(
            ISqlServer sqlServer,
            IGetArtWorks getArtworks = null)
        {
            _sqlServer = sqlServer;
            _getArtworks = getArtworks;
        }

        public User GetUser(string username)
        {
            var connection = _sqlServer.Connect();

            var query = $"SELECT * FROM user_table WHERE username = '{username}'";

            User user = null;

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            user = new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Username = reader.GetString(reader.GetOrdinal("username")),
                                Password = reader.GetString(reader.GetOrdinal("password")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("date_created"))
                            };
                        }
            }

            if (user != null && _getArtworks != null)
                user.ArtWorks = _getArtworks.GetAll(user.Id, connection);

            _sqlServer.CloseConnection();
            return user;
        }
    }
}