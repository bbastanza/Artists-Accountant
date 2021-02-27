using System.IO;
using API.ApiServices;
using API.Models;
using Core.Entities;
using Core.Services.ArtPieceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ArtsController : Controller
    {
        private readonly string _path;
        private IAddPieceService _addPieceService;
        private readonly IMapPiece _mapPiece;

        public ArtsController(
            IAddPieceService addPieceService,
            IMapPiece mapPiece)
        {
            _addPieceService = addPieceService;
            _mapPiece = mapPiece;
            _path = Path.GetFullPath(ToString()!);
        }

        // TODO should be a void method
        [Authorize]
        [HttpPost]
        public User AddPiece(ArtWorkInputModel artWorkInput)
        {
            // TODO 
            // SELECT user FROM user_table WHERE username = $"{pieceInput.Username}"
            
            var user = new User(artWorkInput.Username, "password");
            var piece = _mapPiece.Map(artWorkInput);
            _addPieceService.Add(user, piece);
            return user;
        }
    }
}
