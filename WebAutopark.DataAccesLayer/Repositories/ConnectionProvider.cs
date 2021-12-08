using Microsoft.Data.SqlClient;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public abstract class ConnectionProvider : IDisposable, IAsyncDisposable
    {
        protected readonly DbConnection Connection;

        public ConnectionProvider(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public void Dispose() => Connection?.Dispose();
        public ValueTask DisposeAsync() => Connection.DisposeAsync();
    }
}
