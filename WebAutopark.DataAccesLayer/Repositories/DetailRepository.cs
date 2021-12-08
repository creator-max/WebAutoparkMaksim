using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public class DetailRepository : BaseRepository<Detail>, IRepository<Detail>
    {
        private const string QueryGetAll = "SELECT * FROM Details";

        private const string QueryGetById = "SELECT * FROM Details " +
                                             "WHERE DetailId = @DetailId";

        private const string QueryCreate = "INSERT Details VALUES(DetailName)";

        private const string QueryDelete = "DELETE FROM Details" +
                                            "WHERE DetailId = @DetailId";

        private const string QueryUpdate = "UPDATE Details SET" +
                                            "DetailName = @DetailName," +
                                            "WHERE DetailId = @DetailId";

        public DetailRepository(string connectionString) :
            base(connectionString)
        { }

        public virtual async Task CreateAsync(Detail item) => await Connection.ExecuteAsync(QueryCreate, item);
        public virtual async Task DeleteAsync(int id) => await Connection.ExecuteAsync(QueryDelete, id);
        public virtual async Task<IEnumerable<Detail>> GetAllAsync() => await Connection.QueryAsync<Detail>(QueryGetAll);
        public virtual async Task<Detail> GetByIdAsync(int id) => await Connection.QueryFirstOrDefaultAsync<VehiclieType>(QueryGetByID, id);
        public virtual async Task UpdateAsync(Detail item) => await Connection.ExecuteAsync(QueryUpdate, item);

    }
}
