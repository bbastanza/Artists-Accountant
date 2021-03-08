using System.IO;
using API.Models;
using Core.Services.JwtAuthentication;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IGenerateJwtToken _generateJwtToken;
        private readonly string _path;

        public AuthenticationController(IGenerateJwtToken generateJwtToken)
        {
            _generateJwtToken = generateJwtToken;
            _path = Path.GetFullPath(ToString()!);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(UserAuthenticationModel user)
        {
            if (user.Username == null || user.Password == null)
                throw new InvalidInputException(_path, "Authenticate()");
                    
            var token = _generateJwtToken.Authenticate(user.Username, user.Password);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
