using System;
using System.Data.SqlClient;

namespace Core.ExtensionMethods
{
    public static class SqlDataReaderExtensions
    {
        public static int GetDefaultInt(this SqlDataReader reader, string column)
        {
            var index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? 0 : reader.GetInt32(index);
        }
        
        public static string GetDefaultString(this SqlDataReader reader, string column)
        {
            var index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) || reader.GetString(index) == "" ? null : reader.GetString(index);
        }

        public static int? GetNullableInt(this SqlDataReader reader, string column)
        {
            var index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? null : (int?) reader.GetInt32(index);
        }

        public static decimal? GetNullableDecimal(this SqlDataReader reader, string column)
        {
            var index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? null : (decimal?) reader.GetDecimal(index);
        }

        public static bool? GetNullableBool(this SqlDataReader reader, string column)
        {
            var index = reader.GetOrdinal(column);
            return !reader.IsDBNull(index) && reader.GetBoolean(index);
        }

        public static DateTime? GetNullableDateTime(this SqlDataReader reader, string column)
        {
            var index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? null : (DateTime?) reader.GetDateTime(index);
        }
    }
}
