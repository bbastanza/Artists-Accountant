using System;
using System.IO;
using Core.Entities;

namespace Core.Services.ArtWorkServices
{
    public interface IEditArtWork
    {
        void Edit(object work);
    }

    public class EditArtWork : IEditArtWork
    {
        private readonly string _path;

        public EditArtWork()
        {
            _path = Path.GetFullPath(ToString());
        }

        public void Edit(object work)
        {
            Console.WriteLine(work);
            // var artWork = _getArtWorks.GetAll(newArtWork.PieceId);

            // compare with new, write changes to the database
        }
    }
}
