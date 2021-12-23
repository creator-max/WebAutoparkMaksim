using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.DataAccesLayer.Interfaces;
using AutoMapper;
using System.Linq;

namespace WebAutopark.BusinessLogicLayer.Services.Base
{
    public abstract class BaseService<TDto, TEntity> : IDtoService<TDto>
        where TDto : IBusinessDto
        where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task Create(TDto item)
        {
            await _repository.Create(_mapper.Map<TEntity>(item));
        }

        public virtual async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public virtual async Task<IEnumerable<TDto>> GetAll()
        {
            var entities =  await (_repository.GetAll());
            return _mapper.Map<List<TDto>>(entities);
        }

        public virtual async Task<TDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task Update(TDto item)
        {
            var entity = _mapper.Map<TEntity>(item);
            await _repository.Update(entity);
        }
    }
}
