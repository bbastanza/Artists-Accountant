using System;
using System.Data.SqlClient;
using Core.Entities;
using Core.Services.DbServices;
using Core.Services.UserServices;

namespace Core.Services.ArtWorkServices
{
    public interface IAddArtWork
    {
        void Add(ArtWork artWork);
    }

    public class AddArtWork : IAddArtWork
    {
        private readonly IGetUserData _getUserData;
        private readonly ISqlServer _sqlServer;

        public AddArtWork(
            IGetUserData getUserData,
            ISqlServer sqlServer)
        {
            _getUserData = getUserData;
            _sqlServer = sqlServer;
        }

        public void Add(ArtWork artWork)
        {
            var user = _getUserData.GetUser(artWork.Username);
            user.ArtWorks.Add(artWork);
            
            var connection = _sqlServer.Connect();
            var shippingCost = artWork.ShippingCost;
            var materialCost = artWork.MaterialCost;
            var salePrice = artWork.SalePrice;
            var height = artWork.HeightInches;
            var width = artWork.WidthInches;
            var isCommission = artWork.IsCommission;
            var isPaymentCollected = artWork.IsPaymentCollected;
            var dateStarted = artWork.DateStarted;
            var dateFinished = artWork.DateFinished;

            var query =
                $"INSERT INTO artwork_table (" +
                $"user_id, " +
                $"piece_name, " +
                $"customer_name, " +
                $"customer_contact, " +
                $"shipping_cost, " +
                $"material_cost, " +
                $"sale_price, " +
                $"height, " +
                $"width, " +
                $"shape, " +
                $"payment_type, " +
                $"is_commission, " +
                $"is_payment_collected, " +
                $"date_started, " +
                $"date_finished, " +
                $"image_url, " +
                $"time_spent_minutes) " +
                $"VALUES (" +
                $"{user.Id}, " +
                $"'{artWork.PieceName}', " +
                $"'{artWork.CustomerName}', " +
                $"'{artWork.CustomerContact}', " +
                $"{shippingCost}, " +
                $"{materialCost}, " +
                $"{salePrice}, " +
                $"{height}, " +
                $"{width}, " +
                $"'{artWork.Shape}', " +
                $"'{artWork.PaymentType}', " +
                $"{(isCommission ? 1 : 0)}, " +
                $"{(isPaymentCollected ? 1 : 0)}, " +
                $"'{dateStarted.ToString("MM/dd/yyyy")}', " +
                $"'{dateFinished.ToString("MM/dd/yyyy")}', " +
                $"'{artWork.ImgUrl}', " +
                $"{artWork.TimeSpentMinutes});";

            try
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                _sqlServer.CloseConnection();
            }
        }
    }
}