using WebAutopark.DataAccesLayer.Interfaces;
using Microsoft.Extensions.Configuration;

namespace WebAutopark.DataAccesLayer.Repositories.Connection
{
    public class MsSqlStringProvider : IConnectionStringProvider
    {
        private string _connectionString;
        public MsSqlStringProvider(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSqlServer");
        }
        public string GetConnectionString()
            => _connectionString;
    }
}
