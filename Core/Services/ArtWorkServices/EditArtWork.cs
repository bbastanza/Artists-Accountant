using System.IO;
using Core.Entities;
using Core.Services.UserServices;

namespace Core.Services.ArtWorkServices
{
    public interface IEditArtWork
    {
        void Edit(ArtWork newArtWork);
    }
    public class EditArtWork : IEditArtWork
    {
        private readonly IGetArtWork _getArtWork;
        private readonly string _path;

        public EditArtWork(IGetArtWork getArtWork)
        {
            _getArtWork = getArtWork;
            _path = Path.GetFullPath(ToString());
        }
        
        public void Edit(ArtWork newArtWork)
        {
            var artWork = _getArtWork.GetArt(newArtWork.PieceId);

            // compare with new, write changes to the database
        }
    }
}