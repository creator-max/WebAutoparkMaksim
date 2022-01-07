using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.DataAccesLayer.Interfaces;
using AutoMapper;

namespace WebAutopark.BusinessLogicLayer.Services.Base
{
    public abstract class BaseService<TDto, TEntity> : IDataService<TDto>
        where TDto : class
        where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task Create(TDto item)
        {
            var entity = _mapper.Map<TEntity>(item);
            return _repository.Create(entity);
        }

        public Task Delete(int id)
        {
            return _repository.Delete(id);
        }

        public virtual async Task<IEnumerable<TDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtoItems = _mapper.Map<List<TDto>>(entities);
            return dtoItems;
        }

        public virtual async Task<TDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            var dtoItem = _mapper.Map<TDto>(entity);
            return dtoItem;
        }

        public Task Update(TDto item)
        {
            var entity = _mapper.Map<TEntity>(item);
            return _repository.Update(entity);
        }
    }
}
