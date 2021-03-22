using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Services.SqlBuilders
{
    public interface IArtworkSqlBuilder
    {
        string GenerateUpdateStatement(ArtWork artwork);
        string GenerateInsertStatement(ArtWork artWork);
    }

    public class ArtworkSqlBuilder : IArtworkSqlBuilder
    {
        private Dictionary<string, string> Properties { get; } = new Dictionary<string, string>
        {
            {"UserId", "user_id"},
            {"ImgUrl", "image_url"},
            {"PieceName", "piece_name"},
            {"CustomerName", "customer_name"},
            {"CustomerContact", "customer_contact"},
            {"ShippingCost", "shipping_cost"},
            {"MaterialCost", "material_cost"},
            {"SalePrice", "sale_price"},
            {"HeightInches", "height"},
            {"WidthInches", "width"},
            {"TimeSpentMinutes", "time_spent_minutes"},
            {"Shape", "shape"},
            {"PaymentType", "payment_type"},
            {"IsCommission", "is_commission"},
            {"IsPaymentCollected", "is_payment_collected"},
            {"DateStarted", "date_started"},
            {"DateFinished", "date_finished"}
        };

        public string GenerateUpdateStatement(ArtWork artwork)
        {
            var properties = artwork.GetType().GetProperties();

            var sqlStatement = new StringBuilder("");
            
            foreach (var property in properties)
            {
                var propertyValue = artwork.GetType().GetProperty(property.Name)?.GetValue(artwork);

                if (Properties.ContainsKey(property.Name) && propertyValue != null)
                {
                    sqlStatement.Append($"{Properties[property.Name]} = ");

                    switch (propertyValue)
                    {
                        case string _:
                            sqlStatement.Append($"'{propertyValue}', ");
                            break;
                        case DateTime _:
                            sqlStatement.Append($"'{propertyValue:MM/dd/yyyy}', ");
                            break;
                        case bool value:
                            sqlStatement.Append($"{(value ? 1 : 0)}, ");
                            break;
                        default:
                            sqlStatement.Append($"{propertyValue}, ");
                            break;
                    }
                }
            }

            if (sqlStatement.ToString().Contains(","))
                sqlStatement.Remove(sqlStatement.ToString().LastIndexOf(",", StringComparison.Ordinal), 1);

            return $"UPDATE artwork_table " +
                   $"SET " +
                   sqlStatement +
                   $"WHERE id = {artwork.Id};";
        }

        public string GenerateInsertStatement(ArtWork artWork)
        {
            var properties = GetSqlProperties(artWork);
            var values = GetSqlValues(artWork);
            return $"INSERT INTO artwork_table (" +
                   $"{(properties.Length > 0 ? $"{properties}" : "")}" +
                   $") VALUES (" +
                   $"{(values.Length > 0 ? $"{values}" : "")});";
        }

        private string GetSqlProperties(ArtWork artwork)
        {
            var properties = artwork.GetType().GetProperties();

            var sqlStatement = new StringBuilder("");
            foreach (var property in properties)
            {
                var propertyValue = artwork.GetType().GetProperty(property.Name)?.GetValue(artwork);

                if (Properties.ContainsKey(property.Name) && propertyValue != null)
                {
                    sqlStatement.Append($"{Properties[property.Name]}, ");
                }
            }

            if (sqlStatement.ToString().Contains(","))
                sqlStatement.Remove(sqlStatement.ToString().LastIndexOf(",", StringComparison.Ordinal), 2);

            return sqlStatement.ToString();
        }

        private string GetSqlValues(ArtWork artwork)
        {
            var properties = artwork.GetType().GetProperties();

            var sqlStatement = new StringBuilder("");
            foreach (var property in properties)
            {
                var propertyValue = artwork.GetType().GetProperty(property.Name)?.GetValue(artwork);

                if (Properties.ContainsKey(property.Name) && propertyValue != null)
                    switch (propertyValue)
                    {
                        case string _:
                            sqlStatement.Append($"'{propertyValue}', ");
                            break;
                        case DateTime _:
                            sqlStatement.Append($"'{propertyValue:MM/dd/yyyy}', ");
                            break;
                        case bool value:
                            sqlStatement.Append($"{(value ? 1 : 0)}, ");
                            break;
                        default:
                            sqlStatement.Append($"{propertyValue}, ");
                            break;
                    }
            }

            if (sqlStatement.ToString().Contains(","))
                sqlStatement.Remove(sqlStatement.ToString().LastIndexOf(",", StringComparison.Ordinal), 2);

            return sqlStatement.ToString();
        }
    }
}