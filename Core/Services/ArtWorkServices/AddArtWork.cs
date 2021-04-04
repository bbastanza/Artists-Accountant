using System.Data.SqlClient;
using System.IO;
using Core.Entities;
using Core.Services.DbServices;
using Core.Services.SqlBuilders;
using Infrastructure.Exceptions;
using SqlException = Infrastructure.Exceptions.SqlException;

namespace Core.Services.ArtWorkServices
{
    public interface IAddArtWork
    {
        void Add(ArtWork artWork);
    }

    public class AddArtWork : IAddArtWork
    {
        private readonly ISqlServer _sqlServer;
        private readonly string _path;

        public AddArtWork(ISqlServer sqlServer)
        {
            _sqlServer = sqlServer;
            _path = Path.GetFullPath(ToString());
        }

        public void Add(ArtWork artWork)
        {
            var connection = _sqlServer.Connect();

            var sqlBuilder = new ArtworkSqlBuilder();

            var query = sqlBuilder.GenerateInsertStatement(artWork);

            try
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new SqlException(_path, "Delete(artwork)");
            }
            finally
            {
                _sqlServer.CloseConnection();
            }
        }
    }
}