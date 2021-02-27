using System;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class PieceInputModel
    {
        [JsonPropertyName("pieceName")] 
        public string PieceName { get; set; }
        [JsonPropertyName("dateStarted")] 
        public DateTime DateStarted { get; set; }
        [JsonPropertyName("dateFinished")] 
        public DateTime DateFinished { get; set; }
        [JsonPropertyName("customerName")] 
        public string CustomerName { get; set; }
        [JsonPropertyName("customerContact")] 
        public string CustomerContact { get; set; }
        [JsonPropertyName("shippingCost")] 
        public double ShippingCost { get; set; }
        [JsonPropertyName("materialCost")] 
        public double MaterialCost { get; set; }
        [JsonPropertyName("height")] 
        public int HeightInches { get; set; }
        [JsonPropertyName("width")] 
        public int WidthInches { get; set; }
        [JsonPropertyName("timeSpent")] 
        public int TimeSpentMinutes { get; set; }
        [JsonPropertyName("shape")] 
        public string Shape { get; set; }
        [JsonPropertyName("paymentType")] 
        public string PaymentType { get; set; }
        [JsonPropertyName("isCommission")] 
        public bool IsCommission { get; set; }
        [JsonPropertyName("salePrice")] 
        public double SalePrice { get; set; }
        [JsonPropertyName("isPaymentCollected")]
        public bool IsPaymentCollected { get; set; }
    }
}