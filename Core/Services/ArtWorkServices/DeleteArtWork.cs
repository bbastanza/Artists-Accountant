using System.IO;

namespace Core.Services.ArtWorkServices
{
    public interface IDeleteArtWork
    {
        void Delete(int id);
    }

    public class DeleteArtWork : IDeleteArtWork
    {
        private readonly string _path;

        public DeleteArtWork()
        {
            _path = Path.GetFullPath(ToString());
        }

        public void Delete(int id)
        {
            // DELETE FROM artwork_table WHERE id = {id};
        }
    }
}