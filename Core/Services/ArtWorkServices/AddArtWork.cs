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

            var connection = _sqlServer.Connect();

            var dateStarted = artWork.DateStarted != null
                ? $"'{(DateTime) artWork.DateStarted:MM/dd/yyyy}', "
                : "NULL, ";

            var dateFinished = artWork.DateFinished != null
                ? $"'{(DateTime) artWork.DateFinished:MM/dd/yyyy}', "
                : "NULL, ";


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
                $"image_url, " +
                $"date_started, " +
                $"date_finished, " +
                $"time_spent_minutes) " +
                $"VALUES (" +
                $"{user.Id}, " +
                $"'{artWork.PieceName}', " +
                $"'{artWork.CustomerName}', " +
                $"'{artWork.CustomerContact}', " +
                $"{artWork.ShippingCost}, " +
                $"{artWork.MaterialCost}, " +
                $"{artWork.SalePrice}, " +
                $"{artWork.HeightInches}, " +
                $"{artWork.WidthInches}, " +
                $"'{artWork.Shape}', " +
                $"'{artWork.PaymentType}', " +
                $"{(artWork.IsCommission ? 1 : 0)}, " +
                $"{(artWork.IsPaymentCollected ? 1 : 0)}, " +
                $"'{artWork.ImgUrl}', " +
                $"{dateStarted}" +
                $"{dateFinished}" +
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