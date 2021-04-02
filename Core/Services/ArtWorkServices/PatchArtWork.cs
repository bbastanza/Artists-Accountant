using System;
using System.Data.SqlClient;
using System.IO;
using Core.Entities;
using Core.Services.DbServices;
using Core.Services.SqlBuilders;

namespace Core.Services.ArtWorkServices
{
    public interface IPatchArtWork
    {
        void Edit(ArtWork artwork);
    }

    public class PatchArtWork : IPatchArtWork
    {
        private readonly ISqlServer _sqlServer;
        private readonly IArtworkSqlBuilder _sqlBuilder;
        private readonly string _path;

        public PatchArtWork(
            ISqlServer sqlServer,
            IArtworkSqlBuilder sqlBuilder)
        {
            _sqlServer = sqlServer;
            _sqlBuilder = sqlBuilder;
            _path = Path.GetFullPath(ToString());
        }

        public void Edit(ArtWork artwork)
        {
            var connection = _sqlServer.Connect();

            var query = _sqlBuilder.GenerateUpdateStatement(artwork);

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
