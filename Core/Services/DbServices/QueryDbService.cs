using Core.Entities;

namespace Core.Services.DbServices
{
    public interface IQueryDbService
    {
        bool CheckExisting(string username);
        User GetUser(string username);
        void AddUser(User user);
        void DeleteUser(string username);
        void ChangeUser(string username, string password);
    }
    
    public class QueryDbService : IQueryDbService
    {
        public bool CheckExisting(string username)
        {
            // TODO | var user = $"SELECT username FROM user_table WHERE username = {username};";
            //        return user == null ? false : true;
            return false;
        }

        public User GetUser(string username)
        {
            // TODO | return $"SELECT * FROM user_table WHERE username = {username};";
            return new User(username, "password");
        }

        public void AddUser(User user)
        {
            // TODO | $"INSERT INTO user_table (username, password, created_at)
            //          VALUES ({user.Username}, {user.Password}, {user.CreatedAt});";
        }

        public void DeleteUser(string username)
        {
            // TODO | $"DELETE FROM user_table WHERE username = {username};";
        }

        public void ChangeUser(string username, string password)
        {
            // check username and password for null before updating the user
            // TODO | change statement
        }
    }
}