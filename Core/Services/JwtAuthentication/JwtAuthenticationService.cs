using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services.JwtAuthentication
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string username, string password);
    }

    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly string _key;

        private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        {
            {"brian", "password"},
            {"sammy", "password2"}
        };

        public JwtAuthenticationService(string key)
        {
            _key = key;
        }

        public string Authenticate(string username, string password)
        {
            // TODO this should be making a SQL statement to see if username and password match
            
            if (!_users.Any(user => user.Key == username && user.Value == password))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}