using System.IO;
using API.Models;
using Core.Services.JwtAuthentication;
using Core.Services.UserServices;
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
        private readonly IGetUserData _getUserData;
        private readonly string _path;

        public AuthenticationController(
            IGenerateJwtToken generateJwtToken,
            IGetUserData getUserData
        )
        {
            _generateJwtToken = generateJwtToken;
            _getUserData = getUserData;
            _path = Path.GetFullPath(ToString()!);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(UserAuthenticationInputModel user)
        {
            if (user.Username == null || user.Password == null)
                throw new InvalidInputException(_path, "Authenticate()");

            var token = _generateJwtToken.Authenticate(user.Username, user.Password);

            if (token == null)
                return Unauthorized();

            var userData = _getUserData.GetDataByUsername(user.Username);

            var userAuth = new UserAuthModel
            {
                Id = userData.Id,
                Username = userData.Username,
                JwtToken = token,
                ProfileImgUrl = userData.ProfileImgUrl
            };

            return Ok(userAuth);
        }
    }
}