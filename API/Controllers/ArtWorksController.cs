using System;
using System.IO;
using API.Models;
using API.Services;
using Core.Entities;
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
        private readonly IEditArtWork _editArtWork;
        private readonly IDeleteArtWork _deleteArtWork;

        public ArtWorksController(
            IAddArtWork addArtWork,
            IMapPiece mapPiece,
            IEditArtWork editArtWork,
            IDeleteArtWork deleteArtWork)
        {
            _addArtWork = addArtWork;
            _mapPiece = mapPiece;
            _editArtWork = editArtWork;
            _deleteArtWork = deleteArtWork;
            _path = Path.GetFullPath(ToString()!);
        }

        // [Authorize]
        [HttpPost]
        public void AddPiece(ArtWorkInputModel artInput)
        {
            if (artInput.Username == null)
                throw new InvalidInputException(_path, "AddPieces()");
            
            var artWork = _mapPiece.Map(artInput);
            _addArtWork.Add(artWork);
        }

        [Authorize]
        [HttpPut]
        public void EditPiece(ArtWorkInputModel artInput)
        {
            if (artInput.Username == null)
                throw new InvalidInputException(_path, "AddPieces()");
            
            var artWork = _mapPiece.Map(artInput);
            _editArtWork.Edit(artWork);
        }

        [Authorize]
        [HttpDelete]
        public void DeletePiece(ArtWorkInputModel artInput)
        {
            if (artInput.Username == null)
                throw new InvalidInputException(_path, "AddPieces()");
            
            _deleteArtWork.Delete(artInput.PieceId);
        }
    }
}