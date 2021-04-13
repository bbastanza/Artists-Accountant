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
        private readonly ISqlQuery _sqlQuery;
        private readonly string _path;

        public DeleteArtWork(ISqlServer sqlServer, ISqlQuery sqlQuery)
        {
            _sqlQuery = sqlQuery;
            _path = Path.GetFullPath(ToString());
        }

        public void Delete(int? id)
        {
            var query = $"DELETE FROM artwork_table WHERE id = {id}";

            _sqlQuery.ExecuteVoid(query);
        }
    }
}