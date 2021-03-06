namespace Infrastructure.Exceptions
{
    public class NonExistingUserException : ArtistException
    {
        public NonExistingUserException(string path, string method) 
            : base(path, method, "User does not exists", "Sorry, the user you are trying to use does not exist. Please try again.")
        {
        }
    }
}
