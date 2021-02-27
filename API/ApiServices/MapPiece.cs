using API.Models;
using Core.Entities;

namespace API.ApiServices
{
    public interface IMapPiece
    {
        Piece Map(PieceInputModel pieceInput);
    }
    public class MapPiece : IMapPiece
    {
        public Piece Map(PieceInputModel pieceInput)
        {
            if (pieceInput.Shape == "Round")
                pieceInput.HeightInches = pieceInput.WidthInches;
            
            return new Piece
            {
                PieceName = pieceInput.PieceName,
                DateStarted = pieceInput.DateStarted,
                DateFinished = pieceInput.DateFinished,
                CustomerContact = pieceInput.CustomerContact,
                CustomerName = pieceInput.CustomerName,
                ShippingCost = pieceInput.ShippingCost,
                MaterialCost = pieceInput.MaterialCost,
                HeightInches = pieceInput.HeightInches,
                WidthInches = pieceInput.WidthInches,
                TimeSpentMinutes = pieceInput.TimeSpentMinutes,
                Shape = pieceInput.Shape,
                PaymentType = pieceInput.PaymentType,
                IsCommission = pieceInput.IsCommission,
                SalePrice = pieceInput.SalePrice,
                IsPaymentCollected = pieceInput.IsPaymentCollected,
            };
        }
    }
}