using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Application.Shared.Repositories.Interfaces
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}
