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
        
        public static decimal GetDefaultDecimal(this SqlDataReader reader, string column)
        {
            var index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? 0 : reader.GetDecimal(index);
        }
        
        public static string GetDefaultString(this SqlDataReader reader, string column)
        {
            var index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) || reader.GetString(index) == "" ? null : reader.GetString(index);
        }
        
        public static bool GetDefaultBool(this SqlDataReader reader, string column)
        {
            var index = reader.GetOrdinal(column);
            return !reader.IsDBNull(index) && reader.GetBoolean(index);
        }
        
        public static DateTime GetDefaultDateTime(this SqlDataReader reader, string column)
        {
            var index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? new DateTime(0) : reader.GetDateTime(index);
        }
    }
}