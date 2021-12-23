using WebAutopark.BusinessLogicLayer.Services.Base;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using AutoMapper;

namespace WebAutopark.BusinessLogicLayer.Services
{
    public class DetailService : BaseService<DetailDto, Detail>
    {
        public DetailService(IRepository<Detail> repository, IMapper mapper) 
            : base(repository, mapper)
        { }
    }
}
