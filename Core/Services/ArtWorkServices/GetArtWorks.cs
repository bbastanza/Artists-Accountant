using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Core.Entities;
using Core.Services.DbServices;

namespace Core.Services.ArtWorkServices
{
    public interface IGetArtWorks
    {
        List<ArtWork> GetAll(int userId, SqlConnection connection);
    }

    public class GetArtWorks : IGetArtWorks
    {
        private readonly string _path;

        public GetArtWorks()
        {
            _path = Path.GetFullPath(ToString());
        }

        public List<ArtWork> GetAll(int userId, SqlConnection connection)
        {
            var query = $"SELECT * FROM artwork_table WHERE user_id = {userId}";

            var artworks = new List<ArtWork>();

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return artworks;

                    while (reader.Read())
                    {
                        var pieceNameIdx = reader.GetOrdinal("piece_name");
                        var customerNameIdx = reader.GetOrdinal("customer_name");
                        var customerContactIdx = reader.GetOrdinal("customer_contact");
                        var imgUrlIdx = reader.GetOrdinal("image_url");
                        var shippingCostIdx = reader.GetOrdinal("shipping_cost");
                        var materialCostIdx = reader.GetOrdinal("material_cost");
                        var salePriceIdx = reader.GetOrdinal("sale_price");
                        var heightIdx = reader.GetOrdinal("height");
                        var widthIdx = reader.GetOrdinal("width");
                        var shapeIdx = reader.GetOrdinal("shape");
                        var paymentTypeIdx = reader.GetOrdinal("payment_type");
                        var isCommissionIdx = reader.GetOrdinal("is_commission");
                        var isPaymentCollectedIdx = reader.GetOrdinal("is_payment_collected");
                        var dateStartedIdx = reader.GetOrdinal("date_started");
                        var dateFinishedIdx = reader.GetOrdinal("date_finished");
                        var timeSpentIdx = reader.GetOrdinal("time_spent_minutes");

                        var artwork = new ArtWork
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            PieceName = reader.IsDBNull(pieceNameIdx) ? null : reader.GetString(pieceNameIdx),
                            CustomerName = reader.IsDBNull(customerNameIdx) ? null : reader.GetString(customerNameIdx),
                            CustomerContact = reader.IsDBNull(customerContactIdx) ? null : reader.GetString(customerContactIdx),
                            ImgUrl = reader.IsDBNull(imgUrlIdx) ? null : reader.GetString(imgUrlIdx),
                            Shape = reader.IsDBNull(shapeIdx) ? null : reader.GetString(shapeIdx),
                            PaymentType = reader.IsDBNull(paymentTypeIdx) ? null : reader.GetString(paymentTypeIdx),
                            ShippingCost = reader.IsDBNull(shippingCostIdx) ? 0 : reader.GetDecimal(shippingCostIdx),
                            MaterialCost = reader.IsDBNull(materialCostIdx) ? 0 : reader.GetDecimal(materialCostIdx),
                            SalePrice = reader.IsDBNull(salePriceIdx) ? 0 : reader.GetDecimal(salePriceIdx),
                            HeightInches = reader.IsDBNull(heightIdx) ? 0 : reader.GetInt32(heightIdx),
                            WidthInches = reader.IsDBNull(widthIdx) ? 0 : reader.GetInt32(widthIdx),
                            TimeSpentMinutes = reader.IsDBNull(timeSpentIdx) ? 0 : reader.GetInt32(timeSpentIdx),
                            DateStarted = reader.IsDBNull(dateStartedIdx) ? new DateTime(0) : reader.GetDateTime(dateStartedIdx),
                            DateFinished = reader.IsDBNull(dateFinishedIdx) ? new DateTime(0) : reader.GetDateTime(dateFinishedIdx),
                            IsCommission = !reader.IsDBNull(isCommissionIdx) && reader.GetBoolean(isCommissionIdx),
                            IsPaymentCollected = !reader.IsDBNull(isPaymentCollectedIdx) && reader.GetBoolean(isPaymentCollectedIdx)
                        };
                        artworks.Add(artwork);
                    }
                }
            }

            return artworks;
        }
    }
}