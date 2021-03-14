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
            ArtworkId = artWork.Id;
        }

        public int ArtworkId { get; set; }
        public string ImgUrl { get; set; }
        public string PieceName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Margin => SalePrice - (ShippingCost + MaterialCost);
        public int HeightInches { get; set; }
        public int WidthInches { get; set; }
        public int TimeSpentMinutes { get; set; }
        public string Shape { get; set; }
        public string PaymentType { get; set; }
        public bool IsCommission { get; set; }
        public bool IsPaymentCollected { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateFinished { get; set; }
    }
}