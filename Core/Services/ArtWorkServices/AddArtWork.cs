using Core.Entities;
using Core.Services.DbServices;
using Core.Services.SqlBuilders;

namespace Core.Services.ArtWorkServices
{
    public interface IAddArtWork
    {
        void Add(ArtWork artWork);
    }

    public class AddArtWork : IAddArtWork
    {
        private readonly ISqlQuery _sqlQuery;
        private readonly IArtworkSqlBuilder _sqlBuilder;

        public AddArtWork(
            ISqlQuery sqlQuery,
            IArtworkSqlBuilder sqlBuilder)
        {
            _sqlQuery = sqlQuery;
            _sqlBuilder = sqlBuilder;
        }

        public void Add(ArtWork artWork)
        {
            var query = _sqlBuilder.GenerateInsertStatement(artWork);

            _sqlQuery.ExecuteVoid(query);
        }
    }
}