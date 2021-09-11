using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Interfaces
{
    public interface IService<TEntity> : IDisposable
    {
        Task<List<TEntity>> GetAsync();

        Task<TEntity> GetAsNoTracking(Guid id);

        Task<TEntity> GetByIdAsync(Guid id);

        Task<Guid> AddAsync(TEntity entity);

        Task AddRangeAsync(List<TEntity> entity);
        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

    }
}
