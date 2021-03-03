using System.IO;
using API.Models;
using API.Services;
using Core.Entities;
using Core.Services.ArtWorkServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ArtsController : Controller
    {
        private readonly string _path;
        private readonly IAddArtWork _addArtWork;
        private readonly IMapPiece _mapPiece;
        private readonly IEditArtWork _editArtWork;

        public ArtsController(
            IAddArtWork addArtWork,
            IMapPiece mapPiece,
            IEditArtWork editArtWork)
        {
            _addArtWork = addArtWork;
            _mapPiece = mapPiece;
            _editArtWork = editArtWork;
            _path = Path.GetFullPath(ToString()!);
        }

        // TODO should be a void method
        [Authorize]
        [HttpPost]
        public void AddPiece(ArtWorkInputModel artWorkInput)
        {
            var artWork = _mapPiece.Map(artWorkInput);
            _addArtWork.Add(artWork);
        }

        [Authorize]
        [HttpPut]
        public void EditPiece(ArtWorkInputModel artInput)
        {
            var artWork = _mapPiece.Map(artInput);
            _editArtWork.Edit(artWork);
        }

        [Authorize]
        [HttpDelete]
        public void DeletePiece(ArtWorkInputModel artInput)
        {
            var artWork = _mapPiece.Map(artInput);
            _editArtWork.Edit(artWork);
        }
    }
}