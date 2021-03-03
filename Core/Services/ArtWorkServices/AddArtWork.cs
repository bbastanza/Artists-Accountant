using Core.Entities;

namespace Core.Services.ArtWorkServices
{
    public interface IAddArtWork
    {
        void Add(ArtWork artWork);
    }
    public class AddArtWork : IAddArtWork
    {
        public void Add(ArtWork artWork)
        {
            // TODO 
            // SELECT user FROM user_table WHERE username = $"{artWork.Username}"
            
            // temp
            var user = new User();
            
            artWork.User = user;
            user.Pieces.Add(artWork);
            
            // INSERT INTO artwork_table (..., user_id)
            // VALUES (..., {user.id})
        }
    }
}