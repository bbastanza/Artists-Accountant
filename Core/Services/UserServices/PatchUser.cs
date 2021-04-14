using System.IO;
using Core.Entities;
using Core.Services.DbServices;
using Core.Services.SqlBuilders;
using Infrastructure.Exceptions;

namespace Core.Services.UserServices
{
    public interface IPatchUser
    {
        User Edit(User user);
    }

    public class PatchUser : IPatchUser
    {
        private readonly IGetUserData _getUserData;
        private readonly IUserSqlBuilder _sqlBuilder;
        private readonly ISqlQuery _sqlQuery;
        private readonly string _path;

        public PatchUser(
            IGetUserData getUserData,
            IUserSqlBuilder sqlBuilder, 
            ISqlQuery sqlQuery
        )
        {
            _getUserData = getUserData;
            _sqlBuilder = sqlBuilder;
            _sqlQuery = sqlQuery;
            _path = Path.GetFullPath(ToString());
        }

        public User Edit(User user)
        {
            var currentUser = _getUserData.GetDataWithoutArtworks(user.Id);

            if (currentUser == null)
                throw new NonExistingUserException(_path, "Edit()");

            if (currentUser.Username == user.Username &&
                currentUser.Password == user.Password &&
                currentUser.ProfileImgUrl == user.ProfileImgUrl) return user;

            var query = _sqlBuilder.GenerateUpdateStatement(user);

            _sqlQuery.ExecuteVoid(query);

            return user;
        }
    }
}