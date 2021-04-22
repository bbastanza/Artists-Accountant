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

        public DeleteArtWork(ISqlQuery sqlQuery)
        {
            _sqlQuery = sqlQuery;
        }

        public void Delete(int? id)
        {
            var query = $"DELETE FROM artwork_table WHERE id = {id}";

            _sqlQuery.ExecuteVoid(query);
        }
    }
}