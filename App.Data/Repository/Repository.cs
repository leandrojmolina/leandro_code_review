using App.Domain.Interfaces.Repository;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.API.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repository
{

   

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly SampleAppContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(SampleAppContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<TEntity> GetAsNoTracking(Guid id)
        {
            return await DbSet.AsNoTracking().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }


        public async Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking()
                              .Where(predicate)
                              .ToListAsync();
        }


        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
        public async Task<List<TEntity>> GetAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
    }
}
