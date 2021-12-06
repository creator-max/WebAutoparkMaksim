using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAutopark.DataAccesLayer.Interfaces
{
    public interface IRepository<T>
            where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}
