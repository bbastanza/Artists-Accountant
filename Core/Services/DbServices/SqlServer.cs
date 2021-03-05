using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Core.Services.DbServices
{
    public interface ISqlServer
    {
        void Connect();
    }

    public class SqlServer : ISqlServer
    {
        private readonly string _datasource;
        private readonly string _database;
        private readonly string _username;
        private readonly string _password;

        public SqlServer(IConfiguration configuration)
        {
            _datasource = configuration["SqlServer:Datasource"];
            _database = configuration["SqlServer:Database"];
            _username = configuration["SqlServer:Username"];
            _password = configuration["SqlServer:Password"];
        }

        // TODO | return void?
        public void Connect()
        {
            var connectionString = @"Data Source=" + _datasource +
                                   ";Initial Catalog=" + _database +
                                   ";Persist Security Info=True;User ID=" + _username +
                                   ";Password=" + _password;

            var connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}