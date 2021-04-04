namespace Infrastructure.Exceptions
{
    public class SqlException : ArtistException
    {
        public SqlException(string path, string method)
            :base(path,method, "Exception interacting with database", "Sorry, There was a error with your request. Please try again.")
        {
        }
    }
}
