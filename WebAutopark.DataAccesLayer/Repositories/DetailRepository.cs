using WebAutopark.DataAccesLayer.Entities;

namespace WebAutopark.DataAccesLayer.Repositories
{
    class DetailRepository : BaseRepository<VehicleType>
    {
        private const string _queryGetAll = "SELECT * FROM Details";

        private const string _queryGetById = "SELECT * FROM Details " +
                                             "WHERE DetailId = @DetailId";

        private const string _queryCreate = "INSERT Details VALUES(DetailName)";

        private const string _queryDelete = "DELETE FROM Details" +
                                            "WHERE DetailId = @DetailId";

        private const string _queryUpdate = "UPDATE Details SET" +
                                            "DetailName = @DetailName," +
                                            "WHERE DetailId = @DetailId";
        public DetailRepository(string connectionString) :
            base(connectionString, _queryGetAll,
                 _queryGetById, _queryCreate,
                 _queryDelete, _queryUpdate)
        { }

    }
}
