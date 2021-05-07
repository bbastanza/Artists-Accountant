using System.IO;
using API.Models;
using API.Services;
using Core.Services.ArtWorkServices;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ArtWorksController : Controller
    {
        private readonly string _path;
        private readonly IAddArtWork _addArtWork;
        private readonly IMapPiece _mapPiece;
        private readonly IPatchArtWork _patchArtWork;
        private readonly IDeleteArtWork _deleteArtWork;

        public ArtWorksController(
            IAddArtWork addArtWork,
            IMapPiece mapPiece,
            IPatchArtWork patchArtWork,
            IDeleteArtWork deleteArtWork)
        {
            _addArtWork = addArtWork;
            _mapPiece = mapPiece;
            _patchArtWork = patchArtWork;
            _deleteArtWork = deleteArtWork;
            _path = Path.GetFullPath(ToString()!);
        }

        [Authorize]
        [HttpPost]
        public void AddPiece(ArtWorkInputModel artInput)
        {
            if (artInput.UserId == null)
                throw new InvalidInputException(_path, "AddPieces()");

            var artWork = _mapPiece.Map(artInput);
            _addArtWork.Add(artWork);
        }

        [Authorize]
        [HttpPatch]
        public void EditPiece(ArtWorkInputModel artInput)
        {
            if (artInput.Id == null)
                throw new InvalidInputException(_path, "EditPiece()");

            var artWork = _mapPiece.Map(artInput);
            _patchArtWork.Edit(artWork);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void DeletePiece(int? id)
        {
            if (id == null)
                throw new InvalidInputException(_path, "DeletePiece()");

            _deleteArtWork.Delete(id);
        }
    }
}