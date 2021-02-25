using System.Text.Json.Serialization;

namespace API.Models
{
    public class UserInputModel
    {
        [JsonPropertyName("userName")]
        public virtual string UserName { get; set; }
        [JsonPropertyName("password")]
        public virtual string Password { get; set; }
        [JsonPropertyName("email")]
        public virtual string Email { get; set; }
    }
}