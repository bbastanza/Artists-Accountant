using Core.Entities;

namespace Core.Services.ArtPieceServices
{
    public interface IAddPieceService
    {
        User Add(User user, Piece piece);
    }
    public class AddPieceService : IAddPieceService
    {
        public User Add(User user, Piece piece)
        {
            user.Pieces.Add(piece);

            //TODO probably a void method , but writes  to db
            return user;
        }
    }
}