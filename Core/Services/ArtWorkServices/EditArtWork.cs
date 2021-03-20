using System;
using System.Data.SqlClient;
using System.IO;
using Core.Entities;
using Core.Services.DbServices;

namespace Core.Services.ArtWorkServices
{
    public interface IEditArtWork
    {
        void Edit(ArtWork artwork);
    }

    public class EditArtWork : IEditArtWork
    {
        private readonly ISqlServer _sqlServer;
        private readonly string _path;

        public EditArtWork(ISqlServer sqlServer)
        {
            _sqlServer = sqlServer;
            _path = Path.GetFullPath(ToString());
        }

        public void Edit(ArtWork artwork)
        {
            var connection = _sqlServer.Connect();

            var sqlBuilder = new ArtworkSqlBuilder();

            var query =
                $"UPDATE artwork_table " +
                $"SET " +
                sqlBuilder.GetSqlSet(artwork) +
                $"WHERE id = {artwork.Id};";

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
