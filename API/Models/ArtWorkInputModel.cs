using System;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class ArtWorkInputModel
    {
        [JsonPropertyName("pieceId")]
        public string PieceId { get; set; }
        
        [JsonPropertyName("pieceName")] 
        public string PieceName { get; set; }

        [JsonPropertyName("customerName")] 
        public string CustomerName { get; set; }

        [JsonPropertyName("customerContact")] 
        public string CustomerContact { get; set; }

        [JsonPropertyName("shippingCost")] 
        public float ShippingCost { get; set; }

        [JsonPropertyName("materialCost")] 
        public float MaterialCost { get; set; }

        [JsonPropertyName("salePrice")] 
        public float SalePrice { get; set; }

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

        [JsonPropertyName("isPaymentCollected")]
        public bool IsPaymentCollected { get; set; }

        [JsonPropertyName("dateStarted")] 
        public DateTime DateStarted { get; set; }

        [JsonPropertyName("dateFinished")] 
        public DateTime DateFinished { get; set; }

        [JsonPropertyName("username")] 
        public string Username { get; set; }
    }
}
