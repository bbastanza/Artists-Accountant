using Core.Entities;

namespace Core.Services.ArtPieceServices
{
    public interface IAddArtWork
    {
        void Add(User user, ArtWork artWork);
    }
    public class AddArtWork : IAddArtWork
    {
        public void Add(User user, ArtWork artWork)
        {
            artWork.User = user;
            user.Pieces.Add(artWork);
            //TODO probably a void method , but writes  to db
        }
    }
}