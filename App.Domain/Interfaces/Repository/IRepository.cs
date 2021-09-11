using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entities.Entity
    {

        Task<List<TEntity>> GetAsync();

        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetAsNoTracking(Guid id);

        Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate);

    }
}
