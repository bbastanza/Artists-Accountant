using System;
using System.Data.SqlClient;
using Core.Entities;
using Core.ExtensionMethods;
using Core.Services.DbServices;

namespace Core.Services.UserServices
{
    public interface IGetUserData
    {
        User GetUserWithArtworks(int? id);
        User GetDataWithoutArtworks(int? id);
        User GetDataByUsername(string username);
    }

    public class GetUserData : IGetUserData
    {
        private readonly ISqlServer _sqlServer;

        public GetUserData(ISqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public User GetUserWithArtworks(int? id)
        {
            var connection = _sqlServer.Connect();

            var query =
                $"SELECT " +
                $"u.username, " +
                $"u.id, " +
                $"u.profile_image_url, " +
                $"a.id AS artworkId, " +
                $"a.piece_name, " +
                $"a.customer_name, " +
                $"a.image_url, " +
                $"a.customer_contact, " +
                $"a.shipping_cost, " +
                $"a.material_cost, " +
                $"a.sale_price, " +
                $"a.height, " +
                $"a.width, " +
                $"a.time_spent_minutes, " +
                $"a.shape, " +
                $"a.payment_type, " +
                $"a.is_commission, " +
                $"a.is_payment_collected, " +
                $"a.date_started, " +
                $"a.date_finished " +
                $"FROM user_table u " +
                $"INNER JOIN artwork_table a " +
                $"ON u.id = a.user_id " +
                $"WHERE u.id = {id};";

            User user = null;

            try
            {
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
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
                                ShippingCost = reader.GetNullableDecimal("shipping_cost"),
                                MaterialCost = reader.GetNullableDecimal("material_cost"),
                                SalePrice = reader.GetNullableDecimal("sale_price"),
                                HeightInches = reader.GetNullableInt("height"),
                                WidthInches = reader.GetNullableInt("width"),
                                TimeSpentMinutes = reader.GetNullableInt("time_spent_minutes"),
                                DateStarted = reader.GetNullableDateTime("date_started"),
                                DateFinished = reader.GetNullableDateTime("date_finished"),
                                IsCommission = reader.GetNullableBool("is_commission"),
                                IsPaymentCollected = reader.GetNullableBool("is_payment_collected"),
                            };
                            user.ArtWorks.Add(artwork);
                        }
                if (user != null) return user;
                _sqlServer.CloseConnection();
                return GetDataWithoutArtworks(id);
            }
            catch
            {
                return null;
            }
            finally
            {
                _sqlServer.CloseConnection();
            }
        }

        public User GetDataWithoutArtworks(int? id)
        {
            var connection = _sqlServer.Connect();

            var query =
                $"SELECT " +
                $"username, password, profile_image_url " +
                $"FROM user_table " +
                $"WHERE id = {id};";

            User user = new User {Id = id};

            using (var command = new SqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        user.Username = reader.GetDefaultString("username");
                        user.ProfileImgUrl = reader.GetDefaultString("profile_image_url");
                        user.Password = reader.GetDefaultString("password");
                    }

            _sqlServer.CloseConnection();
            return user;
        }

        public User GetDataByUsername(string username)
        {
            var connection = _sqlServer.Connect();

            var query =
                $"SELECT " +
                $"id, username, password, profile_image_url " +
                $"FROM user_table " +
                $"WHERE username = '{username}';";

            Console.WriteLine("fetching user");
            User user = new User();

            using (var command = new SqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        user.Id = reader.GetDefaultInt("id");
                        user.Username = reader.GetDefaultString("username");
                        user.ProfileImgUrl = reader.GetDefaultString("profile_image_url");
                        user.Password = reader.GetDefaultString("password");
                    }

            Console.WriteLine("User = "+ user.Username + user.Id);
            _sqlServer.CloseConnection();
            return user;
        }
    }
}