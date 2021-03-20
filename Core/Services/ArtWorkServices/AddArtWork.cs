using System;
using System.Data.SqlClient;
using Core.Entities;
using Core.Services.DbServices;
using Core.Services.UserServices;

namespace Core.Services.ArtWorkServices
{
    public interface IAddArtWork
    {
        void Add(ArtWork artWork);
    }

    public class AddArtWork : IAddArtWork
    {
        private readonly IGetUserData _getUserData;
        private readonly ISqlServer _sqlServer;

        public AddArtWork(
            IGetUserData getUserData,
            ISqlServer sqlServer)
        {
            _getUserData = getUserData;
            _sqlServer = sqlServer;
        }

        public void Add(ArtWork artWork)
        {
            var user = _getUserData.GetUser(artWork.Username);

            var connection = _sqlServer.Connect();

            var sqlBuilder = new ArtworkSqlBuilder();
            var properties = sqlBuilder.GetSqlProperties(artWork);
            var values = sqlBuilder.GetSqlValues(artWork);

            var query =
                $"INSERT INTO artwork_table (user_id" +
                $"{(properties.Length > 0 ? $", {properties}" : "")}" +
                $") VALUES ({user.Id}" +
                $"{(values.Length > 0 ? $", {values}" : "")});";

            try
            {
                using (var command = new SqlCommand(query, connection))
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