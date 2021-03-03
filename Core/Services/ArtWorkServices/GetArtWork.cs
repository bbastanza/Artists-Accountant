using System.IO;
using Core.Entities;

namespace Core.Services.ArtWorkServices
{
    public interface IGetArtWork
    {
        ArtWork GetArt(int id);
    }

    public class GetArtWork : IGetArtWork
    {
        private readonly string _path;

        public GetArtWork()
        {
            _path = Path.GetFullPath(ToString());
        }
        
        public ArtWork GetArt(int id)
        {
            // return $"SELECT * FROM artwork_table WHERE id = {id}"

            // temporary
            return new ArtWork();
        }
    }
}