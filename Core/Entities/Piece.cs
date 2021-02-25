using System;

namespace Core.Entities
{
    public class Piece
    {
        public virtual Guid PieceId { get; set; } = Guid.NewGuid();
        public virtual string PieceName { get; set; } 
        public virtual DateTime DateStarted { get; set; } 
        public virtual DateTime DateFinished { get; set; } 
        public virtual string CustomerName { get; set; } 
        public virtual string CustomerContact { get; set; } 
        public virtual double ShippingCost { get; set; } 
        public virtual double MaterialCost { get; set; } 
        public virtual double SalePrice { get; set; } 
        public virtual int HeightInches { get; set; } 
        public virtual int WidthInches { get; set; } 
        public virtual int TimeSpentMinutes { get; set; } 
        public virtual string Shape { get; set; } 
        public virtual string PaymentType { get; set; } 
        public virtual bool IsCommission { get; set; } 
    }
}