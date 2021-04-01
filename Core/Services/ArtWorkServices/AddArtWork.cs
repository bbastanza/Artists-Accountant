using System;
using System.Data.SqlClient;
using Core.Entities;
using Core.Services.DbServices;
using Core.Services.SqlBuilders;
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
            var connection = _sqlServer.Connect();

            var sqlBuilder = new ArtworkSqlBuilder();

            var query = sqlBuilder.GenerateInsertStatement(artWork);
            Console.WriteLine(query);

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