using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAutopark.DataAccesLayer.Interfaces
{
    public interface IRepository<T>
            where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);

        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
