using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Core.Services.DbServices
{
    public interface ISqlServer
    {
        SqlConnection Connect();
        void CloseConnection();
    }

    public class SqlServer : ISqlServer
    {
        private readonly SqlConnection _connection;

        public SqlServer(IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            if (connectionString == null)
            {
                var datasource = configuration["SqlServer:Datasource"];
                var database = configuration["SqlServer:Database"];
                var username = configuration["SqlServer:Username"];
                var password = configuration["SqlServer:Password"];
                connectionString = @"Data Source=" + datasource +
                                   ";Initial Catalog=" + database +
                                   ";Persist Security Info=True;User ID=" + username +
                                   ";Password=" + password;
            }
            _connection = new SqlConnection(connectionString);
        }

        public SqlConnection Connect()
        {
            try
            {
                _connection.Open();
                return _connection;
            }
            catch
            {
                return null;
            }
        }

        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}