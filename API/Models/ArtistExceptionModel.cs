using Infrastructure.Exceptions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace API.Models
{
    public class ArtistExceptionModel
    {
        public ArtistExceptionModel(ArtistException ex)
        {
            ClientMessage = $"{ex.ClientMessage}";
        }
        
        public string ClientMessage { get; }
        
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}