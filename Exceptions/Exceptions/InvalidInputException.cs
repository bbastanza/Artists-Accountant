namespace Infrastructure.Exceptions
{
    public class InvalidInputException : ArtistException
    {
        public InvalidInputException(string path, string method)
            : base(path,method,"Invalid Input", "Please fill out all fields.")
        {
        }
    }
}