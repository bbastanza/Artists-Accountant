using System.IO;
using Core.Entities;
using Infrastructure.Exceptions;

namespace Core.Services.UserServices
{
    public interface IAddUser
    {
        void Add(string username, string password);
    }
    
    public class AddUser : IAddUser
    {
        private readonly IGetUserData _getUserData;
        private readonly string _path;

        public AddUser(IGetUserData getUserData)
        {
            _getUserData = getUserData;
            _path = Path.GetFullPath(ToString());
        }

        public void Add(string username, string password)
        {
            var existingUser = _getUserData.GetUser(username);
            
            if (existingUser != null)
                  throw new ExistingUserException(_path, "Add()");

            var user = new User(username, password);

            // TODO | $"INSERT INTO user_table (username, password, created_at)
            //          VALUES ({user.Username}, {user.Password}, {user.CreatedAt});";
        }
    }
}