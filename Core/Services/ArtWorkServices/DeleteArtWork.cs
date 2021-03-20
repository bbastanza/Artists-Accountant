using System.Data.SqlClient;
using System.IO;
using Core.Services.DbServices;

namespace Core.Services.ArtWorkServices
{
    public interface IDeleteArtWork
    {
        void Delete(int? id);
    }

    public class DeleteArtWork : IDeleteArtWork
    {
        private readonly ISqlServer _sqlServer;
        private readonly string _path;

        public DeleteArtWork(ISqlServer sqlServer)
        {
            _sqlServer = sqlServer;
            _path = Path.GetFullPath(ToString());
        }

        public void Delete(int? id)
        {
            var connection = _sqlServer.Connect();

            var query = $"DELETE FROM artwork_table WHERE id = {id}";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
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
        }
    }
}