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
        private readonly IGetArtWorks _getArtWorks;
        private readonly string _path;

        public EditArtWork(IGetArtWorks getArtWorks)
        {
            _getArtWorks = getArtWorks;
            _path = Path.GetFullPath(ToString());
        }
        
        public void Edit(ArtWork newArtWork)
        {
            // var artWork = _getArtWorks.GetAll(newArtWork.PieceId);

            // compare with new, write changes to the database
        }
    }
}
