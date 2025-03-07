using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimoshStore
{
    // Class should be public (if you're using it outside the current namespace or project).
    internal class DataRepository : IDataRepository
    {
        private readonly AppDbContext _dbContext;

        // Constructor that accepts DbContext
        public DataRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); // null check for safety
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : EntityBase
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll<T>() where T : EntityBase
        {
            return _dbContext.Set<T>();
        }

        public async Task<T> AddAsync<T>(T entity) where T : EntityBase
        {
            entity.Id = default; // Ensure that the ID is reset before inserting
            entity.CreatedAt = DateTime.UtcNow;

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T?> UpdateAsync<T>(T entity) where T : EntityBase
        {
            if (entity.Id == default)
            {
                return null;
            }

            var dbEntity = await GetByIdAsync<T>(entity.Id);
            if (dbEntity == null)
            {
                return null;
            }

            entity.CreatedAt = dbEntity.CreatedAt; // Maintain the original creation time

            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync<T>(int id) where T : EntityBase
        {
            var entity = await GetByIdAsync<T>(id);

            if (entity == null)
            {
                return;
            }

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
