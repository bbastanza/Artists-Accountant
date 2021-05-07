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
        private readonly ISqlQuery _sqlQuery;
        private readonly IArtworkSqlBuilder _sqlBuilder;

        public PatchArtWork(
            ISqlQuery sqlQuery,
            IArtworkSqlBuilder sqlBuilder)
        {
            _sqlQuery = sqlQuery;
            _sqlBuilder = sqlBuilder;
        }

        public void Edit(ArtWork artwork)
        {
            var query = _sqlBuilder.GenerateUpdateStatement(artwork);

            _sqlQuery.ExecuteVoid(query);
        }
    }
}