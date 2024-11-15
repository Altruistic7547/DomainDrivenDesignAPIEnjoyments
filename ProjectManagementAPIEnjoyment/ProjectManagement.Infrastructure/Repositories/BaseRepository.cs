using Microsoft.EntityFrameworkCore;
using ProjectManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected DbSet<TEntity> DbContextSet => _dbContext.Set<TEntity>();

        public BaseRepository(ProjectManagementDbContext dbContext) =>
            _dbContext = dbContext;

        public void Dispose()
        {
            _dbContext.Dispose();

            GC.SuppressFinalize(this);
        }

        protected async Task<bool> SaveChangesAsync()
        {
            var changes = await _dbContext.SaveChangesAsync();
            return changes > 0;
        }

        protected async Task<bool> AddAsync(TEntity entityData)
        {
            await DbContextSet.AddAsync(entityData);
            return await SaveChangesAsync();
        }

        protected async Task<IList<TEntity>> GetEntitiesAsync()
        {
            return await DbContextSet.AsQueryable().ToListAsync();
        }

        protected async Task<TEntity> GetEntityAsync<TId>(TId id)
        {
            var entity = await DbContextSet.FindAsync(id);
            return entity;
        }

        protected TEntity Create(TEntity entity)
        {
            DbContextSet.Add(entity);
            return entity;
        }

        protected async Task<TEntity> EditAsync(TEntity entity)
        {
            DbContextSet.Update(entity);
            await SaveChangesAsync();
            return entity;
        }

        protected async Task DeleteAsync(object id)
        {
            var entityToDelete = await _dbContext.FindAsync(typeof(TEntity), id);
            _dbContext.Entry(entityToDelete).State = EntityState.Modified;
            _dbContext.Remove(entityToDelete);
            await SaveChangesAsync();
        }
    }
}
