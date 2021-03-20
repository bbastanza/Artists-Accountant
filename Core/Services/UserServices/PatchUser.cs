using System;
using System.Data.SqlClient;
using System.IO;
using Core.Entities;
using Core.Services.DbServices;
using Core.Services.SqlBuilders;
using Infrastructure.Exceptions;

namespace Core.Services.UserServices
{
    public interface IPatchUser
    {
        void Edit(User user);
    }

    public class PatchUser : IPatchUser
    {
        private readonly IGetUserData _getUserData;
        private readonly IUserSqlBuilder _sqlBuilder;
        private readonly ISqlServer _sqlServer;
        private readonly string _path;

        public PatchUser(
            IGetUserData getUserData,
            IUserSqlBuilder sqlBuilder,
            ISqlServer sqlServer)
        {
            _getUserData = getUserData;
            _sqlBuilder = sqlBuilder;
            _sqlServer = sqlServer;
            _path = Path.GetFullPath(ToString());
        }

        public void Edit(User user)
        {
            var currentUser = _getUserData.GetDataWithoutArtworks(user.Id);

            var connection = _sqlServer.Connect();

            if (currentUser == null)
                throw new NonExistingUserException(_path, "Edit()");

            if (currentUser.Username == user.Username && 
                currentUser.Password == user.Password &&
                currentUser.ProfileImgUrl == user.ProfileImgUrl) return;

            var query = _sqlBuilder.GenerateUpdateStatement(user);

            try
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlServer.CloseConnection();
            }
        }
    }
}