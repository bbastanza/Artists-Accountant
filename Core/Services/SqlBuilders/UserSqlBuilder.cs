using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Services.SqlBuilders
{
    public interface IUserSqlBuilder
    {
        string GenerateUpdateStatement(User user);
    }

    public class UserSqlBuilder : IUserSqlBuilder
    {
        private Dictionary<string, string> Properties { get; } = new Dictionary<string, string>
        {
            {"Password", "password"},
            {"Username", "username"},
            {"ProfileImgUrl", "profile_image_url"},
        };

        public string GenerateUpdateStatement(User user)
        {
            var properties = user.GetType().GetProperties();
            
            if (properties.Length == 0) return "";

            var sqlStatement = new StringBuilder("");
            foreach (var property in properties)
            {
                var propertyValue = user.GetType().GetProperty(property.Name)?.GetValue(user);

                if (!Properties.ContainsKey(property.Name) || propertyValue == null) continue;
                
                sqlStatement.Append($"{Properties[property.Name]} = ");
                sqlStatement.Append($"'{propertyValue}', ");
            }

            if (sqlStatement.ToString().Contains(","))
                sqlStatement.Remove(sqlStatement.ToString().LastIndexOf(",", StringComparison.Ordinal), 1);

            return $"UPDATE user_table " +
                   $"SET " +
                   sqlStatement +
                   $"WHERE id = {user.Id};";
        }
    }
}