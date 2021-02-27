using System;
using System.IO;
using API.ApiServices;
using API.Models;
using Core.Entities;
using Core.Services.ArtPieceServices;
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

        [HttpPost]
        [Route("addPiece")]
        public User AddPiece(PieceInputModel pieceInput)
        {
            var user = new User() {UserName = "Brian", Password = "password", Email = "myEmail"};
            var piece = _mapPiece.Map(pieceInput);
            _addPieceService.Add(user, piece);
            return user;
        }
    }
}
