using System.Text.Json.Serialization;

namespace API.Models
{
    public class UserInputModel
    {
        [JsonPropertyName("userName")]
        public virtual string Username { get; set; }
        
        [JsonPropertyName("password")]
        public virtual string Password { get; set; }
        
        [JsonPropertyName("profileImgUrl")] 
        public string ProfileImgUrl { get; set; }
    }
}