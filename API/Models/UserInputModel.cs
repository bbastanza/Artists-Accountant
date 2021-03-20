using System.Text.Json.Serialization;

namespace API.Models
{
    public class UserInputModel
    {
        [JsonPropertyName("id")] 
        public int? Id { get; set; }
        
        [JsonPropertyName("userName")]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
        
        [JsonPropertyName("profileImgUrl")] 
        public string ProfileImgUrl { get; set; }
    }
}