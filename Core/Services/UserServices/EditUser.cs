using System;
using System.IO;
using Infrastructure.Exceptions;

namespace Core.Services.UserServices
{
    public interface IEditUser
    {
        void Edit(string username, string password);
    }

    public class EditUser : IEditUser
    {
        private readonly IGetUserData _getUserData;
        private readonly string _path;

        public EditUser(IGetUserData getUserData)
        {
            _getUserData = getUserData;
            _path = Path.GetFullPath(ToString());
        }

        public void Edit(string username, string password)
        {
            var user = _getUserData.GetUser(username);

            // TODO custom exception class
            if (user == null)
                throw new NonExistingUserException(_path, "Edit()");

            if (user.Username != username || user.Password != password)
            {
                // check username and password for null before updating the user
                // TODO | change statement
            }
        }
    }
}