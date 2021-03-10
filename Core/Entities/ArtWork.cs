using System;

namespace Core.Entities
{
    public class ArtWork : Entity
    {
        public virtual string PieceName { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string CustomerContact { get; set; }
        public virtual decimal ShippingCost { get; set; }
        public virtual decimal MaterialCost { get; set; }
        public virtual decimal SalePrice { get; set; }
        public virtual decimal Margin => SalePrice - (ShippingCost + MaterialCost);
        public virtual int HeightInches { get; set; }
        public virtual int WidthInches { get; set; }
        public virtual int TimeSpentMinutes { get; set; }
        public virtual string Shape { get; set; }
        public virtual string PaymentType { get; set; }
        public virtual bool IsCommission { get; set; }
        public virtual bool IsPaymentCollected { get; set; }
        public virtual DateTime DateStarted { get; set; }
        public virtual DateTime DateFinished { get; set; }
        public virtual string Username { get; set; }
    }
}