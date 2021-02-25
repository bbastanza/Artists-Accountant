using System;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class PieceInputModel
    {
        [JsonPropertyName("pieceName")]
        public virtual string PieceName { get; set; } 
        [JsonPropertyName("dateStarted")]
        public virtual DateTime DateStarted { get; set; } 
        [JsonPropertyName("dateFinished")]
        public virtual DateTime DateFinished { get; set; } 
        [JsonPropertyName("customerName")]
        public virtual string CustomerName { get; set; } 
        [JsonPropertyName("contact")]
        public virtual string CustomerContact { get; set; } 
        [JsonPropertyName("shippingCost")]
        public virtual double ShippingCost { get; set; } 
        [JsonPropertyName("materialCost")]
        public virtual double MaterialCost { get; set; } 
        [JsonPropertyName("height")]
        public virtual int HeightInches { get; set; } 
        [JsonPropertyName("width")]
        public virtual int WidthInches { get; set; } 
        [JsonPropertyName("timeSpent")]
        public virtual int TimeSpentMinutes { get; set; } 
        [JsonPropertyName("shape")]
        public virtual string Shape { get; set; } 
        [JsonPropertyName("paymentType")]
        public virtual string PaymentType { get; set; } 
        [JsonPropertyName("isCommission")]
        public virtual bool IsCommission { get; set; } 
        [JsonPropertyName("salePrice")]
        public virtual double SalePrice { get; set; } 
    }
}