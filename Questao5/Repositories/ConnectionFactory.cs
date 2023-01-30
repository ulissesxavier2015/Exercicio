using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Interfaces;

namespace Questao5.Repositories
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();

            return connection;
        }
    }
}
