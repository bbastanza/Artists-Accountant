using System.Data.SqlClient;
using System.IO;
using Core.Services.DbServices;
using Infrastructure.Exceptions;
using SqlException = Infrastructure.Exceptions.SqlException;

namespace Core.Services.UserServices
{
    public interface IDeleteUser
    {
        void Delete(int? id);
    }

    public class DeleteUser : IDeleteUser
    {
        private readonly IGetUserData _getUserData;
        private readonly ISqlServer _sqlServer;
        private readonly string _path;

        public DeleteUser(
            IGetUserData getUserData,
            ISqlServer sqlServer
        )
        {
            _getUserData = getUserData;
            _sqlServer = sqlServer;
            _path = Path.GetFullPath(ToString());
        }

        public void Delete(int? id)
        {
            var existingUser = _getUserData.GetDataWithoutArtworks(id);

            if (existingUser == null)
                throw new NonExistingUserException(_path, "Delete()");

            var connection = _sqlServer.Connect();

            var deleteUserArtworksQuery = $"DELETE FROM artwork_table WHERE user_id = {id};";
            
            var deleteUserQuery = $"DELETE FROM user_table WHERE id = {id};";

            try
            {
                using (var command = new SqlCommand(deleteUserArtworksQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqlCommand(deleteUserQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new SqlException(_path, "Delete");
            }
            finally
            {
                _sqlServer.CloseConnection();
            }
        }
    }
}