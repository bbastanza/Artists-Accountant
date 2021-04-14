using System.IO;
using Core.Services.DbServices;
using Infrastructure.Exceptions;

namespace Core.Services.UserServices
{
    public interface IDeleteUser
    {
        void Delete(int? id);
    }

    public class DeleteUser : IDeleteUser
    {
        private readonly IGetUserData _getUserData;
        private readonly ISqlQuery _sqlQuery;
        private readonly string _path;

        public DeleteUser(
            IGetUserData getUserData,
            ISqlQuery sqlQuery
        )
        {
            _getUserData = getUserData;
            _sqlQuery = sqlQuery;
            _path = Path.GetFullPath(ToString());
        }

        public void Delete(int? id)
        {
            var existingUser = _getUserData.GetDataWithoutArtworks(id);

            if (existingUser == null)
                throw new NonExistingUserException(_path, "Delete()");

            var deleteUserArtworksQuery = $"DELETE FROM artwork_table WHERE user_id = {id};";
            
            var deleteUserQuery = $"DELETE FROM user_table WHERE id = {id};";

           _sqlQuery.ExecuteDoubleVoid(deleteUserArtworksQuery, deleteUserQuery); 
        }
    }
}