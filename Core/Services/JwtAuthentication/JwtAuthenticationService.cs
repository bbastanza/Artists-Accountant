using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Services.UserServices;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services.JwtAuthentication
{
    public interface IGenerateJwtToken
    {
        string Authenticate(string username, string password);
    }

    public class GenerateJwtToken : IGenerateJwtToken
    {
        private readonly string _key;
        private readonly IGetUserData _getUserData;

        public GenerateJwtToken(string key, IGetUserData getUserData)
        {
            _key = key;
            _getUserData = getUserData;
        }

        public string Authenticate(string username, string password)
        {
            var user = _getUserData.GetUser(username);

            if (user == null || user.Password != password)
                return null;
                
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
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
