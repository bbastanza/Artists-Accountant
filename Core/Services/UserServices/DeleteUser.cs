using System.Data.SqlClient;
using System.IO;
using Core.Services.DbServices;
using Infrastructure.Exceptions;

namespace Core.Services.UserServices
{
    public interface IDeleteUser
    {
        void Delete(string username);
    }

    public class DeleteUser : IDeleteUser
    {
        private readonly IGetUserData _getUserData;
        private readonly ISqlServer _sqlServer;
        private readonly string _path;

        public DeleteUser(
            IGetUserData getUserData,
            ISqlServer sqlServer)
        {
            _getUserData = getUserData;
            _sqlServer = sqlServer;
            _path = Path.GetFullPath(ToString());
        }

        public void Delete(string username)
        {
            var existingUser = _getUserData.GetUser(username);

            if (existingUser == null)
                throw new NonExistingUserException(_path, "Delete()");

            var connection = _sqlServer.Connect();
            
            var query = $"DELETE FROM user_table WHERE username = '{username}'";

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