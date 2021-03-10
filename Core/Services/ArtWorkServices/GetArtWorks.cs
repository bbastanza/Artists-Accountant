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
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            var artwork = new ArtWork
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                PieceName = reader.GetString(reader.GetOrdinal("piece_name")),
                                CustomerName = reader.GetString(reader.GetOrdinal("customer_name")),
                                CustomerContact = reader.GetString(reader.GetOrdinal("customer_contact")),
                                ShippingCost = reader.GetDecimal(reader.GetOrdinal("shipping_cost")),
                                MaterialCost = reader.GetDecimal(reader.GetOrdinal("material_cost")),
                                SalePrice = reader.GetDecimal(reader.GetOrdinal("sale_price")),
                                HeightInches = reader.GetInt32(reader.GetOrdinal("height")),
                                WidthInches = reader.GetInt32(reader.GetOrdinal("width")),
                                Shape = reader.GetString(reader.GetOrdinal("shape")),
                                PaymentType = reader.GetString(reader.GetOrdinal("payment_type")),
                                IsCommission = reader.GetBoolean(reader.GetOrdinal("is_commission")),
                                IsPaymentCollected = reader.GetBoolean(reader.GetOrdinal("is_payment_collected")),
                                DateStarted = reader.GetDateTime(reader.GetOrdinal("date_started")),
                                DateFinished = reader.GetDateTime(reader.GetOrdinal("date_finished")),
                                TimeSpentMinutes = reader.GetInt32(reader.GetOrdinal("time_spent_minutes"))
                            };
                            artworks.Add(artwork);
                        }
                }
            }

            return artworks;
        }
    }
}