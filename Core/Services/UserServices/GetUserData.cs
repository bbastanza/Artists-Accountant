using System.Data.SqlClient;
using Core.Entities;
using Core.ExtensionMethods;
using Core.Services.DbServices;

namespace Core.Services.UserServices
{
    public interface IGetUserData
    {
        User GetUser(string username);
    }

    public class GetUserData : IGetUserData
    {
        private readonly ISqlServer _sqlServer;

        public GetUserData(ISqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public User GetUser(string username)
        {
            var connection = _sqlServer.Connect();

            var query =
                $"SELECT " +
                    $"u.username, " +
                    $"u.id, " +
                    $"u.profile_image_url, " +
                    $"a.id AS artworkId,  " +
                    $"a.piece_name, " +
                    $"a.customer_name, " +
                    $"a.image_url, " +
                    $"a.customer_contact, " +
                    $"a.shipping_cost, " +
                    $"a.material_cost, " +
                    $"a.sale_price, " +
                    $"a.height, " +
                    $"a.width,  " +
                    $"a.time_spent_minutes,  " +
                    $"a.shape, " +
                    $"a.payment_type, " +
                    $"a.is_commission, " +
                    $"a.is_payment_collected, " +
                    $"a.date_started, " +
                    $"a.date_finished " +
                $"FROM user_table u " +
                $"INNER JOIN  artwork_table a " +
                $"ON u.id = a.user_id;";

            User user = null;

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            if (user == null)
                                user = new User
                                {
                                    Id = reader.GetDefaultInt("id"),
                                    Username = reader.GetDefaultString("username"),
                                    ProfileImgUrl = reader.GetDefaultString("profile_image_url")
                                };

                            var artwork = new ArtWork
                            {
                                Id = reader.GetDefaultInt("artworkId"),
                                PieceName = reader.GetDefaultString("piece_name"),
                                CustomerName = reader.GetDefaultString("customer_name"),
                                CustomerContact = reader.GetDefaultString("customer_contact"),
                                ImgUrl = reader.GetDefaultString("image_url"),
                                Shape = reader.GetDefaultString("shape"),
                                PaymentType = reader.GetDefaultString("payment_type"),
                                ShippingCost = reader.GetDefaultDecimal("shipping_cost"),
                                MaterialCost = reader.GetDefaultDecimal("material_cost"),
                                SalePrice = reader.GetDefaultDecimal("sale_price"),
                                HeightInches = reader.GetDefaultInt("height"),
                                WidthInches = reader.GetDefaultInt("width"),
                                TimeSpentMinutes = reader.GetDefaultInt("time_spent_minutes"),
                                DateStarted = reader.GetDefaultDateTime("date_started"),
                                DateFinished = reader.GetDefaultDateTime("date_finished"),
                                IsCommission = reader.GetDefaultBool("is_commission"),
                                IsPaymentCollected = reader.GetDefaultBool("is_payment_collected"),
                            };
                            user.ArtWorks.Add(artwork);
                        }
                }
            }

            _sqlServer.CloseConnection();

            return user;

            // todo _sqlServer.CloseConnection middleware?
        }
    }
}