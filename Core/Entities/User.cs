using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfileImgUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<ArtWork> ArtWorks { get; set; } = new List<ArtWork>();
    }
}