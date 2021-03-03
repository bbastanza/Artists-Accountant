using Core.Entities;

namespace Core.Services.UserServices
{
    public interface IGetUserData
    {
        User GetUser(string username);
    }
    
    public class GetUserData : IGetUserData
    {
        public User GetUser(string username)
        {
            // TODO | return $"SELECT * FROM user_table WHERE username = {username};";
            // 
            // temporary
            return new User(username, "password");
            // 
        }
    }
}