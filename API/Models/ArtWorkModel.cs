using System;
using Core.Entities;

namespace API.Models
{
    public class ArtWorkModel
    {
        public ArtWorkModel(ArtWork artWork)
        {
            ImgUrl = artWork.ImgUrl;
            PieceName = artWork.PieceName;
            CustomerName = artWork.CustomerName;
            CustomerContact = artWork.CustomerContact;
            ShippingCost = artWork.ShippingCost;
            MaterialCost = artWork.MaterialCost;
            SalePrice = artWork.SalePrice;
            HeightInches = artWork.HeightInches;
            WidthInches = artWork.WidthInches;
            TimeSpentMinutes = artWork.TimeSpentMinutes;
            Shape = artWork.Shape;
            PaymentType = artWork.PaymentType;
            IsCommission = artWork.IsCommission;
            IsPaymentCollected = artWork.IsPaymentCollected;
            DateStarted = artWork.DateStarted;
            DateFinished = artWork.DateFinished;
            Id = artWork.Id;
        }

        public int? Id { get; }
        public string ImgUrl { get; }
        public string PieceName { get; }
        public string CustomerName { get; }
        public string CustomerContact { get; }
        public decimal? ShippingCost { get; }
        public decimal? MaterialCost { get; }
        public decimal? SalePrice { get; }
        public decimal? Margin => SalePrice - (ShippingCost + MaterialCost);
        public int? HeightInches { get; }
        public int? WidthInches { get; }
        public int? TimeSpentMinutes { get; }
        public string Shape { get; }
        public string PaymentType { get; }
        public bool? IsCommission { get; }
        public bool? IsPaymentCollected { get; }
        public DateTime? DateStarted { get; }
        public DateTime? DateFinished { get; }
    }
}
