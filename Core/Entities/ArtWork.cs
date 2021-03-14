using System;

namespace Core.Entities
{
    public class ArtWork : Entity
    {
        public string Username { get; set; }
        public string ImgUrl { get; set; }
        public string PieceName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal SalePrice { get; set; }
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