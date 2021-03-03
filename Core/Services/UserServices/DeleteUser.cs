using System.IO;
using Infrastructure.Exceptions;

namespace Core.Services.UserServices
{
    public interface IDeleteUser
    {
        void Delete(string username);
    }
    
    public class DeleteUser: IDeleteUser
    {
        private readonly IGetUserData _getUserData;
        private readonly string _path;

        public DeleteUser(IGetUserData getUserData)
        {
            _getUserData = getUserData;
            _path = Path.GetFullPath(ToString());
        }
        public void Delete(string username)
        {
            var existingUser = _getUserData.GetUser(username);
            
            // TODO custom exception class
            if (existingUser == null)
                  throw new NonExistingUserException(_path,"Delete()");

            // TODO | $"DELETE FROM user_table WHERE username = {username};";
        }
        
    }
}