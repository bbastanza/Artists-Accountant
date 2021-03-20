using API.Models;
using Core.Entities;

namespace API.Services
{
    public interface IMapPiece
    {
        ArtWork Map(ArtWorkInputModel artWorkInput);
    }
    public class MapPiece : IMapPiece
    {
        public ArtWork Map(ArtWorkInputModel artWorkInput)
        {
            if (artWorkInput.Shape == "round")
                artWorkInput.HeightInches = artWorkInput.WidthInches;
            
            return new ArtWork
            {
                UserId = artWorkInput.UserId,
                Id = artWorkInput.Id,
                PieceName = artWorkInput.PieceName,
                DateStarted = artWorkInput.DateStarted,
                DateFinished = artWorkInput.DateFinished,
                CustomerContact = artWorkInput.CustomerContact,
                CustomerName = artWorkInput.CustomerName,
                ShippingCost = artWorkInput.ShippingCost,
                MaterialCost = artWorkInput.MaterialCost,
                HeightInches = artWorkInput.HeightInches,
                WidthInches = artWorkInput.WidthInches,
                TimeSpentMinutes = artWorkInput.TimeSpentMinutes,
                Shape = artWorkInput.Shape,
                PaymentType = artWorkInput.PaymentType,
                IsCommission = artWorkInput.IsCommission,
                SalePrice = artWorkInput.SalePrice,
                IsPaymentCollected = artWorkInput.IsPaymentCollected,
                ImgUrl = artWorkInput.ImgUrl
            };
        }
    }
}