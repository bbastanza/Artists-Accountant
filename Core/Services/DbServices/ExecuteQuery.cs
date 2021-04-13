using System.Data.SqlClient;
using System.IO;
using SqlException = Infrastructure.Exceptions.SqlException;

namespace Core.Services.DbServices
{
    public interface ISqlQuery
    {
        void ExecuteVoid(string query);
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
                {
                    command.ExecuteNonQuery();
                }
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