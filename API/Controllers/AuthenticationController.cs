using System;
using System.IO;
using API.Models;
using Core.Services.JwtAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private string _path;

        public AuthenticationController(IJwtAuthenticationService jwtAuthenticationService)
        {
            _jwtAuthenticationService = jwtAuthenticationService;
            _path = Path.GetFullPath(ToString()!);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserAuthenticationModel user)
        {
            var token = _jwtAuthenticationService.Authenticate(user.Username, user.Password);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}