namespace API.Models
{
    public class UserAuthModel
    {
        public int? Id { get; set; }
        public string JwtToken { get; set; }
        public string Username { get; set; }
        public string ProfileImgUrl { get; set; }
    }
}