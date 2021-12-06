using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly string ConnectionString;
        protected readonly string QueryGetAll;
        protected readonly string QueryGetByID;
        protected readonly string QueryCreate;
        protected readonly string QueryDelete;
        protected readonly string QueryUpdate;

        public BaseRepository(string connectionString,
                              string queryGetAll,
                              string queryGetById,
                              string queryCreate,
                              string queryDelete,
                              string queryUpdate)
        {
            ConnectionString = connectionString;
            QueryGetAll = queryGetAll;
            QueryGetByID = queryGetById;
            QueryCreate = queryCreate;
            QueryDelete = queryDelete;
            QueryUpdate = queryUpdate;
        }

        public virtual async Task CreateAsync(T item)
        {
            using(DbConnection db = new SqlConnection(ConnectionString))
            {
                await db.ExecuteAsync(QueryCreate, item);
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            using (DbConnection db = new SqlConnection(ConnectionString))
            {
                await db.ExecuteAsync(QueryDelete, id);
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            using (DbConnection db = new SqlConnection(ConnectionString))
            {
                return await db.QueryAsync<T>(QueryGetAll);
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            using (DbConnection db = new SqlConnection(ConnectionString))
            {
                return await db.QueryFirstOrDefaultAsync<T>(QueryGetByID, id);
            }
        }

        public virtual async Task UpdateAsync(T item)
        {
            using (DbConnection db = new SqlConnection(ConnectionString))
            {
                await db.ExecuteAsync(QueryUpdate, item);
            }
        }
    }
}
