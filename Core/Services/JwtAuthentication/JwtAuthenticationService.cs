using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities;
using Core.Services.UserServices;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services.JwtAuthentication
{
    public interface IGenerateJwtToken
    {
        string Authenticate(string username, string password);
        string NewUserToken(User user);
    }

    public class GenerateJwtToken : IGenerateJwtToken
    {
        private readonly string _key;
        private readonly IGetUserAuth _getUserAuth;

        public GenerateJwtToken(string key, IGetUserAuth getUserAuth)
        {
            _key = key;
            _getUserAuth = getUserAuth;
        }

        public string Authenticate(string username, string password)
        {
            var user = _getUserAuth.Get(username);

            if (user == null || user.Password != password)
                return null;

            return GenerateKey(user.Username);
        }

        public string NewUserToken(User user)
        {
            return GenerateKey(user.Username);
        }

        private string GenerateKey(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddDays(15),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}
