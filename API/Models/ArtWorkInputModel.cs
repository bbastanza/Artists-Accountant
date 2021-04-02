using System;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class ArtWorkInputModel
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        
        [JsonPropertyName("pieceName")] 
        public string PieceName { get; set; }

        [JsonPropertyName("customerName")] 
        public string CustomerName { get; set; }

        [JsonPropertyName("customerContact")] 
        public string CustomerContact { get; set; }

        [JsonPropertyName("shippingCost")] 
        public decimal? ShippingCost { get; set; }

        [JsonPropertyName("materialCost")] 
        public decimal? MaterialCost { get; set; }

        [JsonPropertyName("salePrice")] 
        public decimal? SalePrice { get; set; }

        [JsonPropertyName("heightInches")] 
        public int? HeightInches { get; set; }

        [JsonPropertyName("widthInches")] 
        public int? WidthInches { get; set; }

        [JsonPropertyName("timeSpentMinutes")] 
        public int? TimeSpentMinutes { get; set; }

        [JsonPropertyName("shape")] 
        public string Shape { get; set; }

        [JsonPropertyName("paymentType")] 
        public string PaymentType { get; set; }

        [JsonPropertyName("isCommission")] 
        public bool? IsCommission { get; set; }

        [JsonPropertyName("isPaymentCollected")]
        public bool? IsPaymentCollected { get; set; }

        [JsonPropertyName("dateStarted")] 
        public DateTime? DateStarted { get; set; }

        [JsonPropertyName("dateFinished")] 
        public DateTime? DateFinished { get; set; }

        [JsonPropertyName("userId")] 
        public int? UserId { get; set; }
        
        [JsonPropertyName("imgUrl")] 
        public string ImgUrl { get; set; }
    }
}
