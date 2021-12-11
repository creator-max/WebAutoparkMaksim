using Microsoft.Data.SqlClient;
using System;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public abstract class BaseRepository : IDisposable, IAsyncDisposable
    {
        protected readonly DbConnection Connection;

        public BaseRepository(IConnectionStringProvider connectionStringProvider)
        {
            Connection = new SqlConnection(connectionStringProvider.GetConnectionString());
        }

        public void Dispose() => Connection?.Dispose();
        public ValueTask DisposeAsync() => Connection.DisposeAsync();
    }
}
