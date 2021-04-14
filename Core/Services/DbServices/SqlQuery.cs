using System.Data.SqlClient;
using System.IO;
using SqlException = Infrastructure.Exceptions.SqlException;

namespace Core.Services.DbServices
{
    public interface ISqlQuery
    {
        void ExecuteVoid(string query);
        void ExecuteDoubleVoid(string query1, string query2);
    }

    public class SqlQuery : ISqlQuery
    {
        private readonly ISqlServer _sqlServer;
        private readonly string _path;

        public SqlQuery(ISqlServer sqlServer)
        {
            _sqlServer = sqlServer;
            _path = Path.GetFullPath(ToString());
        }

        public void ExecuteVoid(string query)
        {
            var connection = _sqlServer.Connect();

            try
            {
                using (var command = new SqlCommand(query, connection))
                    command.ExecuteNonQuery();
            }
            catch
            {
                throw new SqlException(_path, "Execute()");
            }
            finally
            {
                _sqlServer.CloseConnection();
            }
        }

        public void ExecuteDoubleVoid(string query1, string query2)
        {
            var connection = _sqlServer.Connect();

            try
            {
                using (var command1 = new SqlCommand(query1, connection))
                    command1.ExecuteNonQuery();
                    
                using (var command2 = new SqlCommand(query2, connection))
                    command2.ExecuteNonQuery();
            }
            catch
            {
                throw new SqlException(_path, "Execute()");
            }
            finally
            {
                _sqlServer.CloseConnection();
            }
        }
    }
}