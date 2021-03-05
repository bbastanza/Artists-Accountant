using System.IO;
using API.Models;
using Core.Services.ArtWorkServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class AwsController : Controller
    {
        private readonly IAwsImage _awsImage;
        private readonly string _path;

        public AwsController(IAwsImage awsImage)
        {
            _awsImage = awsImage;
            _path = Path.GetFullPath(ToString()!);
        }

        // [Authorize]
        [HttpPost]
        public void AddImage()
        {
            var something = _awsImage.UploadFile();
        }
    }
}