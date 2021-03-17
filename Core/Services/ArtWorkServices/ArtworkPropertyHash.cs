using System;
using System.Collections;
using System.Reflection;
using System.Text;
using Core.Entities;

namespace Core.Services.ArtWorkServices
{
    public class ArtworkPropertyHash
    {
        private Hashtable Properties { get; } = new Hashtable();

        public ArtworkPropertyHash()
        {
            Properties.Add("username", "user_id");
            Properties.Add("pieceName", "piece_name");
            Properties.Add("customerName", "customer_name");
            Properties.Add("customerContact", "customer_contact");
            Properties.Add("shippingCost", "shipping_cost");
            Properties.Add("materialCost", "material_cost");
            Properties.Add("salePrice", "sale_price");
            Properties.Add("heightInches", "height");
            Properties.Add("widthInches", "width");
            Properties.Add("shape", "shape");
            Properties.Add("paymentType", "payment_type");
            Properties.Add("isCommission", "is_commission");
            Properties.Add("isPaymentCollected", "is_payment_collected");
            Properties.Add("imgUrl", "image_url");
            Properties.Add("dateStarted", "date_started");
            Properties.Add("dateFinished", "date_finished");
            Properties.Add("timeSpentMinutes", "time_spent_minutes");
        }

        public string GetSqlProperty(object artwork)
        {
            var properties = artwork.GetType().GetProperties();

            Console.WriteLine(properties);
            var sqlStatement = new StringBuilder("");
            foreach (var property in properties)
            {
                Console.WriteLine(property.Name);
                var name = property.Name;
                sqlStatement.Append($"{Properties[name]}, ");
            }


            Console.WriteLine(sqlStatement.ToString());
            return sqlStatement.Remove(sqlStatement.Length - 4, 4).ToString();
        }
    }
}