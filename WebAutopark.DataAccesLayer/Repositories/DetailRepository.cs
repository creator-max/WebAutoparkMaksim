using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public class DetailRepository : BaseRepository, IRepository<Detail>
    {
        private const string QueryGetAll = "SELECT * FROM Details";

        private const string QueryGetById = "SELECT * FROM Details " +
                                            "WHERE DetailId = @DetailId";

        private const string QueryCreate = "INSERT INTO Details VALUES(@DetailName)";

        private const string QueryDelete = "DELETE FROM Details" +
                                           "WHERE DetailId = @DetailId";

        private const string QueryUpdate = "UPDATE Details SET" +
                                           "DetailName = @DetailName" +
                                           "WHERE DetailId = @DetailId";

        public DetailRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public virtual async Task Create(Detail item) => await Connection.ExecuteAsync(QueryCreate, item);
        public virtual async Task Delete(int id) => await Connection.ExecuteAsync(QueryDelete, id);
        public virtual async Task<IEnumerable<Detail>> GetAll() => await Connection.QueryAsync<Detail>(QueryGetAll);
        public virtual async Task<Detail> GetById(int id) => await Connection.QueryFirstOrDefaultAsync<Detail>(QueryGetById, id);
        public virtual async Task Update(Detail item) => await Connection.ExecuteAsync(QueryUpdate, item);

    }
}
